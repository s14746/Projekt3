using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Projekt3.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LogoutController(
            SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        // POST: Logout
        public void Index()
        {
            signInManager.SignOutAsync();
            Response.Redirect("/");
        }
    }
}
