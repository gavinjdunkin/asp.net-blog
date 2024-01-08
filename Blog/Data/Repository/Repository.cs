using System;
using System.Linq;
using Blog.Models;
using Microsoft.Extensions.Hosting;

namespace Blog.Data.Repository
{
    public class Repository : IRepository
    {
        private BlogDbContext _ctx;

        public Repository(BlogDbContext context)
        {
            _ctx = context;
        }

        public void AddPost(Post post)
        {
            _ctx.Post.Add(post);
        }

        public List<Post> GetAllPosts()
        {
            return _ctx.Post.ToList();
        }

        public Post GetPost(int id)
        {
            return _ctx.Post.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            _ctx.Post.Remove(GetPost(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _ctx.SaveChangesAsync() > 0;
        }

        public void UpdatePost(Post post)
        {
            _ctx.Post.Update(post);
        }
    }
}

