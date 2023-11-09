namespace SHJ.FileManager.Options;

public sealed class FileManagerOptions
{
    
    
    public string ConnectionString { get;  set; } = string.Empty;
    public string DatabaseName { get;  set; } = string.Empty;
    public string SchemaName { get; set; } = "dbo";
    public string TableName { get;  set; } = "Documents";
    public DatabaseType Database { get; set; } = DatabaseType.MSSQL;
}

public enum DatabaseType : byte
{
    MSSQL = 1,
    Mongodb = 2,
}
