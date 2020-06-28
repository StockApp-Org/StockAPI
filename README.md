# StockAPI
Backend API Project for the https://github.com/StockApp-Org/StockApp project.

### Technology
* Backend API
  - This is built with .NET Core 3.1, acting as a CRUD API.
 The API implements the ORM EF Core for database operations and abstractions.

* Database
  - MySQL relational Database were we store items such as user details, company information, stock share details and the relations therein.

#### Usage
When initially cloning, in the StockAPI folder, add appsettings.json and configure the database connection string.

"ConnectionStrings": {
  "Database":"Server=[DB_SERVER];port=[DB_SERVER_PORT];Database=[DB_NAME];User=[DB_SERVER_USER];Password=[DB_SERVER_USER_PASSWORD]"
  }

To run this, please verify that the machine has the .NET Core 3.1 Runtime installed.
https://dotnet.microsoft.com/download/dotnet-core/3.1
