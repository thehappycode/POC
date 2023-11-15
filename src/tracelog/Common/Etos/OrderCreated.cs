namespace Common.Etos;

public record OrderCreateEto(
    long Id,
     string ProductName,
     decimal Price,
     int Quantity
);