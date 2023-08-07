namespace Mongodb.UsageExamples.Models;

public class GradeModel 
{
    public DateTime Date { get; set; }
    public string Grade { get; set; } = null!;
    public float Score { get; set; }
}