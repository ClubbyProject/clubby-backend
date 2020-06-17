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
    [Route("api/event")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ClubbyContext _context;

        public EventsController(ClubbyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventList()
        {
            return await _context.Event.OrderByDescending(x => x.StartTime)
                                       .ToListAsync();
        }

        [HttpGet("{month}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventListByMonthx(int month)
        {
            return await _context.Event.Where(x => (x.StartTime.Value.Month == month || x.EndTime.Value.Month == month))
                                       .OrderByDescending(x => x.StartTime)
                                       .ToListAsync();
        }
    }
}