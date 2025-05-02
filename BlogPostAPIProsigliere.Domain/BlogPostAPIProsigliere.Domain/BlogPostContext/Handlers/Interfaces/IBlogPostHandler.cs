using BlogPostAPIProsigliere.Domain.BlogContext.Entities;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.Inputs;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.OutPuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostAPIProsigliere.Domain.BlogPostContext.Handlers.Interfaces
{
    public interface IBlogPostHandler
    {
        IEnumerable<GetBlogPostResult> GetAll();
        BlogPost GetById(int id);
        BlogPost Add(CreateBlogPostCommand post);
        Comment AddComment(int postId, CreateCommentCommand comment);
        bool Delete(int id);
    }
}
