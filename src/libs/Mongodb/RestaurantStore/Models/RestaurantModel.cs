using MongoDB.Bson;

namespace Mongodb.RestaurantStore.Models;

public class RestaurantModel
{
    public ObjectId Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid RestaurantId { get; set; } = Guid.NewGuid();

    public string Cuisine { get; set; } = null!;

    public AddressModel Address { get; set; } = null!;

    public string Borough { get; set; } = null!;

    public List<GradeModel> Grades { get; set; } = null!;
}