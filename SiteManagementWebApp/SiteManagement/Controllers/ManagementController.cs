using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagement.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Auth");
        }

        public IActionResult CreateNewSite()
        {

            var context = new SiteManagementDbContext();
            List<Province> Kategoriler = context.Provinces.ToList();
            ViewBag.KategoriListesi = new SelectList(Kategoriler, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewSite(CreateSiteDTO createSiteDTO)
        {
            using (var context = new SiteManagementDbContext())
            {
                var site = new Site()
                {
                    Name = createSiteDTO.Name,
                    DistrictId = createSiteDTO.DistrictId,
                    Adress = createSiteDTO.Adress
                };

                context.Sites.Add(site);
                context.SaveChanges();
            }
            return RedirectToAction("SiteList");
        }
        [HttpPost]
        public IActionResult DeleteSite(int siteId)
        {
            using (var context = new SiteManagementDbContext())
            {
                var toBeDeletedSite = context.Sites.FirstOrDefault(x => x.Id == siteId);
                context.Sites.Remove(toBeDeletedSite);
                return Ok(context.SaveChanges());
            }
            
        }

        public IActionResult SiteList()
        {
            using (var context = new SiteManagementDbContext())
            {
                ViewBag.SiteList = context.Sites.ToList();
                ViewBag.BlockList = context.Blocks.ToList();

            }
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
