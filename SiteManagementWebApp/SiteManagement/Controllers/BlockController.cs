using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using System;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;

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
        [Route("block/updateblock/{siteId}/{blockId}")]
        public IActionResult UpdateBlock(int siteId,int blockId)
        {
            using(var context = new SiteManagementDbContext())
            {
                var block = context.Blocks
                    .Where(x => x.SiteId == siteId && x.Id == blockId)
                    .Select(x => new UpdateBlockDTO
                    {   
                        BlockId = x.Id,
                        SiteId = x.SiteId,
                        BlockName = x.BlockName
                    }).FirstOrDefault();

                return View(block);
            }
            
        }

        [Route("block/updateblock/{siteId}/{blockId}")]
        [HttpPost]
        public IActionResult UpdateBlock(UpdateBlockDTO updateBlockDTO)
        {
            using(var context = new SiteManagementDbContext())
            {
                var toBeUpdatedBlock = context.Blocks.FirstOrDefault(x => x.Id == updateBlockDTO.BlockId);
                toBeUpdatedBlock.BlockName = updateBlockDTO.BlockName;
                context.SaveChanges();
                return RedirectToAction("list", new { siteId = toBeUpdatedBlock.SiteId});
            }
            
        }


        [HttpPost]
        public IActionResult DeleteBlock(int blockId)
        {
            using (var context = new SiteManagementDbContext())
            {
                var toBeDeletedBlock = context.Blocks.FirstOrDefault(x => x.Id == blockId);
                context.Blocks.Remove(toBeDeletedBlock);
                return Ok(context.SaveChanges());
            }
        }
    }
}
