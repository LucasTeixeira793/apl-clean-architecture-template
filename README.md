# 🧱 Clean Architecture - Estrutura do Projeto

Este projeto segue os princípios da **Clean Architecture**, organizando as responsabilidades de forma clara entre as camadas:

## 📁 Camadas da Solução

### 🧩 Domain
- **Responsabilidade:** Regras de negócio puras e imutáveis.
- **Não deve depender de nenhuma outra camada.**
- **Contém:**
  - Entidades (`Blog`, `User`, etc)
  - Value Objects
  - Enums
  - Interfaces (ex: `IRepository`, `IService`)

### ⚙️ Application
- **Responsabilidade:** Casos de uso, lógica de orquestração e validações.
- **Pode depender apenas de `Domain`.**
- **Contém:**
  - Use Cases (`CreateBlogCommandHandler`)
  - DTOs
  - Commands e Queries (CQRS)
  - Interfaces para serviços de aplicação
  - Validações (`FluentValidation`, etc)

### 🏗 Infrastructure
- **Responsabilidade:** Implementações técnicas externas.
- **Depende de `Application` e `Domain`.**
- **Contém:**
  - EF Core DbContext (`AppDbContext`)
  - Repositórios (`Repository<T>`)
  - Serviços externos (`EmailService`, `S3Service`)
  - Mapeamentos (AutoMapper Profiles, EF Configs)

### 🎤 Presentation
- **Responsabilidade:** Interface pública da aplicação (Controllers).
- **Depende de `Application`.**
- **Contém:**
  - Controllers (`BlogController`)
  - Request Models e Response Models (DTOs para API)
  - Filtros de exceção e atributos

### 🚀 Web (EntryPoint)
- **Responsabilidade:** Execução e configuração da aplicação.
- **Depende de todas as outras camadas.**
- **Contém:**
  - `Program.cs`
  - `Startup.cs` ou `WebApplicationBuilder`
  - Configurações (Swagger, Serilog, etc)
  - Service Registration

---

## ✅ Exemplos de Alocação de Classes

| Tipo de Classe                      | Camada         |
|------------------------------------|----------------|
| `Blog` (entidade)                  | Domain         |
| `CreateBlogCommand`, `BlogDto`     | Application    |
| `CreateBlogCommandHandler`         | Application    |
| `IBlogRepository`                  | Domain         |
| `BlogRepository`                   | Infrastructure |
| `BlogController`                   | Presentation   |
| `BlogRequest`, `BlogResponse`      | Presentation   |
| `AppDbContext`                     | Infrastructure |
| `Program.cs`, `Startup.cs`         | Web            |

---

## 🔐 Regras de Dependência

- `Domain` → depende de ninguém.
- `Application` → depende de `Domain`.
- `Infrastructure` → depende de `Application` e `Domain`.
- `Presentation` → depende de `Application`.
- `Web` → depende de todas.
