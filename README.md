# Web.APi with Entity Framework Core
<img src="https://img.shields.io/badge/dotnet_version-7.0.305-green">
<img src="https://img.shields.io/badge/Language-English-red">
<img src="https://img.shields.io/badge/ASP.net-core-red">

## Description

This repository is a simple study project about the use of the framework Entity Framework Core to create a database and a web API. The database is about users and their addresses. The web API has the following endpoints: User/register (POST), User/login (POST), auth (GET)

## How to use it

Fist of all, you need to install the .NET SDK, you can find it [here](https://dotnet.microsoft.com/download). After that, you can clone this repository and run the projects in your IDE. I recommend using Visual Studio Code or Visual Studio Community. If you want to do this in Visual Studio Code, you can use the extension C# to run the projects. 

The packages are already installed in the project, but if you want to install it again or see, you can see in the file ***Entity_Framework.csproj***.

### Installing the packages

Now, you need to create a database, you can do it using the command line or the NuGet Package Manager.

#### NuGet Package Manager

```bash
add-migration "Creating user"
```

#### Command line

```bash
dotnet ef migrations add "Creating user" --project .\Entity_Framework\
```

After that, you need to update the database, you can do it using the command line or the NuGet Package Manager. 

#### NuGet Package Manager

```bash
update-database
```

#### Command line

```bash
dotnet ef database update --project .\Entity_Framework\
```

Now you need to set the connection string and the security key, you can do it using the command line.

```bash
dotnet user-secrets set "ConnectionStrings:UsuarioConnection" "[ConnectionString]" --project .\Entity_Framework\
```	

```bash
dotnet user-secrets set "SymmetricSecurityKey" "[token]" --project .\Entity_Framework\
```

Now you can run the project and test it using Postman or Insomnia using the endpoints described in the description.

## Technologies

- .NET SDK
- Entity Framework Core
- ASP.NET Core
- C#
- SQL Server
- Postman
- Identity Framework Core
