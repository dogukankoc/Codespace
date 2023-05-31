using Microsoft.AspNetCore.Mvc;

namespace SiteManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
