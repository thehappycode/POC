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

    public async Task UploadFilesAsync(IEnumerable<IFormFile> files)
    {
        try
        {


            foreach (var file in files)
            {

                var octetStream = MinIOContentType.OctetStream.ToString();
                Console.WriteLine($"Octet-Stream: {octetStream}");
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    Console.WriteLine($"MinIO Length: {memoryStream.Length}");
                    var putObjectArgs = new PutObjectArgs()
                        .WithBucket(_minIOOptions.Bucket)
                        .WithObject(file.FileName)
                        // .WithFileName(file.FileName)
                        .WithStreamData(memoryStream)
                        .WithObjectSize(memoryStream.Length)
                        .WithContentType("application/octet-stream");

                    await _minioClient
                        .PutObjectAsync(putObjectArgs)
                        .ConfigureAwait(false);
                }
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Exceptions: {ex.Message}");
        }
    }
}