using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Models.Db;
using SiteManagement.Models.DTOs;
using SiteManagement.Services;

namespace SiteManagement.Controllers
{
    public class ManagementController : Controller
    {
        readonly SiteManagementDbContext _context;
        readonly SiteService _siteService;
        readonly CommonService _commonService;


        public ManagementController(SiteManagementDbContext context, SiteService siteService, CommonService commonService)
        {
            _context = context;
            _siteService = siteService;
            _commonService = commonService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Auth");
        }

        public IActionResult SiteList()
        {
            ViewBag.SiteList = _siteService.GetSiteListOrdered();
            return View();
        }

        public IActionResult CreateNewSite()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewSite(CreateSiteDTO createSiteDTO)
        {
            _siteService.CreateNewSite(createSiteDTO);
            return RedirectToAction("SiteList");
        }

        public IActionResult UpdateSite(int id)
        {
            return View(_siteService.GetSiteById(id));
        }

        [HttpPost]
        public IActionResult UpdateSite(UpdateSiteDTO updateSiteDTO)
        {
            _siteService.UpdateSite(updateSiteDTO);
            return RedirectToAction("SiteList");
        }

        [HttpPost]
        public IActionResult DeleteSite(int siteId)
        {
            _siteService.DeleteSite(siteId);
            return Ok();
        }

        public IActionResult GetDistricts(int cityId)
        {
                return Json(_commonService.GetDistrictListByCityId(cityId));
        }

        public IActionResult GetCities()
        {
                return Json(_commonService.GetCities());
        }

    }
}
