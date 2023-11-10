using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SHJ.FileManager.Contracts;

namespace SHJ.FileManager.Controllers
{
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
            await _services.UploadInServerAsync(file,"Folder_1/Folder_2");
            return Ok();
        }

        [HttpPost("Many")]
        public async Task<IActionResult> UploadMany(List<IFormFile> files)
        {
            await _services.UploadInServerAsync(files, "Folder_200");
            return Ok();
        }
    }
}
