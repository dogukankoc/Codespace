using Microsoft.AspNetCore.Mvc;
using SiteManagement.Models.DTOs;
using SiteManagement.Services;
using System;
using System.Linq;

namespace SiteManagement.Controllers
{
    public class BlockController : Controller

    {
        readonly SiteService _siteService;
        readonly BlockService _blockService;
        public BlockController(SiteService siteService, BlockService blockService)
        {
            _siteService = siteService;
            _blockService = blockService;
        }

        [Route("block/list/{siteId}")]
        public IActionResult List(int siteId)

        {
            ViewBag.Site = _siteService.GetSiteWithBlocks(siteId);
            return View();
        }
        
        public IActionResult CreateBlock(int siteId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlock(CreateBlockDTO createBlockDTO, int _siteId)
        {
            _siteId = Convert.ToInt32(HttpContext.Request.Path.Value.Split('/').LastOrDefault());
            _blockService.CreateBlock(createBlockDTO, _siteId);

            return RedirectToAction("list", new { siteId = _siteId });
        }

        [Route("block/updateblock/{siteId}/{blockId}")]
        public IActionResult UpdateBlock(int siteId,int blockId)
        {
           return View( _blockService.GetUpdateBlock(siteId, blockId));
        }

        [Route("block/updateblock/{siteId}/{blockId}")]
        [HttpPost]
        public IActionResult UpdateBlock(UpdateBlockDTO updateBlockDTO)
        {
            int siteId = _blockService.PostUpdateBlock(updateBlockDTO);
            return RedirectToAction("list", new { siteId =siteId });
        }

        [HttpPost]
        public IActionResult DeleteBlock(int blockId)
        {
            _blockService.DeleteBlock(blockId);
            return Ok();
        }
    }
}
