using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using truyum_WebAPIPracticeCheck.Models;

namespace truyum_WebAPIPracticeCheck.Repository
{
    public interface IAuthenticationManager
    {
        public string Authenticate(List<User> users,string username, string password);
    }
}
