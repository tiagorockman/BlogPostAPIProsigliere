using BlogPostAPIProsigliere.Domain.BlogContext.Entities;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.Inputs;

namespace BlogPostAPIProsigliere.Domain.BlogContext.Repositories
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetAll();
        BlogPost GetById(int id);
        BlogPost Add(BlogPost post);
        Comment AddComment(int postId, Comment comment);
        bool Delete(int id);
    }
}
