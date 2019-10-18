using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAzure.Controllers
{
    [Route("/")] 
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(GitHubAuthenticationDefaults.AuthenticationScheme);
            }

            HttpContext.Response.Cookies.Append("githubchat_username", User.Identity.Name);
            HttpContext.SignInAsync(User);
            return Redirect("/");
        }
    }
}