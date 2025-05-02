using BlogPostAPIProsigliere.Domain.BlogContext.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.OutPuts
{
    public class GetBlogPostResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuantityOfComments { get; set; }

        public GetBlogPostResult()
        {
            
        }
        public GetBlogPostResult(BlogPost post)
    {
        Id = post.Id;
        Title = post.Title;
        QuantityOfComments = post.Comments.Count;
    }
    }
}
