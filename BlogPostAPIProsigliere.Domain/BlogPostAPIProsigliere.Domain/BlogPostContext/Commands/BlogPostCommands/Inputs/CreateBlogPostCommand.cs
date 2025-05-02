using BlogPostAPIProsigliere.Domain.BlogContext.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.Inputs
{
    public class CreateBlogPostCommand
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }
 
    }
}
