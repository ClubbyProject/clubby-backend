using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clubby.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Google.Apis.Auth;
using Microsoft.Extensions.Caching.Memory;

namespace Clubby.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ClubbyContext _context;
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        private readonly IMemoryCache _cache;

        public AuthController(ClubbyContext context, ILogger<AuthController> logger, IConfiguration config, IMemoryCache cache)
        {
            _context = context;
            _logger = logger;
            _config = config;
            _cache = cache;
        }


        [HttpPost]
        public async Task<ActionResult<string>> AuthCheck([FromBody] AuthCodeRequest request)
        {
            var token = request.Code;
            GoogleJsonWebSignature.Payload payload;
            try
            {
                payload = await GoogleJsonWebSignature.ValidateAsync(token, new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _config.GetValue<string>("OAuth:ClientID") },
                    HostedDomain = "gemail.yuntech.edu.tw"
                });
            }
            catch (Google.Apis.Auth.InvalidJwtException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Invalid token");
            }


            if (!await _context.User.AnyAsync(x => x.Token == payload.Subject))
            {
                await _context.User.AddAsync(new User()
                {
                    Name = payload.Email,
                    Nick = payload.Name,
                    Token = payload.Subject
                });
                await _context.SaveChangesAsync();
            }

            var user = await _context.User.Where(x => x.Token == payload.Subject).FirstOrDefaultAsync();
            var sessionToken = Guid.NewGuid().ToString();

            var cacheOpt = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(8));
            _cache.Set(sessionToken, user.Id, cacheOpt);

            return sessionToken;
        }
    }

    public class AuthCodeRequest
    {
        public string Code { get; set; }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
    }
}
