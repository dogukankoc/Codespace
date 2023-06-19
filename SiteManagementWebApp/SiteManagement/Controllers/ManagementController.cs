using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult UpdateSite(int id)
        {
            using (var context = new SiteManagementDbContext())
            {
                var site = context.Sites
                    .Include(x => x.District)
                    .Where(x => x.Id == id)
                    .Select(x => new UpdateSiteDTO
                    {
                        Id = x.Id,
                        SiteName = x.Name,
                        DistrictId = x.DistrictId,
                        SiteAdress = x.Adress,
                        CityId = x.District.ProvinceId
                    }).FirstOrDefault();
                return View(site);
            }

            
        }
        [HttpPost]
        public IActionResult UpdateSite(UpdateSiteDTO updateSiteDTO)
        {
            using (var context = new SiteManagementDbContext())
            {
              var toBeUpdatedSite =  context.Sites.FirstOrDefault(x => x.Id == updateSiteDTO.Id);
                toBeUpdatedSite.Name = updateSiteDTO.SiteName;
                toBeUpdatedSite.Adress = updateSiteDTO.SiteAdress;
                toBeUpdatedSite.DistrictId = updateSiteDTO.DistrictId;
                context.SaveChanges();

            }
            return RedirectToAction("SiteList");
        }

        public IActionResult SiteList()
        {
            using (var context = new SiteManagementDbContext())
            {
                ViewBag.SiteList = context.Sites.OrderByDescending(x => x.Id).ToList();  

            }
            return View();
        }

        public IActionResult GetDistricts(int cityId)
        {
            using (var context = new SiteManagementDbContext())
            {
                return Json(context.Districts.Where(d => d.ProvinceId == cityId).ToList());
            }
        }

        public IActionResult GetCities()
        {
            using (var context = new SiteManagementDbContext())
            {
                return Json(context.Provinces.ToList());
            }
        }

    }
}
