using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHJ.FileManager.Contracts;

namespace SHJ.FileManager.Sample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileManagerController : ControllerBase
{
    private readonly IFileManagerService _services;
    public FileManagerController(IFileManagerService services)
    {
        _services = services;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        await _services.UploadInServer(file, "hasanImg");
        return Ok();
    }
}
