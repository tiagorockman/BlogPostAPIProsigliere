using BlogPostAPIProsigliere.Domain.BlogContext.Entities;
using BlogPostAPIProsigliere.Domain.BlogContext.Repositories;
using BlogPostAPIProsigliere.Domain.BlogPostContext.Commands.BlogPostCommands.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogPostAPIProsigliere.Infra.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private static readonly List<BlogPost> _posts = new List<BlogPost>(); // In-memory storage
        private static int _nextPostId = 1;

        public BlogPostRepository()
        {
            //Load Data when code runs
            BlogDataStore();
        }

        private void BlogDataStore()
        {
            _posts.Add(new BlogPost(
                     id: 1,
                     title: "Welcome to the Blog",
                     content: "This is the first blog post introducing the site.",
                     comments: new List<Comment>
                     {
                        new Comment(author: "Alice", text: "Great intro!"),
                        new Comment(author: "Bob", text: "Looking forward to more content.")
                     }
                 ));

            _posts.Add(new BlogPost(
                id: 2,
                title: "Understanding ASP.NET Core",
                content: "A beginner’s guide to building web apps with ASP.NET Core.",
                comments: new List<Comment>
                {
                new Comment(author: "Carol", text: "Very helpful, thanks!"),
                new Comment(author: "Dave", text: "Could you add more on middleware?"),
                new Comment(author: "Eve", text: "This clarified a lot for me.")
                        }
                    ));

            _posts.Add(new BlogPost(
                id: 3,
                title: "How to Use Entity Framework",
                content: "Learn how to connect your models to a database using EF Core.",
                comments: new List<Comment>()
            ));

            _posts.Add(new BlogPost(
                id: 4,
                title: "Deploying Your App to Azure",
                content: "Step-by-step tutorial on deploying ASP.NET Core apps to Azure App Service.",
                comments: new List<Comment>
                {
                new Comment(author: "Frank", text: "Deployment was easier than I thought!")
                        }
                    ));

            _posts.Add(new BlogPost(
                id: 5,
                title: "Performance Tips for .NET Applications",
                content: "Optimize your .NET apps with these performance tips.",
                comments: new List<Comment>
                {
                new Comment(author: "Grace", text: "Nice tips!"),
                new Comment(author: "Henry", text: "Caching really helps."),
                new Comment(author: "Ivan", text: "Great explanation of async processing."),
                new Comment(author: "Jane", text: "I’ll try these in my project.")
                        }
                    ));
            _nextPostId = 6;

        }

        public IEnumerable<BlogPost> GetAll()
        {
            return _posts;
        }

        public BlogPost GetById(int id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public BlogPost Add(BlogPost post)
        {
            post.setID(_nextPostId++);
            _posts.Add(post);
            return post;
        }

        public Comment AddComment(int postId, Comment comment)
        {
            var blogPost = GetById(postId);
            if (blogPost == null)
            {
                return null; // Post not found
            }

            comment.SetBlogPostId(postId);
            blogPost.Comments.Add(comment);
            return comment;
        }

        public bool Delete(int id)
        {
            var postToRemove = _posts.FirstOrDefault(p => p.Id == id);
            if (postToRemove == null)
            {
                return false;
            }
            return _posts.Remove(postToRemove);
        }
    }
}
