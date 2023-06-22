using Microsoft.AspNetCore.Mvc;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using System;
using System.Linq;

namespace SiteManagement.Controllers
{
    public class ApartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("apartment/list/{blockId}")]
        public IActionResult List(int blockId)
        {
            using (var context = new SiteManagementDbContext())
            {
                ViewBag.ApartmentList = context.Apartments.Where(x => x.BlockId == blockId).ToList();
                ViewBag.BlockId = blockId;
                //
                //context.Apartments.Where(a => a.)
                return View();
            }
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
            using (var context = new SiteManagementDbContext())
            {
                var apartment = new Apartment()
                {
                    Name = createApartmentDTO.Name,
                    BlockId = Convert.ToInt32(HttpContext.Request.Path.Value.Split('/').LastOrDefault())
                };
                context.Apartments.Add(apartment);
                context.SaveChanges();
                return RedirectToAction("list", new { blockId = apartment.BlockId });
            }
        }

        [HttpPost]
        public IActionResult DeleteApartment(int apartmentId)
        {
            using (var context = new SiteManagementDbContext())
            {
                var toBeDeletedApartment = context.Apartments.FirstOrDefault(a => a.Id == apartmentId);
                context.Apartments.Remove(toBeDeletedApartment);
                return Ok(context.SaveChanges());
            }
        }

        [Route("apartment/updateapartment/{blockId}/{apartmentId}")]
        public IActionResult UpdateApartment(int blockId, int apartmentId)
        {
            using (var context = new SiteManagementDbContext())
            {
                var apartment = context.Apartments
                    .Where(a => a.Id == apartmentId && a.BlockId == blockId)
                    .Select(a => new UpdateApartmentDTO
                    {
                        ApartmentId = a.Id,
                        BlockId = a.BlockId,
                        ApartmentName = a.Name,
                    }).FirstOrDefault();
                return View(apartment);
            }
        }

        [Route("apartment/updateapartment/{blockId}/{apartmentId}")]
        [HttpPost]
        public IActionResult UpdateApartment(UpdateApartmentDTO updateApartmentDTO)
        {
            using (var context = new SiteManagementDbContext())
            {
                var toBeUpdatedApartment = context.Apartments.FirstOrDefault(a => a.Id == updateApartmentDTO.ApartmentId);
                toBeUpdatedApartment.Name = updateApartmentDTO.ApartmentName;
                context.SaveChanges();
                return RedirectToAction("list", new { blockId = toBeUpdatedApartment.BlockId });
            }
        }
    }
}
