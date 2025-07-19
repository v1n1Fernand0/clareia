# Clareia 🛡️

**Sistema de Registro de Ciência de Termos Operacionais**, focado em segurança, clareza e rastreabilidade dos colaboradores.

---

## 📦 Arquitetura

- 🧱 Clean Architecture modular (Domain, Application, Infrastructure, API)
- 📚 Services com interfaces + DTOs
- 🗃️ Repositório genérico via EF Core
- 🐘 PostgreSQL como banco de dados
- 🔍 Swagger para documentação da API
- 🧪 Testes com xUnit, FluentAssertions, Moq e FakeRepository

---

## 📁 Estrutura de Pastas

Clareia/ ├── Clareia.API/ # Controllers e Program.cs ├── Clareia.Application/ # Services, Interfaces, DTOs ├── Clareia.Domain/ # Entidades e Interfaces de domínio ├── Clareia.Infrastructure/ # Repositórios, DbContext, EF Config │ └── Persistence/ │ └── Migrations/ # Migrações do EF Core ├── Clareia.Tests/ # Testes unitários e mocks │ └── Docs/ │ └── plano_teste.md # Plano de testes

---

## 🚀 Como rodar

### 📥 Clonar e instalar

```bash
git clone https://github.com/seu-usuario/clareia.git
cd clareia
dotnet restore

🔧 Configurar conexão PostgreSQL
No Clareia.API/appsettings.json:

"ConnectionStrings": {
  "Default": "Host=localhost;Port=5432;Database=clareia_db;Username=postgres;Password=123"
}

🗃️ Criar migração e banco
dotnet ef migrations add InitialCreate --project Clareia.Infrastructure --startup-project Clareia.API --output-dir Persistence/Migrations
dotnet ef database update --project Clareia.Infrastructure --startup-project Clareia.API

▶️ Rodar o projeto
dotnet run --project Clareia.API
Acesse o Swagger em https://localhost:443/swagger.

🧪 Testes
dotnet test Clareia.Tests

✅ Funcionalidades
Criar e listar termos

Registrar leitura com ciência

Rastrear compreensão de colaboradores

Auditoria com CriadoEm / CriadoPor

Validação de inputs e duplicações

💡 Futuro

🔐 Autenticação via JWT

📄 Exportação de relatórios

🧠 Resumo automático com IA

📊 Dashboards operacionais
