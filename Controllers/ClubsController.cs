using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clubby.Models;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Caching.Memory;
using System.Text.RegularExpressions;

namespace Clubby.Controllers
{
    [Route("api/club")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly ClubbyContext _context;
        private readonly IMemoryCache _cache;
        public ClubsController(ClubbyContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubList()
        {
            return await _context.Club.ToListAsync();
        }
        [HttpGet("{ClubId}/post")]
        public async Task<ActionResult<IEnumerable<Club>>> GetPost(int ClubId)
        {
            return await _context.Club.Where(x => x.Id == ClubId)
                                      .Include(x => x.Post)
                                      .ToListAsync();
        }


        [HttpPost("{ClubId}/post")]
        public async Task<ActionResult<int>> AddPost([FromBody] PostContext context, int ClubId)
        {
            StringValues token;
            if (!Request.Headers.TryGetValue("Authorization", out token))
                return Unauthorized();

            int userid;
            if (!_cache.TryGetValue(token.ToString(), out userid))
                return Unauthorized();

            if (!_context.Admin.Any(x => x.UserId == userid && x.ClubId == ClubId))
                return Forbid("why?");

            await _context.Post.AddAsync(new Post()
            {
                ClubId = ClubId,
                EventId = null,
                Title = context.Title,
                Context = context.Content,
                ImageList = context.ImageList,
                CreateBy = userid
            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class PostContext
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageList { get; set; }
    }
}