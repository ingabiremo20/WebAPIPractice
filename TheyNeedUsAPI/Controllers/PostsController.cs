using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheyNeedUsAPI.Contracts;
using TheyNeedUsAPI.Models;

namespace TheyNeedUsAPI.Controllers
{

  // [EnableCors()]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PostsController : ControllerBase
    {
      
        private readonly IPostsRepository _postsRepository;

        public PostsController(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }
      

        // GET: api/Posts
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Getposts()
        {

            var results = new ObjectResult(_postsRepository.GetAllPosts())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("x-Total-Count", _postsRepository.GetAllPosts().Count().ToString());
            return results;
        }

        // GET: api/Posts/5
    
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Posts>> GetPosts(int id)
        {
            try
            {
                if (await PostsExists(id))
                {
                    var posts = await _postsRepository.FindPost(id);

                    if (posts == null)
                    {
                        return BadRequest("Failed To get data");
                    }

                    return posts;
                }
                else
                {
                    return BadRequest("Failed To get data");
                }
            }
            catch (Exception ex)
            {

                return BadRequest("Failed To get data");

            }
            
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosts(int id, Posts posts)
        {
            if (id != posts.Id)
            {
                return BadRequest();
            }         

            try
            {
                await _postsRepository.UpdatePost(posts);
                return Ok(posts);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PostsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

          
        }

        // POST: api/Posts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Posts>> PostPosts(Posts posts)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _postsRepository.Register(posts);

                return CreatedAtAction("GetPosts", new { id = posts.Id }, posts);
            }
            catch (Exception)
            {

                return BadRequest("Failed to save"); 
            }
           
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Posts>> DeletePosts(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!await PostsExists(id))
                {
                    return NotFound();
                }

                await _postsRepository.RemovePost(id);

                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Something wrong");
            }
        }

        private async Task<bool> PostsExists(int id)
        {
            return await _postsRepository.Exits(id);
        }
    }
}
