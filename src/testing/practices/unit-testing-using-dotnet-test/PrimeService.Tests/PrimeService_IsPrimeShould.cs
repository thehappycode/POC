using Prime.Services;

namespace Prime.Service.Tests;

public class PrimeService_IsPrimeShould
{
    private readonly PrimeService _primeService;

    public PrimeService_IsPrimeShould()
    {
        _primeService = new PrimeService();
    }
    [Fact]
    public void IsPrime_InputIs1_ReturnFalse()
    {
        var primeService = new PrimeService();
        var result = primeService.IsPrime(1);

        Assert.False(result, "1 should not be prime");
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
    {
        var result = _primeService.IsPrime(value);

        Assert.False(result, $"{value} should not be prime");
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(7)]
    public void IsPrime_ValuesLessThan10_ReturnTrue(int value)
    {
        var result = _primeService.IsPrime(value);

        Assert.True(result, $"{value} should be prime");
    }
}