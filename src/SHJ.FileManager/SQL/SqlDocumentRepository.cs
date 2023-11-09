using Dapper;
using SHJ.FileManager.Contracts;
using SHJ.FileManager.Entities;
using SHJ.FileManager.Options;
using SHJ.FileManager.SQL.CommandTexts;
using System.Data;
using System.Data.SqlClient;

namespace SHJ.FileManager.SQL;

internal class SqlDocumentRepository : IDocumentRepository, IDisposable
{
    private readonly FileManagerOptions _options;
    private readonly IDbConnection _connection;
    public SqlDocumentRepository(FileManagerOptions options)
    {
        _options = options;
        ValidationOption(options);
        _connection = new SqlConnection(options.ConnectionString);
        ConnectedDatabase();
    }

   

    public async Task InsertAsync(DocumentRecord document)
    {
        await _connection.ExecuteAsync(DocumentCommandTexts
            .InsertINTO(_options.TableName, _options.SchemaName), document);
    }

    public void Dispose()
    {
        _connection.Close();
    }
    private void ConnectedDatabase()
    {
        _connection.Open();
        _connection.Execute(DocumentCommandTexts.CreateTable(_options.TableName, _options.SchemaName));
    }

    private static void ValidationOption(FileManagerOptions options)
    {
        if (options.Database != DatabaseType.MSSQL)
            throw new ArgumentException(nameof(options.Database));
        if (string.IsNullOrEmpty(options.ConnectionString))
            throw new ArgumentException("Filemanager:ConnectionString is null");
        if (string.IsNullOrEmpty(options.DatabaseName))
            throw new ArgumentException("Filemanager:DatabaseName is null");
    }
}
