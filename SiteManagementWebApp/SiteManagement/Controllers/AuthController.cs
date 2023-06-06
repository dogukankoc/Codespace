using Microsoft.AspNetCore.Mvc;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Services;

namespace SiteManagement.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var userControl = AuthServices.Login(email, password);
            if(userControl != null)
            {
                TempData["welcomeMessage"] = userControl;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.checkInformation = "Girdiğiniz bilgiler yanlış lütfen tekrar deneyin.";
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            using (SiteManagementDbContext context = new SiteManagementDbContext())
            {
                if (ModelState.IsValid)
                {
                    var availableMail = AuthServices.Register(user);
                    if(availableMail != null)
                    {
                        ViewBag.availableMail = availableMail;
                        return View();
                    }
                    else
                    {
                        return View("Login");
                    }
                }
                return View();
            }
        }
    }
}
