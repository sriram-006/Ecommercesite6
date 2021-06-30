
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using truyum_WebAPIPracticeCheck.Models;
using truyum_WebAPIPracticeCheck.Repository;

namespace truyum_WebAPIPracticeCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       // static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        private readonly IAuthenticationManager manager;
        private readonly TruYumContext _context;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        public AuthController(IAuthenticationManager manager,TruYumContext context)
        {
            this.manager = manager;
            this._context = context;
        }
        [HttpGet]
        public string Get()
        {
            _log4net.Info("Login initiated!");
            return "Login using Authenticate User";
        }

        [AllowAnonymous]
        [HttpPost("AuthenicateUser")]
        public IActionResult AuthenticateUser([FromBody] AuthenticateModel user)
        {
            _log4net.Info(" Http Authentication request Initiated");

            var token = manager.Authenticate(_context.Users.ToList(),user.UserName, user.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

    }
}
