using BlogPostAPIProsigliere.Domain.BlogContext.Entities;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.Inputs;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.OutPuts;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Entities;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Annotations;
using System.Xml.Linq;

namespace BlogPostAPIProsigliere.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostHandler _blogPostHandler;
        private readonly ILogger<BlogPostsController> _logger;

        public BlogPostsController(ILogger<BlogPostsController> logger, IBlogPostHandler blogPostHandler)
        {
            _logger = logger;
            _blogPostHandler = blogPostHandler;
        }

       

        [HttpGet("posts")]
        #region SWAGGER
        [SwaggerOperation(
           Summary = "Gets all blog posts",
           Description = "Retrieves a complete list of all available blog posts with their comment counts",
           OperationId = "GetAllBlogPosts",
           Tags = new[] { "GetAll" }
        )]
        [SwaggerResponse(200, "Successfully retrieved blog posts", typeof(IEnumerable<GetBlogPostResult>))]
        [SwaggerResponse(500, "Internal server error occurred", typeof(ErrorResponse))]
        #endregion SWAGGER
        public IActionResult GetAll()
        {
            try
            {
                var result = _blogPostHandler.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error ocurred while retrieving all posts");
                return StatusCode(500, new ErrorResponse("An error occurred while processing your request."));
            }
        }

        [HttpGet("posts/{id}")]
        #region SWAGGER
        [SwaggerOperation(
           Summary = "Gets blog posts by ID",
           Description = "Retrieves a specific blog post by its ID, including its title, content, and associated comments.",
           OperationId = "GetBlogPostbyId",
           Tags = new[] { "GetBlogPostbyId" }
        )]
        [SwaggerResponse(200, "Successfully retrieved blog post", typeof(IEnumerable<GetBlogPostResult>))]
        [SwaggerResponse(204, "Blog Post Not Found")]
        [SwaggerResponse(500, "Internal server error occurred", typeof(ErrorResponse))]
        #endregion SWAGGER
        public IActionResult GetBlogPostbyId(int id)
        {
            try
            {
                var result = _blogPostHandler.GetById(id);
                if (result == null)
                {
                    return NotFound("BlogPost Not Found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error ocurred while retrieving blog post by Id");
                return StatusCode(500, new ErrorResponse("An error occurred while processing your request."));
            }
        }

        [HttpPost("posts")]
        #region SWAGGER
        [SwaggerOperation(
          Summary = "Creates a new blog post",
          Description = "Creates a new blog post.",
          OperationId = "PostBlogPost",
          Tags = new[] { "PostBlogPost" }
       )]
        [SwaggerResponse(201, "Created blog post", typeof(GetBlogPostResult))]
        [SwaggerResponse(400, "Client Error Bad Request")]
        [SwaggerResponse(500, "Internal server error occurred", typeof(ErrorResponse))]
        #endregion SWAGGER
        public IActionResult Post([FromBody] CreateBlogPostCommand post)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newPost = _blogPostHandler.Add(post);
                return CreatedAtAction(nameof(GetBlogPostbyId), new { id = newPost.Id }, newPost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error ocurred");
                return StatusCode(500, new ErrorResponse("An error occurred while processing your request."));
            }
        }

        [HttpPost("posts/{id}/comments")]
        #region SWAGGER
        [SwaggerOperation(
      Summary = "Creates a new blog post comment",
      Description = "Creates a new blog post comment.",
      OperationId = "PostBlogPostComment",
      Tags = new[] { "PostBlogPostComment" }
   )]
        [SwaggerResponse(201, "Created blog post comment", typeof(Comment))]
        [SwaggerResponse(400, "Client Error Bad Request")]
        [SwaggerResponse(500, "Internal server error occurred", typeof(ErrorResponse))]
        #endregion SWAGGER
        public IActionResult PostComment(int id, [FromBody] CreateCommentCommand post)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newComment = _blogPostHandler.AddComment(id, post);
                if (newComment == null)
                {
                    return NotFound("Blog Post Not Found");
                }
                return CreatedAtAction(nameof(GetBlogPostbyId), new { id = newComment.BlogPostId }, newComment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error ocurred while retrieving blog post by Id");
                return StatusCode(500, new ErrorResponse("An error occurred while processing your request."));
            }
        }


        [HttpDelete("posts/{id}")]
        #region SWAGGER
        [SwaggerOperation(
     Summary = "Delete a blog post",
     Description = "Delete a blog post.",
     OperationId = "DeleteBlogPost",
     Tags = new[] { "DeleteBlogPost" }
  )]
        [SwaggerResponse(204, "Sucessfully Deleted")]
        [SwaggerResponse(404, "No Content Found")]
        [SwaggerResponse(500, "Internal server error occurred", typeof(ErrorResponse))]
        #endregion SWAGGER
        public IActionResult Delete(int id)
        {
            try
            {
              
                if (_blogPostHandler.Delete(id))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error ocurred while trying to delete a Blog Post");
                return StatusCode(500, new ErrorResponse("An error occurred while processing your request."));
            }
        }


    }
}
