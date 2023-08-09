namespace Mongodb.RestaurantStore.Models;

public class GradeModel 
{
    public Guid GradeId { get; set; } = new Guid();
    public string Grade { get; set; } = null!;
    public float Score { get; set; }
    public DateTime Date { get; set; }
}