using Microsoft.AspNetCore.Mvc;
using MiniIO.Applcation.Dtos;
using MiniIO.Applcation.Interfaces;
using Minio.DataModel;
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
    public async Task<IActionResult> UploadFileAsync(IFormFile file)
    {
        var result = await _minIOService.UploadFilesAsync(file);
        return Ok(result);
    }

    [HttpGet("DownloadFileAsync/{fileName}")]
    public async Task<IActionResult> DownloadFileAsync(string fileName)
    {
        var result = await _minIOService.DownloadFileAsync(fileName);
        return Ok(result);
    }

    [HttpGet("GetMetadataAsync/{fileName}")]
    public async Task<IActionResult> GetMetadataAsync(string fileName)
    {
        var result = await _minIOService.GetMetadataAsync(fileName);
        return Ok(result);
    }

    [HttpGet("GetListsAsync/{bucketName}")]
    public async Task<IActionResult> GetListsAsync(string bucketName)
    {
        var result = await _minIOService.GetListsAsync(bucketName);
        return Ok(result);
    }

    [HttpDelete("DeleteFileAsync/{fileName}")]
    public async Task<IActionResult> DeleteFileAsync(string fileName)
    {
        await _minIOService.DeleteFileAsync(fileName);
        return NoContent();
    }
}