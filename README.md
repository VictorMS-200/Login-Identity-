## Description

This repository is about the use of the framework Entity Framework Core to create a database and a web API. The database is about users and their addresses. The web API has the following endpoints: User (POST)

## How to use it

Fist of all, you need to install the .NET SDK, you can find it [here](https://dotnet.microsoft.com/download). After that, you can clone this repository and run the projects in your IDE. I recommend using Visual Studio Code or Visual Studio Community. If you want to do this in Visual Studio Code, you can use the extension C# to run the projects. 

The packages are already installed in the project, but if you want to install it again or see, you can see in the file ***Entity_Framework.csproj***.

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
