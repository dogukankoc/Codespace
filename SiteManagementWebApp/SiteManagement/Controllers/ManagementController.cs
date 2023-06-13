using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using System.Collections.Generic;
using System.Linq;

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

            var context = new SiteManagementDbContext();
            List<Province> Kategoriler = context.Provinces.ToList();
            ViewBag.KategoriListesi = new SelectList(Kategoriler, "Id", "Name");
            return View();
        }
        public IActionResult GetSubCategories(int categoryId)
        {
            using (var context = new SiteManagementDbContext())
            {
                List<District> altkategoriler = context.Districts.Where(d => d.ProvinceId == categoryId).ToList();
                return Json(altkategoriler);
            }
        }

        public IActionResult GetCategories()
        {
            using (var context = new SiteManagementDbContext())
            {
                return Json(context.Provinces.ToList());
            }
        }

    }
}
