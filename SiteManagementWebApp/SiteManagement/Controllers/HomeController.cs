using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models;
using SiteManagement.Models.Db;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

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
