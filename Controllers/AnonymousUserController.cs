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
    public class AnonymousUserController : ControllerBase
    {
        private readonly TruYumContext _context;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AnonymousUserController));

        public AnonymousUserController(TruYumContext context)
        {
            _context = context;
        }

        // GET: api/AnonymousUser
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            _log4net.Info("Get Menu Items Called!");
            return await _context.MenuItems.ToListAsync();
        }
    }
}
