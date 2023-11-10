## Getting Started

### How do I get started?

### Installing SHJ.FileManager

```bash
> Install-Package SHJ.FileManager
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

How to change database in sql

```csharp
option.Database= DatabaseType.MSSQL
```

### UI Framework Options
