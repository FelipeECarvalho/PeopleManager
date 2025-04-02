A simple program built using ASP.NET MVC for managing people and employees.

Technologies used in the project
  - C#
  - .NET
  - ASP.NET Core
  - ASP.NET MVC
  - DDD, Clean Code
  - EntityFramework Core
  - Authorization and Authentication using EntityFramework Identity

How to run locally:
  1. Ensure your connection strings in appsettings.json point to a local SQL Server instance.
  2. Ensure the tool EF was already installed
     ```
     dotnet tool update --global dotnet-ef
  3. Open a command prompt in the Web folder and execute the following commands:
      ```
      dotnet restore
      dotnet tool restore
      dotnet ef database update -c catalogcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj
      dotnet ef database update -c appidentitydbcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj
  4. In the Package Manager Console execute the following commands:
     ```
     Update-Database -Context PeopleManagerContext -Project PeopleManager.Infrastructure
     Update-Database -Context AppIdentityDbContext -Project PeopleManager.Infrastructure
  5. Run the application.
       You should be able to login using the "admin@localhost" login and "Admin@123" password.
  
