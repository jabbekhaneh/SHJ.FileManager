namespace SHJ.FileManager.Entities;

public class DocumentRecord
{
    public DocumentRecord(string fileName, string path, string fileType, string fileExtension, byte[]? fileByte = default)
    {
        FileName = fileName;
        Path = path;
        FileType = fileType;
        FileExtension = fileExtension;
        FileByte = fileByte;
        this.CreateDataTime = DateTime.Now;
    }
    public DocumentRecord SetUploadType(UploadType uploadType)
    {
        this.UploadType = uploadType;
        return this;
    }
    public Guid Id { get; set; }
    public string Path { get; private set; } = string.Empty;
    public string FileName { get; private set; } = string.Empty;
    public string FileType { get; private set; } = string.Empty;
    public string FileExtension { get; private set; } = string.Empty;
    public byte[]? FileByte { get; private set; } = default;
    public UploadType UploadType { get; private set; }//tinyint
    public DateTime CreateDataTime { get; private set; } = default;
}
public enum UploadType : byte
{
    InServer = 1,
    InDatabase = 2,
}