using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MiniIO.Applcation.Interfaces;
using minio.Options;
using Minio;
using Minio.DataModel.Args;
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
    public async Task UploadFilesAsync(IEnumerable<IFormFile> files)
    {
        await CheckBucketExistsAsync();
        var now = DateTime.Now;
        try
        {
            foreach (var file in files)
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

                    await _minioClient
                        .PutObjectAsync(putObjectArgs)
                        .ConfigureAwait(false);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"UploadFilesAsync.Exception: {ex.Message}");
        }
    }
}