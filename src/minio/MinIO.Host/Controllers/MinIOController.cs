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
    public async Task<ActionResult<PutObjectResponse>> UploadFileAsync(IFormFile file){
        var result = await _minIOService.UploadFilesAsync(file);
        return Ok(result);
    }

    [HttpGet("DownloadFileAsync/{fileName}")]
    public async Task<ActionResult<FileDto>> DownloadFileAsync(string fileName){
        var result = await _minIOService.DownloadFileAsync(fileName);
        return Ok(result);
    }
    
    [HttpGet("GetMetadataAsync/{fileName}")]
    public async Task<ActionResult<ObjectStat>> GetMetadataAsync(string fileName){
        var result = await _minIOService.GetMetadataAsync(fileName);
        return Ok(result);
    }

        [HttpGet("GetListsAsync/{bucketName}")]
    public async Task<ActionResult<FileDto>> GetListsAsync(string bucketName){
        var result = await _minIOService.GetListsAsync(bucketName);
        return Ok(result);
    }
}