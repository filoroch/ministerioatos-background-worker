using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinisterioAtos.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController(IStorageService storageService) : ControllerBase
    {
        private readonly IStorageService _storageService = storageService;

        [HttpGet("{id}")]
        public async Task<IActionResult> getResourceUrl([FromRoute] string id)
        {
            var data = await _storageService.GetResourceById(id);
            return Ok(data);
        }

        [HttpGet("getFile/{value}")]
        public async Task<IActionResult> getFile([FromRoute] string value)
        {
            await _storageService.DownloadResouceById(value);
            return Accepted("verique o /Resources");
        }
    }
}
