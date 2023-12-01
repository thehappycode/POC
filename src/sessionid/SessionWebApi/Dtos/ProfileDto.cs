namespace SessionWebApi.Dtos;

public class ProfileDto
{
    public string? FullName { get; set; }
    public ushort Age { get; set; }
    public DateTime Birthday { get; set; }
}