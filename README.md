### **A simple program built using ASP.NET MVC for managing people and employees.**  

#### **Technologies used in the project:**  
- C#  
- .NET  
- ASP.NET Core  
- ASP.NET MVC  
- DDD, Clean Code  
- Entity Framework Core  
- Authorization and Authentication using ASP.NET Core Identity  

#### **How to run locally:**  
1. Ensure that your connection strings in `appsettings.json` point to a local SQL Server instance. 
2. Make sure the EF Core CLI tool is installed:  
   ```sh
   dotnet tool update --global dotnet-ef
   ```  
3. Open a command prompt in the **Web** folder and execute the following commands:  
   ```sh
   dotnet restore
   dotnet tool restore
   ```  
4. In the **Package Manager Console**, execute the following commands:  
   ```powershell
   Update-Database -Context PeopleManagerContext -Project PeopleManager.Infrastructure
   Update-Database -Context AppIdentityDbContext -Project PeopleManager.Infrastructure
   ```  
5. Run the application.  
   - You should be able to log in using the following credentials:  
     - **Email:** `admin@localhost`  
     - **Password:** `Admin@123`
