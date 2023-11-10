using Microsoft.AspNetCore.Http;
using SHJ.FileManager.Entities;

namespace SHJ.FileManager.Contracts;

public interface IFileManagerService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="file"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    Task<DocumentRecord> UploadInServerAsync(IFormFile file, string path = "");

    /// <summary>
    /// 
    /// </summary>
    /// <param name="files"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    Task<List<DocumentRecord>> UploadInServerAsync(List<IFormFile> files, string path = "");

    //--------
    //Task UploadInDatabase(IFormFile file);
    //Task UploadManyInDatabase(List<IFormFile> files);
}
