using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Webapplication2;
public class CheckoutControllerTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;

    public CheckoutControllerTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_ReturnsBadRequestResult_WhenInputStringIsEmpty()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/checkout");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Get_ReturnsBadRequestResult_WhenInputStringContainsInvalidItems()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/checkout/ABCD1");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Get_ReturnsCorrectTotal_WhenInputStringContainsValidItems()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/checkout/ABCD");
        var total = int.Parse((await response.Content.ReadAsStringAsync()));

        // Assert
        Assert.Equal(160, total);
    }

    [Fact]
    public async Task Get_AppliesOffersCorrectly_WhenInputStringContainsMultipleOffers()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/checkout/AAAABBBCD");
        var total = int.Parse((await response.Content.ReadAsStringAsync()));

        // Assert
        Assert.Equal(230, total);
    }

    [Fact]
    public async Task Get_AppliesOffersCorrectly_WhenInputStringContainsFewerThan3Items()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/checkout/ABCD");
        var total = int.Parse((await response.Content.ReadAsStringAsync()));

        // Assert
        Assert.Equal(160, total);
    }
}
