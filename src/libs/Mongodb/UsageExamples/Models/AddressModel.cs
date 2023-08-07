using MongoDB.Bson.Serialization.Attributes;

namespace Mongodb.UsageExamples.Models;

public class AddressModel
{
    public string Building { get; set; } = null!;

    public double[] Coordinates { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string ZipCode { get; set; } = null!;
}