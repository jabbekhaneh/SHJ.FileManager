using Microsoft.AspNetCore.Http;
using SHJ.FileManager.Entities;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats;
using System.Net.Http.Headers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace SHJ.FileManager.Extentions;

internal class UploadToolser
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="file"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static DocumentRecord Upload(IFormFile file, string path)
    {
        string fileType = string.Empty;
        string fileName = string.Empty;
        string newFileName = string.Empty;

        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
        var fileExtension = Path.GetExtension(fileName);
        newFileName = myUniqueFileName + fileExtension;


        fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + "/" + path, newFileName);
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

    public static string UploadImageAndResize(IFormFile imageFile,
              int height, int width, string path, string pathResize)
    {

        string uniqCode = Guid.NewGuid().ToString().Replace("-", "");
        if (imageFile.Length > 0)
        {
            FileInfo fileInfo = new FileInfo(imageFile.FileName);
            string getExt = fileInfo.Extension.ToLower();
            string newFileName = "img_" + uniqCode + getExt;
            string imgUrlSave = Path.Combine(path, newFileName);
            string imgThumbUrlSave = Path.Combine(pathResize, newFileName);
            using (var stream = new MemoryStream())
            {
                imageFile.CopyTo(stream);

                using (FileStream fs = new FileStream(imgUrlSave, FileMode.Create, FileAccess.Write))
                {
                    imageFile.CopyTo(fs);
                    stream.CopyTo(fs);
                    fs.Flush();
                }
                var image = Image.Load(imageFile.OpenReadStream());
                IImageEncoder imageEncoder = new JpegEncoder()
                {
                    Quality = 100,
                    ColorType = JpegColorType.YCbCrRatio444,
                };
                image.Mutate(x => x.Resize(width, height));
                image.Save(imgThumbUrlSave, imageEncoder);
            }

            return newFileName;

        }
        return "";
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
