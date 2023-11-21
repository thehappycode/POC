using System.Runtime.Serialization.Formatters;
using Microsoft.AspNetCore.Http;

namespace MiniIO.Applcation.Interfaces;

public interface IMinIOService
{
    Task UploadFilesAsync(IEnumerable<IFormFile> files);
}