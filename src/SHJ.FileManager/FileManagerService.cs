using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SHJ.FileManager.Contracts;
using SHJ.FileManager.Entities;
using SHJ.FileManager.Extentions;
using SHJ.FileManager.Options;
using SHJ.FileManager.SQL;
using System.IO;

namespace SHJ.FileManager;

internal class FileManagerService : IFileManagerService
{
    private readonly IDocumentRepository _repository;
    private readonly FileManagerOptions _options;
    private IHostingEnvironment _environment;
    public FileManagerService(IOptions<FileManagerOptions> options, IHostingEnvironment environment)
    {
        _options = options.Value;
        if (options.Value.Database == DatabaseType.MSSQL)
        {
            _repository = new SqlDocumentRepository(options.Value);
        }
        else
        {
            throw new Exception("FileManager : The database is not supported");
        }
        _environment = environment;
    }


    public async Task<DocumentRecord> UploadInServerAsync(IFormFile file, string path="")
    {
        var existDirectory = _environment.ContentRootPath + "wwwroot/" + path;
        if (!Directory.Exists(existDirectory))
        {
            Directory.CreateDirectory(existDirectory);
        }
        var document = await UploadToolser.UploadAsync(file, path);
        document.SetUploadType(UploadType.InServer);
        await _repository.InsertAsync(document);
        return document;
    }

   
    public async Task<List<DocumentRecord>> UploadInServerAsync(List<IFormFile> files, string path="")
    {
        var existDirectory = _environment.ContentRootPath + "wwwroot/" + path;
        if (!Directory.Exists(existDirectory))
        {
            Directory.CreateDirectory(existDirectory);
        }
        var documents = await UploadToolser.UploadAsync(files, path);
        documents.ForEach(_ => _.SetUploadType(UploadType.InServer));
        await _repository.InsertManyAsync(documents);
        return documents;
    }
}
