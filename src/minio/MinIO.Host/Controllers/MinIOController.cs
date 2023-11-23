using Microsoft.AspNetCore.Mvc;
using MiniIO.Applcation.Dtos;
using MiniIO.Applcation.Interfaces;
using Minio.DataModel.Response;

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
    public async Task<ActionResult<PutObjectResponse>> UploadFileAsync(IFormFile file){
        var result = await _minIOService.UploadFilesAsync(file);
        return Ok(result);
    }

    [HttpGet("DownloadFileAsync/{pathName}")]
    public async Task<ActionResult<FileDto>> DownloadFileAsync(string pathName){
        var result = await _minIOService.DownloadFileAsync(pathName);
        return Ok(result);
    }
}