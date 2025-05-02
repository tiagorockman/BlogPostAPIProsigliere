using BlogPostAPIProsigliere.Domain.BlogContext.Entities;
using BlogPostAPIProsigliere.Domain.BlogContext.Repositories;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.Inputs;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.OutPuts;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostAPIProsigliere.Domain.BlogPostContext.Handlers
{
    public class BlogPostHandler : IBlogPostHandler
    {
        private readonly IBlogPostRepository _blogPostRepository;
        public BlogPostHandler(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }
        public BlogPost Add(CreateBlogPostCommand post)
        {
            var blogPost = new BlogPost(post);
            return _blogPostRepository.Add(blogPost);
        }

        public Comment AddComment(int postId, CreateCommentCommand command)
        {
            var comment = new Comment(command.Author, command.Text);
            return _blogPostRepository.AddComment(postId, comment);
        }

        public bool Delete(int id)
        {
           return _blogPostRepository.Delete(id);
        }

        public IEnumerable<GetBlogPostResult> GetAll()
        {
            var posts = _blogPostRepository.GetAll();
            //Transform the posts and return the result
            var result = posts.Select(p => new GetBlogPostResult(p));

            return result;
        }

        public BlogPost GetById(int id)
        {
            return _blogPostRepository.GetById(id);
        }
    }
}
