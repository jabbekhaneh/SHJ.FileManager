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
        private IHostingEnvironment _environment;
        public FileManagerController(IFileManagerService services, IHostingEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            
        
            await _services.UploadInServer(file);
            return Ok();
        }
    }
}
