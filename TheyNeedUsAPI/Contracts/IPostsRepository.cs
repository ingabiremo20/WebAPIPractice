using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheyNeedUsAPI.Models;

namespace TheyNeedUsAPI.Contracts
{
    public interface IPostsRepository
    {
        Task<Posts> Register(Posts posts);
        IEnumerable<Posts> GetAllPosts();
        Task<Posts> FindPost(int id);
        Task<Posts> UpdatePost(Posts posts);
        Task<Posts> RemovePost(int id);
        Task<bool> Exits(int id);
            
    }
}
