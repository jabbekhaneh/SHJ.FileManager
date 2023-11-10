namespace SHJ.FileManager.SQL.CommandTexts;

public class DocumentCommandTexts
{
    public static string CreateTable(string tableName, string schema = "dbo") 
        => $"IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES WHERE " +
                 $"TABLE_SCHEMA = '{schema}' AND  TABLE_NAME = '{tableName}' )) Begin " +
                 $"CREATE TABLE [{schema}].[{tableName}]( " +
                 $"Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT (NEWID())," +
                 $"[Path] [nvarchar](1500) NULL," +
                 $"[FileName] [nvarchar](1500) NOT NULL," +
                 $"[FileType] [nvarchar](256) NULL," +
                 $"[FileExtension] [nvarchar](256) NULL," +
                 $"[FileByte] [varbinary](MAX)  NULL," +
                 $"[UploadType] [tinyint] NOT NULL," +
                 $"[CreateDataTime] [datetime2] NOT NULL," +
                 $")" +
                 $" End";

    public static string InsertINTO(string tableName, string schema = "dbo") 
                         => $"INSERT INTO {schema}.{tableName}" +
        $"                           (FileName,CreateDataTime,Path,FileByte,UploadType,FileExtension,FileType)" +
                            $"VALUES (@FileName,@CreateDataTime,@Path,@FileByte,@UploadType,@FileExtension,@FileType)";

    
}
