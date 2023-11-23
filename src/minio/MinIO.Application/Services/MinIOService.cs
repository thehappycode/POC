using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MiniIO.Applcation.Dtos;
using MiniIO.Applcation.Interfaces;
using minio.Options;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.DataModel.Response;
using Newtonsoft.Json;

namespace MiniIO.Applcation.Services;

public class MinIOService : IMinIOService
{
    private readonly IMinioClient _minioClient;
    private readonly MinIOOptions _minIOOptions;

    public MinIOService(
        IOptions<MinIOOptions> minIOOptions,
        IMinioClient minioClient
    )
    {
        _minioClient = minioClient;

        Console.WriteLine($"MiIOOptions: {JsonConvert.SerializeObject(minIOOptions.Value)}");
        _minIOOptions = minIOOptions.Value;
    }

    public async Task<bool> CheckBucketExistsAsync()
    {
        try
        {
            // Make a bucket on the server, if not already present.
            var bucketExistsArgs = new BucketExistsArgs()
                    .WithBucket(_minIOOptions.Bucket);
            var isExisting = await _minioClient.BucketExistsAsync(bucketExistsArgs).ConfigureAwait(false);
            Console.WriteLine($"Bucket {_minIOOptions.Bucket} is existing");

            return isExisting;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"CheckBucketExistsAsync.Exception: {ex.Message}");
            throw;
        }

    }

    public async Task<PutObjectResponse> UploadFilesAsync(IFormFile file)
    {
        await CheckBucketExistsAsync();
        var now = DateTime.Now;
        try
        {
            var octetStream = MinIOContentType.OctetStream.ToString();
            Console.WriteLine($"Octet-Stream: {octetStream}");
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                Console.WriteLine($"MinIO Length: {memoryStream.Length}");
                var putObjectArgs = new PutObjectArgs()
                    .WithBucket(_minIOOptions.Bucket)
                    .WithObject($"{now.Year}/{now.Month}/{now.Day}/{Guid.NewGuid()}-{file.FileName}")
                    .WithStreamData(memoryStream)
                    .WithObjectSize(memoryStream.Length)
                    .WithContentType("application/octet-stream");

                var result = await _minioClient
                    .PutObjectAsync(putObjectArgs)
                    .ConfigureAwait(false);

                return result;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"UploadFilesAsync.Exception: {ex.Message}");
            throw;
        }
    }

    public async Task<FileDto> DownloadFileAsync(string fileName)
    {
        fileName = "2023/11/21/3e504a73-b658-4fcc-b1ef-065d60bb2804-minio.png";
        Console.WriteLine($"DownloadFileAsync.PathName: {fileName}");
        await CheckBucketExistsAsync();
        var metadata = await GetMetadataAsync(fileName);
        try
        {
            using (var memoryStream = new MemoryStream())
            {

                var getObjectArgs = new GetObjectArgs()
                    .WithBucket(_minIOOptions.Bucket)
                    .WithObject(fileName)
                    .WithCallbackStream(stream =>
                    {
                        stream.CopyToAsync(memoryStream);
                    });
                // memoryStream.Seek(0, SeekOrigin.Begin);

                var objState = await _minioClient.GetObjectAsync(getObjectArgs);
                Console.WriteLine($"DownloadFileAsync.MemoryStream: {memoryStream.Length}");

                var result = new FileDto(objState.ObjectName, objState.ContentType, memoryStream.ToArray());

                return result;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"DownloadFileAsync.Exception: {ex.Message}");
            throw;
        }
    }

    public async Task<ObjectStat> GetMetadataAsync(string pathName)
    {
        try
        {
            var stateObjectArgs = new StatObjectArgs()
                .WithBucket(_minIOOptions.Bucket)
                .WithObject(pathName);

            var result = await _minioClient.StatObjectAsync(stateObjectArgs);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetMetadataAsync.Exception: {ex.Message}");
            throw;
        }
    }
}