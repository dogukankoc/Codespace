using Microsoft.AspNetCore.Mvc;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using System;
using System.Linq;

namespace SiteManagement.Controllers
{
    public class ResidentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("resident/residentlist/{apartmentId}")]
        public IActionResult ResidentList(int apartmentId) 
        {
            using(var context = new SiteManagementDbContext()) 
            {
                ViewBag.ResidentList = context.Humans.Where(h => h.ApartmentId == apartmentId).ToList();
                ViewBag.ApartmentId = apartmentId;
            }
            return View();
        }

        [Route("resident/createperson/{apartmentId}")]
        public IActionResult CreatePerson(int apartmentId)
        {
            ViewBag.ApartmentId = apartmentId;
            return View();
        }

        [HttpPost]
        [Route("resident/createperson/{apartmentId}")]
        public IActionResult CreatePerson(CreatePersonDTO createPersonDTO)
        {
            using(var context = new SiteManagementDbContext())
            {
                var newPerson = new Human()
                {
                    NameSurname = createPersonDTO.NameSurname,
                    ApartmentId = Convert.ToInt32(HttpContext.Request.Path.Value.Split("/").LastOrDefault())
                };
                context.Humans.Add(newPerson);
                context.SaveChanges();
                return RedirectToAction("ResidentList", new { apartmentId = newPerson.ApartmentId});
            }
        }

        [HttpPost]
        public IActionResult DeletePerson(int personId)
        {
            using (var context = new SiteManagementDbContext())
            {
                var toBeDeletedPerson = context.Humans.FirstOrDefault(a => a.Id == personId);
                context.Humans.Remove(toBeDeletedPerson);
                return Ok(context.SaveChanges());
            }
        }
        
        [Route("resident/updateperson/{apartmentId}/{personId}")]
        public IActionResult UpdatePerson(int apartmentId, int personId)
        {
            using (var context = new SiteManagementDbContext())
            {
                var apartment = context.Humans
                    .Where(a => a.Id == personId && a.ApartmentId == apartmentId)
                    .Select(a => new UpdatePersonDTO
                    {
                        PersonId = a.Id,
                        NameSurname = a.NameSurname,
                        ApartmentId = a.ApartmentId,
                    }).FirstOrDefault();
                return View(apartment);
            }
        }

        [Route("resident/updateperson/{apartmentId}/{personId}")]
        [HttpPost]
        public IActionResult UpdateApartment(UpdatePersonDTO updatePersonDTO)
        {
            using (var context = new SiteManagementDbContext())
            {
                var toBeUpdatedPerson = context.Humans.FirstOrDefault(a => a.Id == updatePersonDTO.PersonId);
                toBeUpdatedPerson.NameSurname = updatePersonDTO.NameSurname;
                context.SaveChanges();
                return RedirectToAction("residentlist", new { apartmentId = toBeUpdatedPerson.ApartmentId });
            }
        }
        [Route("resident/sethomeowner/{apartmentId}")]
        public IActionResult SetHomeOwner(int apartmentId)
        {
            using (var context = new SiteManagementDbContext())
            {
                ViewBag.ResidentList = context.Humans.Where(h => h.ApartmentId == apartmentId).ToList();
            }
            return View();
        }

        //[Route("resident/sethomeowner/")]
        [HttpPost]
        public IActionResult SetHomeOwnerPost(int responsible, int apartmentID)
        {
            using (var context = new SiteManagementDbContext())
            {
                var homeOwner = context.Apartments.FirstOrDefault(a => a.Id == apartmentID);
                homeOwner.HomeOwnerId= responsible;
                context.SaveChanges();  
            }
            // return RedirectToAction("residentlist", new {apartmentId = apartmentID}); //Ajax succes data bekliyor, burayı ezer.
            return Ok();
        }

        
    }
}
