using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using System;
using System.Linq;
using System.Security.Permissions;

namespace SiteManagement.Controllers
{
    
    public class BlockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("block/list/{siteId}")]
        public IActionResult List(int siteId)
        {
            using (var context = new SiteManagementDbContext())
            {
                ViewBag.BlockList = context.Blocks.Where(x => x.SiteId == siteId).ToList();

                ViewBag.SiteId = siteId;

            }
            return View();
        }
        
        public IActionResult CreateBlock(int siteId)
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateBlock(CreateBlockDTO createBlockDTO)
        {
            using (var context = new SiteManagementDbContext())
            {
                var block = new Block()
                {
                    BlockName = createBlockDTO.Name,
                    SiteId =  Convert.ToInt32(HttpContext.Request.Path.Value.Split('/').LastOrDefault())
                };
                context.Blocks.Add(block);
                context.SaveChanges();
                return RedirectToAction("list", new {siteId = block.SiteId});  
            }
        }
    }
}
