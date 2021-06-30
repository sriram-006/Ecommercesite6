using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using truyum_WebAPIPracticeCheck.Models;

namespace truyum_WebAPIPracticeCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TruYumContext _context;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(UsersController));

        public UsersController(TruYumContext context)
        {
            _context = context;
        }

        // GET: api/Users
       /* [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }*/

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            _log4net.Info("Get Users Called!");
            var user = await _context.Users.FindAsync(id);
            if (user.Role == Role.Admin)
                return Unauthorized();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

 
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _log4net.Info("Post Users Action called!");
            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserID))
                {
                    return Conflict();
                }
                else if (user.Role == Role.Admin)
                    return Unauthorized();
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        private bool UserExists(int id)
        {
            _log4net.Info("User exists check!");
            return _context.Users.Any(e => e.UserID == id && e.Role!=Role.Admin);
        }
    }
}
