using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SiteManagement.Models.Db.Entities;

namespace SiteManagement.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            
            TempData["welcomeMessage"] = HttpContext.Session.GetString("UserSession");
            return View();
        }
    }
}
