# 📋 GerenciadorDeTarefaFull

## 📌 Proposta do Projeto

API REST de Gerenciamento de Tarefas com interface visual para criação, edição, exclusão e filtragem de tarefas por status. O projeto foi desenvolvido seguindo **Arquitetura em Camadas** com os princípios da **Clean Architecture**, **Clean Code** e **SOLID**.

---

## ✅ O que o projeto oferece

- Criar, editar, listar e excluir tarefas
- Filtrar tarefas por status: Pendente, Em Progresso e Concluída
- Validação de dados com retorno de erros padronizados
- Documentação interativa dos endpoints via Swagger
- Interface visual consumindo a API

---

## 🖥️ Tecnologias — Backend

- .NET 8
- ASP.NET Core Web API
- C# 12
- Entity Framework Core 8
- SQL Server / LocalDB
- Swagger / OpenAPI

### Arquitetura em Camadas

| Camada | Responsabilidade |
|---|---|
| Domain | Entidades e regras de negócio |
| Application | Use Cases, DTOs e Interfaces |
| Infrastructure | Repositórios e banco de dados |
| Presentation | Controllers, Middlewares e configuração |

---

## 🌐 Tecnologias — Frontend

- Next.js 16
- React 19
- TypeScript 5
- Node.js >= 20.9.0

---

## 🔧 Restaurando o Backend

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server) ou SQL Server LocalDB
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### Passo a passo

**1.** Clone o repositório e acesse a pasta do backend

**2.** Crie o arquivo `appsettings.json` dentro do projeto `GerenciarTarefas.Presentation` com o conteúdo abaixo, substituindo os dados pelo seu banco de dados local:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GerenciarTarefasDB;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

> Se estiver usando SQL Server com usuário e senha, altere o valor de `DefaultConnection` para:
> `Server=localhost;Database=GerenciarTarefasDB;User Id=seu_usuario;Password=sua_senha;TrustServerCertificate=True`

**3.** Restaure os pacotes NuGet — o Visual Studio faz isso automaticamente ao abrir a solução. Via CLI:

```bash
dotnet restore
```

**4.** Aplique as Migrations para criar o banco de dados. Via Console do Gerenciador de Pacotes (Visual Studio):

```powershell
Update-Database -Project GerenciarTarefas.Infrastructure -StartupProject GerenciarTarefas.Presentation
```

Via CLI:

```bash
dotnet ef database update --project GerenciarTarefas.Infrastructure --startup-project GerenciarTarefas.Presentation
```

**5.** Execute o projeto pelo Visual Studio pressionando **F5** ou via CLI:

```bash
dotnet run --project GerenciarTarefas.Presentation
```

---

## 🌍 Restaurando o Frontend

### Pré-requisitos

- [Node.js >= 20.9.0](https://nodejs.org/)

### Passo a passo

**1.** Acesse a pasta do frontend

**2.** Crie o arquivo `.env.local` dentro da pasta `GerenciadorDeTarefas` com o conteúdo abaixo, substituindo a porta pela que aparecer no terminal ao iniciar o backend:

```env
NEXT_PUBLIC_API_URL=http://localhost:{porta}/api
```

**3.** Instale as dependências:

```bash
npm install
```

**4.** Execute o projeto:

```bash
npm run dev
```

---

## 🔗 Acessos

> As portas podem variar de acordo com a máquina. Verifique a porta exibida no terminal ao iniciar cada projeto.

| Serviço | Endereço padrão |
|---|---|
| API (Backend) | `http://localhost:{porta}` |
| Swagger (Documentação) | `http://localhost:{porta}/swagger` |
| Frontend | `http://localhost:3000` |
