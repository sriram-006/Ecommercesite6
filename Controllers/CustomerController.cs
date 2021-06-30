using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using truyum_WebAPIPracticeCheck.Models;

namespace truyum_WebAPIPracticeCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly TruYumContext _context;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CustomerController));

        public CustomerController(TruYumContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        [Authorize(Roles = Role.Customer)]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            _log4net.Info("Get all carts called!");
            return await _context.Carts.Where(i=>i.MenuItem.Active && i.MenuItem.DateOfLaunch< DateTime.UtcNow).ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Customer)]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            _log4net.Info("Get action with parameter!");
            var cart = await _context.Carts.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = Role.Customer)]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            _log4net.Info("Put Cart action!");
            if (id != cart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = Role.Customer)]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            _log4net.Info("Post Cart action!");
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Customer)]
        public async Task<IActionResult> DeleteCart(int id)
        {
            _log4net.Info("Delete Cart Action!");
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.CartId == id);
        }
    }
}
