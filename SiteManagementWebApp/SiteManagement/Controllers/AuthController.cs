using Microsoft.AspNetCore.Mvc;
using SiteManagement.Models.Db.Entities;

namespace SiteManagement.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            

            if(!ModelState.IsValid)
            {
                return View(user);
            }
            return View();
        }
    }
}
