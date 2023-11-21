using Microsoft.AspNetCore.Mvc;
using MiniIO.Applcation.Interfaces;

namespace MiniIO.Host.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class MinIOController : ControllerBase
{
    private readonly ILogger<MinIOController> _logger;
    private readonly IMinIOService _minIOService;

    public MinIOController(
        ILogger<MinIOController> logger,
        IMinIOService minIOService
    )
    {
        _logger = logger;
        _minIOService = minIOService;
    }

    [HttpPost("UploadFileAsync")]
    public async Task<IActionResult> UploadFileAsync(IEnumerable<IFormFile> files){
        await _minIOService.UploadFilesAsync(files);
        return Ok("Upload success");
    }
}