using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clubby.Models;

namespace Clubby.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ClubbyContext _context;

        public PostsController(ClubbyContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostList()
        {
            return await _context.Post.OrderByDescending(x => x.CreateAt)
                                      .Take(100)
                                      .ToListAsync();
        }
    }
}