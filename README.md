# web-stack-base

A clean and extensible base architecture for web applications using ASP.NET Core, TypeScript, and modern DevOps practices.

---

## 📦 Project Structure

```bash
.
├── api
│   ├── WebStackBase.Api.sln
│   ├── WebStackBase.Application        # Business logic, DTOs, interfaces
│   ├── WebStackBase.Common             # Shared logic/utilities
│   ├── WebStackBase.Database           # EF Core DbContext and Migrations
│   ├── WebStackBase.Domain             # Core business entities and enums
│   ├── WebStackBase.Infrastructure     # Repository implementation and integrations
│   ├── WebStackBase.Util               # Validators and utilities
│   ├── WebStackBase.WebAPI             # ASP.NET Core Web API
│   └── WebStackBase.Tests              # Unit tests
├── site-admin                         # (WIP) Admin frontend in TypeScript/React
├── site-public                        # (WIP) Public frontend in TypeScript/React
└── structure.txt

```

---

## 🚀 Features

- Clean architecture with separation of concerns
- ASP.NET Core Web API with x-api-version support
- Entity Framework Core
- FluentValidation
- AutoMapper
- Unit of Work and generic repository
- Swagger/OpenAPI with versioned docs
- CI/CD pipeline with GitHub Actions
- Environment-based configuration
- Ready for Docker deployment
- Future-ready: admin and public frontends

---

## 🛠️ Setup

1. **Clone the repo**
```bash
git clone https://github.com/alejograjal/web-stack-base.git
cd web-stack-base/api
```

2. **Restore dependencies**
```bash
dotnet restore
```

3. **Apply database migrations**
Make sure you're running from the `WebStackBase.WebAPI` folder. EF CLI must know where the startup project is.
```bash
dotnet ef database update --project ../WebStackBase.Infrastructure/WebStackBase.Infrastructure.csproj
```

4. **Run the app**
```bash
dotnet run --project WebStackBase.WebAPI
```

---

## 🧪 Running Tests
   Run tests from the `WebStackBase.Tests` project:
```bash
dotnet test
```

---

## 🧬 API Documentation

Swagger UI is available at:
```bash
http://localhost:{port}/swagger
```
Includes versioned documentation using x-api-version header.

---

## 🛡️ CI/CD
GitHub Actions handles:

- **Restore and build**
- **Run tests**
- **Publish build artifacts**
- **(Optional) Deployment to VPS**

---

## 📦 Environment Configuration

Each environment (Development, Staging, Production) can have its own configuration via:

- **appsettings.{Environment}.json**
- **User secrets / environment variables**
- **.env (for frontend projects)**

---

## 🌐 Frontend Projects

Coming soon:

- **site-admin:** A React + TypeScript app for managing resources.
- **site-public:** A public-facing site consuming the same API.


## 🛠️ Tech Stack

- **Backend:** ASP.NET Core (.NET 9 or later)
- **Frontend:** React / Vite (WIP)
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Validation:** FluentValidation
- **Mapping:** AutoMapper
- **Documentation:** Swashbuckle (Swagger)
- **Communication:** RESTful API (JSON)
- **Authentication:** JWT or ASP.NET Identity (to be configured)


---

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---