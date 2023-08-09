namespace Mongodb.RestaurantStore.Models;

public class AddressModel
{
    public Guid AddressId { get; set; } = new Guid();

    public string Building { get; set; } = null!;

    public double[] Coordinates { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string ZipCode { get; set; } = null!;
}