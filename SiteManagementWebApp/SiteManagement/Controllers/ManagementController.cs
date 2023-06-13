using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiteManagement.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Auth");
        }
        
        public IActionResult SiteCreate()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult SiteCreate()
        //{
        //    return View();
        //}
    }
}
