using Microsoft.AspNetCore.Mvc;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using SiteManagement.Services;
using System;
using System.Linq;

namespace SiteManagement.Controllers
{
    public class ApartmentController : Controller
    {
        readonly BlockService _blockService;
        readonly ApartmentService _apartmentService;
        public ApartmentController(BlockService blockService, ApartmentService apartmentService)
        {
            _blockService = blockService;
            _apartmentService = apartmentService;
        }

        [Route("apartment/list/{blockId}")]
        public IActionResult List(int blockId)
        {
            ViewBag.Block = _blockService.GetBlockWithApartmentByBlockId(blockId);
            return View();
        }

        [Route("apartment/createapartment/{blockId}")]
        public IActionResult CreateApartment(int blockId)
        {
            ViewBag.BlockId = blockId;
            return View();
        }

        [Route("apartment/createapartment/{blockId}")]
        [HttpPost]
        public IActionResult CreateApartment(CreateApartmentDTO createApartmentDTO)
        {
            int blockId = Convert.ToInt32(HttpContext.Request.Path.Value.Split('/').LastOrDefault());
            Apartment apartment = _apartmentService.CreateApartment(createApartmentDTO, blockId);
            return RedirectToAction("list", new { blockId = apartment.BlockId });
        }

        [HttpPost]
        public IActionResult DeleteApartment(int apartmentId)
        {
            _apartmentService.DeleteApartment(apartmentId);
            return Ok();
        }

        [Route("apartment/updateapartment/{blockId}/{apartmentId}")]
        public IActionResult UpdateApartment(int blockId, int apartmentId)
        {
            return View(_apartmentService.GetApartmentByBlockIdandApartmentId(blockId, apartmentId));
        }

        [Route("apartment/updateapartment/{blockId}/{apartmentId}")]
        [HttpPost]
        public IActionResult UpdateApartment(UpdateApartmentDTO updateApartmentDTO)
        {
            Apartment toBeUpdatedApartment = _apartmentService.UpdateApartment(updateApartmentDTO);
            return RedirectToAction("list", new { blockId = toBeUpdatedApartment.BlockId });
        }
    }
}
