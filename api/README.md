# Web Stack Base – API Layer
This repository represents the backend API component of the web-stack-base project, structured to provide a robust foundation for scalable web applications.​

## 📁 Project Structure
The solution is organized into multiple projects, each encapsulating a specific concern:​

```bash
api
├── WebStackBase.Application    # Contains application logic, including service interfaces and implementations.
├── WebStackBase.Common         # Houses shared utilities, constants, and helper classes.
├── WebStackBase.Database       # SQL files, clean query and populate data
├── WebStackBase.Domain         # Defines domain entities and aggregates, adhering to DDD principles.
├── WebStackBase.Infrastructure # Implements data access layers, external service integrations, and repository patterns.
├── WebStackBase.Tests          # Contains unit and integration tests to ensure code reliability.​
├── WebStackBase.Util           # Provides additional utility functions and extensions.
├── WebStackBase.WebAPI         # Hosts the ASP.NET Core Web API controllers and middleware configurations.
````

This modular architecture promotes separation of concerns, testability, and maintainability.​

## 🚀 Features
- Clean Architecture: Adheres to Clean Architecture principles, facilitating a clear separation between business logic and infrastructure.

- Entity Framework Core: Utilizes EF Core for ORM, enabling efficient database interactions and migrations.

- Dependency Injection: Leverages built-in DI for managing service lifetimes and dependencies.

- Asynchronous Programming: Implements async/await patterns for non-blocking operations.

- Comprehensive Testing: Includes a dedicated testing project to ensure code quality and reliability.​

## 🛠️ Getting Started
Prerequisites
- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [SQL Server (local installation or Docker container)](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### 🐳 Running with Docker (Optional)

If you prefer not to install SQL Server locally, you can run both the API and SQL Server using Docker.

#### Prerequisites
- Docker 
- Docker Compose

Note: ***Docker desktop could be installed too***

#### Steps
1. Ensure Docker is running on your machine.
2. Create a docker-compose.yml file in directory you prefer with the following content:
```bash
version: "3.9"

services:
  mssql:
    container_name: mssql
    image: mcr.microsoft.com/mssql/server:2022-latest
    restart: no
    environment:
      ACCEPT_EULA:"Y"
      MSSQL_SA_PASSWORD:"${SQL_SA_PASSWORD}"
      MSSQL_BACKUP_DIR=:"/var/opt/mssql/backups"
    ports:
      - 1433:1433
    volumes:
      - ./data/mssql/backups:/var/opt/mssql/backups
      - ./data/mssql/data:/var/opt/mssql/data
      - ./data/mssql/log:/var/opt/mssql/log

networks:
  default:
    name: mssql-net
```

3. Create a `Dockerfile` in the same directory directory:
```bash
FROM mcr.microsoft.com/mssql/server:2022-latest 

USER root

RUN apt-get update
RUN apt-get install -yq curl apt-transport-https gnupg
RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/22.04/mssql-server-2022.list | tee /etc/apt/sources.list.d/mssql-server-2022.list 

RUN apt-get update
RUN apt-get install -y mssql-server-fts
RUN apt-get clean && rm -rf /var/lib/apt/lists/* && rm -rf /*.deb

USER mssql

EXPOSE 1433

CMD ["/opt/mssql/bin/sqlservr"]

```

4. Build and run the containers in the directory
```bash
docker-compose up --build
```

Make sure the docker container was created and you can access and connect the MSSQL Server

#### Running the Application

1. Clone the repository:

```bash
git clone https://github.com/alejograjal/web-stack-base.git
cd web-stack-base/api
```

2. Restore dependencies:

```bash
dotnet restore
```

4. Apply database migrations:

Make sure to add the connection string in you appsettings.json or secrets file

```bash
"ConnectionStrings": {
    "WebStackBase": ""
},
```
or 
```bash
"ConnectionStrings:WebStackBase": "Data Source=localhost;Initial Catalog=WebStackBase;Persist Security Info=True;User ID=sa;Password=\"{saPassword}\";TrustServerCertificate=True",
```

```bash
cd ./web-stack-base/api/WebStackbase.WebAPI
dotnet ef database update -p ../WebStackBase.Infrastructure/WebStackBase.Infrastructure.csproj
````

5. Run the API:

Before running make sure to complete the appsettings.json or secrets file with this configuration properties

```bash
"AuthenticationConfiguration": {
    "JwtSettings": {
      "Secret": "",
      "TokenLifetime": "00:15:00"
    }
},
"SmtpSettings": {
    "Host": "smtp.gmail.com",
    "Port": 587,
    "DisplayName": "{Display name}",
    "EnableSsl": true
},
  "TemplateSettings": {
    "BasePath": ""
},
```
or
```bash
"AuthenticationConfiguration:JwtSettings_Secret": "{JWT_Secret}",
"AuthenticationConfiguration:JwtSettings_TokenLifetime": "00:15:00",
"SmtpSettings:Username": "{SMTPUsername}",
"SmtpSettings:Password": "SMTPPassCode",
"SmtpSettings:From": "{SMTPFromEmail}",
"TemplateSettings:BasePath": "{route where templates are saved locally}"
```


```bash
dotnet run --project WebStackBase.WebAPI
````

The API will be accessible at https://localhost:5001 by default. with swagger page

## 🧪 Testing
To run the tests:

```bash
cd ./web-stack-base/api/WebStackbase.Tests
dotnet test
```
This will execute all unit and integration tests in the WebStackBase.Tests project.