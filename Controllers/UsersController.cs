using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clubby.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Clubby.Controllers
{
    [Route("api/user/{id}")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ClubbyContext _context;
        private readonly IMemoryCache _cache;
        public UsersController(ClubbyContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet("club")]
        public async Task<ActionResult<IEnumerable<UserInClub>>> GetUserClub(int id)
        {
            StringValues token;
            if (!Request.Headers.TryGetValue("Authorization", out token))
            {
                Console.WriteLine("no header");
                return Unauthorized();
            }
            int userid;
            if (!_cache.TryGetValue(token.ToString(), out userid))
            {
                Console.WriteLine("no cache");
                return Unauthorized();
            }
            return await _context.UserInClub.Where(x => x.UserId == userid)
                                            .Include(x => x.Club)
                                            .ToListAsync();
        }
    }
}
