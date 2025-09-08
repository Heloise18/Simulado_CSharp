dotnet new web
dotnet new gitignore

Primeiros passos: 
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

Migrations:
$env:SQL_CONNECTION = "Data Source=localhost;Initial Catalog=Fofoquinha;Trust Server Certificate=true;Integrated Security=true"

dotnet add package usecases("obs: OLhar repositorio usecases do trevis ")

dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialModel
dotnet ef database update

dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package Microsoft.NET.Test.Sdk
dotnet add package Moq

JWT:
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
$env:JWT_SECRET ""


SWAGGER:
dotnet add package Swashbuckle.AspNetCore
