SHJ.FileManager
=======

Simple SHJ.FileManager implementation in .NET
Supports upload files,validation files,get all directories in asp 
Examples in the [wiki](https://github.com/jabbekhaneh/SHJ.FileManager).

<!-- ### How do I get started? -->

### Installing SHJ.FileManager
You should install [SHJ.FileManager with NuGet](https://www.nuget.org/packages/SHJ.FileManager):

```bash
> Install-Package SHJ.FileManager
```

Or via the .NET Core command line interface:
   
```bash
> dotnet add package SHJ.FileManager
```

### Registering with `IServiceCollection`

```
services.AddFileManager(option =>
{
    option.DatabaseName = "dbFileManager";
    option.ConnectionString = conntection;
});
```

### Registering with `IApplicationBuilder`

```
app.UseStaticFiles();
app.UseFileManager();
```

How to change database Supports database 
```csharp
option.Database= DatabaseType.MSSQL
```

### UI Framework Options



# Completing soon ...
