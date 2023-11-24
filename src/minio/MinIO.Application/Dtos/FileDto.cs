namespace MiniIO.Applcation.Dtos;

public class FileDto
{
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] Bytes { get; set; }
    public string Base64 { get; set; }

    public FileDto()
    {

    }

    public FileDto(string fileName, string contentType, byte[] bytes)
    {
        FileName = fileName;
        ContentType = contentType;
        Bytes = bytes;
        // Base64 = Convert.ToBase64String(bytes);
    }

    private string GetBase64()
    {
        if (!string.IsNullOrWhiteSpace(Base64))
            return Base64;

        if (Bytes.Length == 0)
            return "Bytes empty";

        Base64 = Convert.ToBase64String(Bytes);

        return Base64;
    }
}