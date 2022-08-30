using Candor.UseCases.Blog.CreatePost;
using Candor.UseCases.Blog.FindPostById;
using Candor.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Candor.UnitTests;

public class Tests
{
    public TestDatabaseFixture Fixture { get; set; }

    [SetUp]
    public void Setup()
    {
        Fixture = new TestDatabaseFixture();
    }

    //[Test]
    //public void FindPostByIdQuery_ValidId_ReturnNotNull()
    //{
    //    // Arrange
    //    const int wrongId = 1000;

    //    var mediator = new Mock<IMediator>();
    //    var query = new FindPostByIdQuery(wrongId);
    //    var logger = new Mock<ILogger<FindPostByIdQueryHandler>>();
    //    using var context = Fixture.CreateContext();
    //    var handler = new FindPostByIdQueryHandler(logger.Object, context);

    //    var controller = new BlogController(mediator.Object);



    //    // Act
    //    var result = controller.PostAsync(1000, CancellationToken.None).Result;

    //    // Assert
    //    Assert.That(result, Is.TypeOf<NotFoundResult>());
    //}

    [Test]
    public void CreatePostCommand_Create_Success()
    {
        // Arrange
        //var logger = new Mock<ILogger<CreatePostCommandHandler>>();
        //using var context = Fixture.CreateContext();

        //var command = new CreatePostCommand();
        //var handler = new CreatePostCommandHandler(logger.Object, context);
        var mediator = new Mock<IMediator>();
        var command = new CreatePostCommand
        {
            Title = "Test",
            Content = "TestContent",
            UserId = "16c784d5-e202-416c-9016-9c3cb0a39343"
        };

        var controller = new BlogController(mediator.Object);

        // Act
        var result = controller.CreatePostAsync(command, CancellationToken.None).Result;

        // Assert
        Assert.That(result, Is.TypeOf<RedirectToActionResult>());
    }
}