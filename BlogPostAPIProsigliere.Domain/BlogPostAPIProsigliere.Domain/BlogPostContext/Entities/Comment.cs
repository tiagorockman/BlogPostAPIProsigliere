using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostAPIProsigliere.Domain.BlogContext.Entities
{
    public class Comment
    {

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; private set; }

        [Required(ErrorMessage = "Comment text is required.")]
        public string Text { get; private set; }
        public int BlogPostId { get; private set; }

        public Comment(string author, string text)
        {
            Author = author;
            Text = text;
        }

        public void SetBlogPostId(int postId)
        {
            BlogPostId = postId;
        }
    }
}
