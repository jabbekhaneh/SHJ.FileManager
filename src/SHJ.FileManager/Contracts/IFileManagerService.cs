using Microsoft.AspNetCore.Http;
using SHJ.FileManager.Entities;

namespace SHJ.FileManager.Contracts;

public interface IFileManagerService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    Task<DocumentRecord> UploadInServer(IFormFile file);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="file"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    Task<DocumentRecord> UploadInServer(IFormFile file, string path);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="files"></param>
    /// <returns></returns>
    Task<List<DocumentRecord>> UploadInServer(List<IFormFile> files);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="files"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    Task<List<DocumentRecord>> UploadInServer(List<IFormFile> files, string path);
    
    //--------
    //Task UploadInDatabase(IFormFile file);
    //Task UploadManyInDatabase(List<IFormFile> files);
}
