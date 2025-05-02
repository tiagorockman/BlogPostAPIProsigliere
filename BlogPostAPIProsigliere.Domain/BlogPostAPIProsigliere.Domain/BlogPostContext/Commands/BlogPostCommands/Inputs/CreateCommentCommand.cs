using System.ComponentModel.DataAnnotations;

namespace BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.Inputs
{
    public class CreateCommentCommand
    {
        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Comment text is required.")]
        public string Text { get; set; }
    }
}
