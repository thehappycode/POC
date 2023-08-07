using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongodb.UsageExamples.Models;

public class RestaurantModel
{
    public ObjectId Id { get; set; }

    public string Name { get; set; } = null!;

    public string RestaurantId { get; set; } = null!;

    public string Cuisine { get; set; } = null!;

    public AddressModel Address { get; set; } = null!;

    public string Borough { get; set; } = null!;

    public List<GradeModel> Grades { get; set; } = null!;
}