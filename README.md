# Camping Blog (ASP.NET Core)

A camping blog web app built with ASP.NET Core 6 MVC for the COMP-2084G Server-Side Scripting course (Lakehead-Georgian). It was deployed to Azure App Service through a GitHub Actions workflow.

## Features

- Create, view, edit and delete blog posts and post categories
- User accounts with ASP.NET Core Identity, with Google and Facebook sign-in packages wired in
- Entity Framework Core with SQL Server and code-first migrations
- Controller unit tests that use the EF Core in-memory provider
- CI/CD: build, publish and deploy to Azure on push (`.github/workflows`)

## Project layout

- `campingBlog/`: the MVC app (controllers, models, views, migrations)
- `CampingBlogTests/`: tests for the posts controller

## Run it locally

1. Install the .NET 6 SDK and SQL Server (or LocalDB).
2. Set the database connection string without committing it:
   ```
   cd campingBlog
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=...;Database=...;..."
   ```
3. `dotnet ef database update`, then `dotnet run`.

## Author

Aleksandr Zheleznov. [GitHub](https://github.com/Aleks4920)
