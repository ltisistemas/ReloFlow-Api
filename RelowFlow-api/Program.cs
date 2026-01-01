using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RelowFlow_api.Application.Helper;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Application.Middleware;
using RelowFlow_api.Application.Services;
using RelowFlow_api.Infrastructure.Persistence;
using RelowFlow_api.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using RelowFlow_api.Application.Validators;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using RelowFlow_api.Infrastructure.Persistence.Interceptors;
using Serilog;
using DotNetEnv;
using Microsoft.Extensions.Configuration;

// Carregar variáveis de ambiente do arquivo .env
Env.Load();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));

    // Configuração das variaveis de ambiente (do .env ou appsettings)
    var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
        ?? builder.Configuration.GetConnectionString("DefaultConnection");

    var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY")
        ?? builder.Configuration["Jwt:Key"];

    if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(jwtKey))
    {
        throw new InvalidOperationException("Connection string e JWT key devem ser configurados");
    }


    // Adicionar interceptor
    builder.Services.AddSingleton<AuditInterceptor>();

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "RelowFlow API",
            Version = "v1"
        });

        // Configuração de segurança JWT - aceita apenas o token (sem Bearer)
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Token. Cole apenas o token (sem o prefixo 'Bearer'). Exemplo: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });

    });

    builder.Services.AddControllers();
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddFluentValidationClientsideAdapters();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigins", policy =>
        {
            policy.WithOrigins(
                    builder.Configuration["AllowedOrigins"]?.Split(',')
                    ?? new[] { "http://localhost:4200" })
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
    });

    // Adicionar após builder.Services.AddControllers()
    builder.Services.AddMemoryCache();
    builder.Services.Configure<IpRateLimitOptions>(options =>
    {
        options.EnableEndpointRateLimiting = true;
        options.StackBlockedRequests = false;
        options.HttpStatusCode = 429;
        options.RealIpHeader = "X-Real-IP";
        options.ClientIdHeader = "X-ClientId";
        options.GeneralRules =
        [
            new RateLimitRule
            {
                Endpoint = "POST:/api/auth/signin",
                Period = "1m",
                Limit = 5
            },

            new RateLimitRule
            {
                Endpoint = "POST:/api/auth/signup",
                Period = "1h",
                Limit = 3
            },

            new RateLimitRule
            {
                Endpoint = "*",
                Period = "1m",
                Limit = 100
            }
        ];
    });

    builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
    builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
    builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
    builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
    builder.Services.AddScoped<ICompanyPositionRepository, CompanyPositionRepository>();
    builder.Services.AddScoped<ILeadRepository, LeadRepository>();
    builder.Services.AddScoped<ILeadMemberRepository, LeadMemberRepository>();
    builder.Services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
    builder.Services.AddScoped<ICompanyPositionDocumentTemplateRepository, CompanyPositionDocumentTemplateRepository>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<ICompanyService, CompanyService>();
    builder.Services.AddScoped<ILeadService, LeadService>();
    builder.Services.AddScoped<ILeadMemberService, LeadMemberService>();
    builder.Services.AddScoped<ICompanyUserService, CompanyUserService>();
    builder.Services.AddScoped<ICompanyPositionDocumentTemplateService, CompanyPositionDocumentTemplateService>();
    builder.Services.AddScoped<ICryptHasherService, PasswordHasherService>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<JwtService>();
    builder.Services.AddValidatorsFromAssemblyContaining<SignupRequestValidator>();

    // JWT Config
    var jwtSection = builder.Configuration.GetSection("Jwt");
    var key = Encoding.UTF8.GetBytes(jwtKey);
    builder.Services
        .AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSection["Issuer"],
                ValidAudience = jwtSection["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });
    builder.Services.AddAuthorization();

    // Configurar DbContext com PostgreSQL
    builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
    {
        options.UseNpgsql(connectionString);
        var interceptor = serviceProvider.GetRequiredService<AuditInterceptor>();
        options.AddInterceptors(interceptor);
    });

    // Adicionar após builder.Services.AddDbContext
    builder.Services.AddHealthChecks()
        .AddDbContextCheck<AppDbContext>("database");

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.UseCors("AllowSpecificOrigins");

    // ordem importante:
    app.UseIpRateLimiting();
    app.UseMiddleware<JwtTokenMiddleware>(); // Processa token antes da autenticação
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapHealthChecks("/health");
    app.MapHealthChecks("/health/ready", new HealthCheckOptions
    {
        Predicate = check => check.Tags.Contains("ready")
    });

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Aplicação encerrada inesperadamente");
}
finally
{
    Log.CloseAndFlush();
}