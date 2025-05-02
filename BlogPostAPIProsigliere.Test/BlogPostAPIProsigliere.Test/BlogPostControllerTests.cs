using BlogPostAPIProsigliere.Controllers;
using BlogPostAPIProsigliere.Domain.BlogContext.Entities;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.OutPuts;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Entities;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BlogPostAPIProsigliere.Test
{
    public class BlogPostControllerTests
    {

        private readonly Mock<IBlogPostHandler> _mockBlogPostHandler;
        private readonly Mock<ILogger<BlogPostsController>> _mockLogger;
        private readonly BlogPostsController _controller;
        public BlogPostControllerTests()
        {
            _mockBlogPostHandler = new Mock<IBlogPostHandler>();
            _mockLogger = new Mock<ILogger<BlogPostsController>>();
            _controller = new BlogPostsController(_mockLogger.Object, _mockBlogPostHandler.Object);      
        }

        [Fact]
        public void GetAll_WhenExceptionThrown_ShouldReturn500StatusCode()
        {
            // Arrange
            _mockBlogPostHandler
                .Setup(h => h.GetAll())
                .Throws(new Exception("Test exception"));

            // Act
            var result = _controller.GetAll();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var errorResponse = Assert.IsType<ErrorResponse>(statusCodeResult.Value);
            Assert.Equal("An error occurred while processing your request.", errorResponse.Message);

            // Verify that the logger was called
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);
        }

        [Fact]
        public void GetAll_WhenOneOrMorePostsExist_ShouldReturnPostsWithOkResult()
        {
            // Arrange
            var expectedPosts = new List<GetBlogPostResult>
            {
                new GetBlogPostResult
                {
                    Id = 1,
                    Title = "Test Post",
                    QuantityOfComments = 5
                }
            };

            _mockBlogPostHandler
                .Setup(h => h.GetAll())
                .Returns(expectedPosts);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);

            var returnedPosts = Assert.IsAssignableFrom<IEnumerable<GetBlogPostResult>>(okResult.Value);
            Assert.Single(returnedPosts);

            var post = returnedPosts.First();
            Assert.Equal(1, post.Id);
            Assert.Equal("Test Post", post.Title);
            Assert.Equal(5, post.QuantityOfComments);
        }
    }
}