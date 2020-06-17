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
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ClubbyContext _context;

        public SearchController(ClubbyContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Search([FromQuery]string str)
        {
            return await _context.Event.OrderByDescending(x => x.StartTime)
                                       .ToListAsync();
        }
    }
}