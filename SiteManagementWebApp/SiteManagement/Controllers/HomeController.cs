using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiteManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                TempData["welcomeMessage"] = HttpContext.Session.GetString("UserSession");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

    }
}
