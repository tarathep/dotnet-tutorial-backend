# Dotnet Tutorial Backend API

## ASP.NET

ASP.NET is an open source web framework, created by Microsoft, for building modern web apps and services with .NET. ASP.NET is cross platform and runs on Windows, Linux, macOS, and Docker.

more : https://dotnet.microsoft.com/en-us/learn/aspnet/what-is-aspnet

## Init Project

Create solution project

```ps
dotnet new sln -n Tutorial-Api
```

Create ASP.NET Web Api project

```ps
dotnet new webapi -o Api
```

Create xUnit project

```ps
dotnet new xunit -o Xunit.Tests
```

Add projects to solution

```ps
dotnet sln add .\Tutorial.Api\Tutorial.Api.csproj
dotnet sln add .\XUnit.Tests\XUnit.Tests.csproj
```

Add reference project into xunit project

```ps
dotnet add ./XUnit.Tests/XUnit.Tests.csproj reference .\Tutorial.Api\Tutorial.Api.csproj
```

## Run

```ps
dotnet run --project ./Tutorial.Api/
```

https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-run#examples

## Build

```ps
dotnet build
```

## Unit Tests

Run Coverage

```ps
dotnet test --collect:"XPlat Code Coverage"
```

Add ReportGenerator nuget

```ps
dotnet add package ReportGenerator --version 5.1.10
```

Setup tool ReportGenerator

```ps
dotnet tool install -g dotnet-reportgenerator-globaltool
```

more : https://www.nuget.org/packages/ReportGenerator

## Run report HTML

```ps
reportgenerator -reports:"XUnit.Tests\TestResults\*\coverage.cobertura.xml" -targetdir:"./coveragereport" -reporttypes:Html
```

## Configurations on File or Overide Environment variables

