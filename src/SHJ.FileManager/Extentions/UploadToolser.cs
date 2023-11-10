using Microsoft.AspNetCore.Http;
using SHJ.FileManager.Entities;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats;
using System.Net.Http.Headers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Microsoft.VisualBasic.FileIO;

namespace SHJ.FileManager.Extentions;

internal class UploadToolser
{

    public static DocumentRecord Upload(IFormFile file, string path)
    {
        string fileType = string.Empty;
        string fileName = string.Empty;
        string newFileName = string.Empty;
        //
        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
        var fileExtension = Path.GetExtension(fileName);
        newFileName = myUniqueFileName + fileExtension;
        //
        fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + path, newFileName);
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
        using (FileStream fs = File.Create(fileName))
        {
            file.CopyTo(fs);
            fs.Flush();
            fileType = file.ContentType;
        }

        return new DocumentRecord(newFileName, path, fileType, fileExtension);
    }
    public static async Task<DocumentRecord> UploadAsync(IFormFile file, string path)
    {
        string fileType = string.Empty;
        string fileName = string.Empty;
        string newFileName = string.Empty;
        //
        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
        var fileExtension = Path.GetExtension(fileName);
        newFileName = myUniqueFileName + fileExtension;
        //
        fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + path, newFileName);
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
        using (FileStream fs = File.Create(fileName))
        {
            await file.CopyToAsync(fs);
            await fs.FlushAsync();
            fileType = file.ContentType;
        }

        return new DocumentRecord(newFileName, path, fileType, fileExtension);
    }
    public static List<DocumentRecord> Upload(IList<IFormFile> files, string path)
    {
        var documents = new List<DocumentRecord>();
        var fileName = string.Empty;
        var newFileName = string.Empty;
        string fileType = string.Empty;
        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                var FileExtension = Path.GetExtension(fileName);
                newFileName = myUniqueFileName + FileExtension;
                fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + path, newFileName);
                string fileExtension = Path.GetExtension(fileName);
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                    fileType = file.ContentType;
                }
                documents.Add(new DocumentRecord(newFileName, path, fileType, fileExtension));
            }
        }

        return documents;
    }
    public static async Task<List<DocumentRecord>> UploadAsync(IList<IFormFile> files, string path)
    {
        var documents = new List<DocumentRecord>();
        var fileName = string.Empty;
        var newFileName = string.Empty;
        string fileType = string.Empty;
        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                var FileExtension = Path.GetExtension(fileName);
                newFileName = myUniqueFileName + FileExtension;
                fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + path, newFileName);
                string fileExtension = Path.GetExtension(fileName);
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    await file.CopyToAsync(fs);
                    await fs.FlushAsync();
                    fileType = file.ContentType;
                }
                documents.Add(new DocumentRecord(newFileName, path, fileType, fileExtension));
            }
        }

        return documents;
    }

    //___________________
    //public static DocumentRecord UploadByte(IFormFile file)
    //{
    //    var documnet = new DocumentRecord();

    //    using (MemoryStream ms = new MemoryStream())
    //    {
    //        file.CopyTo(ms);
    //        documnet.FileByte = ms.ToArray();

    //    }
    //    documnet.FileName = file.FileName;
    //    documnet.FileType = file.ContentType;
    //    documnet.FileExtension = Path.GetExtension(file.FileName);
    //    return documnet;
    //}
}
