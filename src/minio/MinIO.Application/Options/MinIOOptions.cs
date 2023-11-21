namespace minio.Options;

public class MinIOOptions
{
    public string Endpoint { get; set; }
    public string AccessKey { get; set; }
    public string SecretKey { get; set; }
    public bool Secure { get; set; }
    public string Bucket { get; set; }
}