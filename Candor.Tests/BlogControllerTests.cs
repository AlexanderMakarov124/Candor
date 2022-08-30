using Candor.IntegrationTests.Utility;
using Candor.Web;

namespace Candor.IntegrationTests;

public class BlogControllerTests : IClassFixture<TestingWebAppFactory<Program>>
{
    private readonly TestingWebAppFactory<Program> factory;
    public BlogControllerTests(TestingWebAppFactory<Program> factory)
    {
        this.factory = factory;
    }

    [Theory]
    [InlineData("/")]
    [InlineData("/Login")]
    [InlineData("/Registration")]
    [InlineData("/Post/1")]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType!.ToString());
    }
}