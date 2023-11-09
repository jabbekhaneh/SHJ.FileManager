using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SHJ.FileManager.Contracts;
using SHJ.FileManager.Entities;
using SHJ.FileManager.Extentions;
using SHJ.FileManager.Options;
using SHJ.FileManager.SQL;

namespace SHJ.FileManager;

internal class FileManagerService : IFileManagerService
{
    private readonly IDocumentRepository _repository;
    private readonly FileManagerOptions _options;

    public FileManagerService(IOptions<FileManagerOptions> options)
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
    }

    public async Task<DocumentRecord> UploadInServer(IFormFile file)
    {
        var document = UploadToolser.Upload(file, "wwwroot");
        document.SetUploadType(UploadType.InServer);
        await _repository.InsertAsync(document);
        return document;
    }

    public async Task<DocumentRecord> UploadInServer(IFormFile file, string path)
    {
        var document = UploadToolser.Upload(file, path);
        document.SetUploadType(UploadType.InServer);
        await _repository.InsertAsync(document);
        return document;
    }

    public Task<List<DocumentRecord>> UploadInServer(List<IFormFile> files)
    {
        throw new NotImplementedException();
    }
    public Task<List<DocumentRecord>> UploadInServer(List<IFormFile> files, string path)
    {
        throw new NotImplementedException();
    }
}
