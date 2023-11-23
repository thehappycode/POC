using Microsoft.AspNetCore.Http;
using MiniIO.Applcation.Dtos;
using Minio.DataModel;
using Minio.DataModel.Response;

namespace MiniIO.Applcation.Interfaces;

public interface IMinIOService
{
    Task<PutObjectResponse> UploadFilesAsync(IFormFile file);

    Task<FileDto> DownloadFileAsync(string pathName);

    Task<ObjectStat> GetMetadataAsync(string pathName);
}