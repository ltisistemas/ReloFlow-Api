# RelowFlow API

> Sistema de gestão de leads e empresas de relocation desenvolvido em .NET 8.0

## 📋 Sobre o Projeto

RelowFlow é uma API RESTful desenvolvida para gerenciar leads, empresas de relocation e seus processos. O sistema oferece funcionalidades completas para gestão de usuários, empresas, leads, membros de leads e templates de documentos, com suporte a autenticação JWT e controle de acesso.

### Principais Funcionalidades

- 🔐 **Autenticação e Autorização** - Sistema de autenticação JWT com rate limiting
- 👥 **Gestão de Usuários** - CRUD completo de usuários com perfis detalhados
- 🏢 **Gestão de Empresas** - Criação e administração de empresas de relocation
- 📊 **Gestão de Leads** - Sistema Kanban para acompanhamento de leads
- 👨‍👩‍👧‍👦 **Membros de Leads** - Gestão de membros associados aos leads
- 📄 **Templates de Documentos** - Configuração de templates por posição no Kanban
- 🔒 **Rate Limiting** - Proteção contra abuso com limites configuráveis
- 📝 **Validação** - Validação robusta com FluentValidation
- 🗄️ **Auditoria** - Interceptação automática de mudanças no banco de dados

## 🛠️ Tecnologias

- **.NET 8.0** - Framework principal
- **PostgreSQL** - Banco de dados
- **Entity Framework Core** - ORM
- **JWT Bearer** - Autenticação
- **FluentValidation** - Validação de dados
- **Serilog** - Logging estruturado
- **Swagger/OpenAPI** - Documentação da API
- **BCrypt** - Hash de senhas

## 📦 Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/) (versão 12 ou superior)
- [Git](https://git-scm.com/)

## 🚀 Configuração Inicial

### 1. Clone o repositório

```bash
git clone <url-do-repositorio>
cd RelowFlow
```

### 2. Configure o banco de dados

Crie um banco de dados PostgreSQL:

```sql
CREATE DATABASE relowflow_db;
```

### 3. Configure as variáveis de ambiente

Crie um arquivo `.env` na raiz do projeto `RelowFlow-api/`:

```env
CONNECTION_STRING=Host=localhost;Port=5432;Database=relowflow_db;Username=seu_usuario;Password=sua_senha
JWT_KEY=sua_chave_secreta_jwt_minimo_32_caracteres_para_seguranca
```

**⚠️ Importante:** 
- A `JWT_KEY` deve ter no mínimo 32 caracteres para garantir segurança
- Nunca commite o arquivo `.env` no repositório
- Use uma chave forte e única em produção

### 4. Configure o appsettings.json (Opcional)

Alternativamente, você pode configurar no `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=relowflow_db;Username=seu_usuario;Password=sua_senha"
  },
  "Jwt": {
    "Key": "sua_chave_secreta_jwt_minimo_32_caracteres",
    "Issuer": "minha-api",
    "Audience": "minha-api-clientes",
    "ExpiresMinutes": 43200
  },
  "AllowedOrigins": "http://localhost:3000,http://localhost:4200"
}
```

### 5. Instale as dependências

```bash
cd RelowFlow-api
dotnet restore
```

### 6. Execute as migrações

```bash
dotnet ef database update
```

Se você ainda não tem o Entity Framework Tools instalado globalmente:

```bash
dotnet tool install --global dotnet-ef
```

## ▶️ Como Executar

### Modo Desenvolvimento

```bash
cd RelowFlow-api
dotnet run
```

A API estará disponível em:
- **HTTP:** `http://localhost:5219`
- **HTTPS:** `https://localhost:7252`
- **Swagger UI:** `http://localhost:5219/swagger`

### Modo Produção

```bash
cd RelowFlow-api
dotnet publish -c Release -o ./publish
cd publish
dotnet RelowFlow-api.dll
```

## 📚 Documentação da API

A documentação completa da API está disponível em:

- **Swagger UI:** Acesse `/swagger` quando a aplicação estiver rodando
- **Documentação detalhada:** Consulte `RelowFlow-api/API_DOCUMENTATION.md`

### Endpoints Principais

- `POST /api/auth/signin` - Autenticação
- `POST /api/auth/signup` - Cadastro de usuário
- `GET /api/user` - Listar usuários
- `GET /api/company` - Listar empresas
- `POST /api/company` - Criar empresa
- `GET /api/lead` - Listar leads
- `POST /api/lead` - Criar lead
- `PATCH /api/lead/{id}/position` - Atualizar posição do lead (Kanban)

## 🔧 Configurações Pós-Instalação

### 1. Configurar CORS

Edite `appsettings.json` para adicionar as origens permitidas:

```json
{
  "AllowedOrigins": "http://localhost:3000,http://localhost:4200,https://seu-dominio.com"
}
```

### 2. Configurar Rate Limiting

Os limites padrão estão configurados em `Program.cs`:
- Login: 5 tentativas por minuto
- Cadastro: 3 tentativas por hora
- Outros endpoints: 100 requisições por minuto

### 3. Health Checks

A API possui endpoints de health check:
- `GET /health` - Health check básico
- `GET /health/ready` - Health check com verificação de banco de dados

## 🧪 Testes

Para executar os testes (quando disponíveis):

```bash
dotnet test
```

## 📝 Estrutura do Projeto

```
RelowFlow-api/
├── Application/          # Camada de aplicação
│   ├── Controllers/     # Controllers da API
│   ├── Dtos/           # Data Transfer Objects
│   ├── Services/       # Serviços de negócio
│   ├── Validators/     # Validações FluentValidation
│   └── Middleware/     # Middlewares customizados
├── Domain/             # Camada de domínio
│   └── Entities/       # Entidades do domínio
├── Infrastructure/     # Camada de infraestrutura
│   ├── Persistence/    # Configurações do EF Core
│   └── Repositories/   # Implementações dos repositórios
└── Migrations/         # Migrações do banco de dados
```

## 🔐 Segurança

- ✅ Autenticação JWT obrigatória para endpoints protegidos
- ✅ Senhas hasheadas com BCrypt
- ✅ Rate limiting configurado
- ✅ CORS configurável
- ✅ Validação de entrada com FluentValidation
- ✅ Soft delete para preservação de dados

## 📄 Licença

Este projeto é proprietário. Todos os direitos reservados.

## 🤝 Contribuindo

Para contribuir com o projeto, siga o fluxo de trabalho Git Flow:
- `feature/**` - Novas funcionalidades
- `hotfix/**` - Correções urgentes
- `develop` - Branch de desenvolvimento
- `main` - Branch de produção

---

**Desenvolvido com ❤️ para facilitar a gestão de relocation**

