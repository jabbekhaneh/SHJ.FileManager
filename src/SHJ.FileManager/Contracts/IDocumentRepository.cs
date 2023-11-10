using SHJ.FileManager.Entities;

namespace SHJ.FileManager.Contracts;

internal interface IDocumentRepository
{
    Task InsertAsync(DocumentRecord document);
    Task InsertManyAsync(List<DocumentRecord> documents);
}
