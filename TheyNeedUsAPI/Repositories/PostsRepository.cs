using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheyNeedUsAPI.Contracts;
using TheyNeedUsAPI.Models;

namespace TheyNeedUsAPI.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly TheyNeedUsAPIContext _context;
        public PostsRepository(TheyNeedUsAPIContext context)
        {
            _context = context;
        }
        public async Task<bool> Exits(int id)
        {
            return await _context.Posts.AnyAsync(p => p.Id == id);
        }

        public async Task<Posts> FindPost(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public IEnumerable<Posts> GetAllPosts()
        {
            return _context.Posts;
        }

        public async Task<Posts> Register(Posts posts)
        {
            await _context.Posts.AddAsync(posts);
            await _context.SaveChangesAsync();
            return posts;
        }

        public async Task<Posts> RemovePost(int id)
        {
            var post = await _context.Posts.SingleAsync(p => p.Id == id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Posts> UpdatePost(Posts posts)
        {
            _context.Posts.Update(posts);
          await  _context.SaveChangesAsync();
            return posts;
        }
    }
}
