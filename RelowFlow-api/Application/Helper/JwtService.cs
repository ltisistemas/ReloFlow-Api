using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RelowFlow_api.Domain.Entities.User;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace RelowFlow_api.Application.Helper;

public class JwtService
{
    private readonly string _jwtKey;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _expiresMinutes;

    public JwtService(IConfiguration configuration)
    {
        // Tenta ler da variável de ambiente primeiro, depois do Configuration
        _jwtKey = Environment.GetEnvironmentVariable("JWT_KEY")
            ?? configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("JWT Key não configurada");
        _issuer = configuration["Jwt:Issuer"]
            ?? throw new InvalidOperationException("JWT Issuer não configurado");
        _audience = configuration["Jwt:Audience"]
            ?? throw new InvalidOperationException("JWT Audience não configurado");

        if (!int.TryParse(configuration["Jwt:ExpiresMinutes"], out _expiresMinutes))
        {
            _expiresMinutes = 43200; // Default 30 dias
        }
    }

    public string GenerateToken(User user)
    {
        if (string.IsNullOrEmpty(_jwtKey) || _jwtKey.Length < 32)
        {
            throw new InvalidOperationException("JWT Key deve ter pelo menos 32 caracteres");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, string.Concat(user.FirstName, " ", user.LastName)),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_expiresMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}