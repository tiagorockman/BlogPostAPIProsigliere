using BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.Inputs;
using System.ComponentModel.DataAnnotations;
namespace BlogPostAPIProsigliere.Domain.BlogContext.Entities
{
    public class BlogPost
    {

        public BlogPost(int id, string title, string content, List<Comment> comments)
        {
            Id = id;
            Title = title;
            Content = content;
            Comments = comments;
        }

        public BlogPost(CreateBlogPostCommand command)
        {
            Title = command.Title;
            Content = command.Content;
        }

        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; private set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; private set; }

        public List<Comment> Comments { get; private set; } = new List<Comment>();

        public void setID(int id)
        {
            Id=id;
        }
    }
}

