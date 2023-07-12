using Microsoft.AspNetCore.Mvc;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using SiteManagement.Services;
using System;
using System.Linq;

namespace SiteManagement.Controllers
{
    public class ResidentController : Controller
    {
        readonly ResidentService _residentService;
        readonly ApartmentService _apartmentService;

        public ResidentController(ResidentService residentService, ApartmentService service)
        {
            _residentService = residentService;
            _apartmentService = service;
        }

        [Route("resident/residentlist/{apartmentId}")]
        public IActionResult ResidentList(int apartmentId)
        {
            using (var context = new SiteManagementDbContext())
            {
                ViewBag.ResidentList = context.Humans.Where(h => h.ApartmentId == apartmentId).ToList();
                ViewBag.Apartment = context.Apartments.Where(a => a.Id == apartmentId).FirstOrDefault();
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
            int apartmentId = Convert.ToInt32(HttpContext.Request.Path.Value.Split("/").LastOrDefault());
            Human newPerson = _residentService.CreatePerson(createPersonDTO, apartmentId);

            return RedirectToAction("ResidentList", new { apartmentId = newPerson.ApartmentId });
        }

        [HttpPost]
        public IActionResult DeletePerson(int personId)
        {
            _residentService.DeletePerson(personId);
            return Ok();
        }

        [Route("resident/updateperson/{apartmentId}/{personId}")]
        public IActionResult UpdatePerson(int apartmentId, int personId)
        {
            return View(_residentService.GetPersonByPersonIdandApartmentId(apartmentId, personId));
        }

        [Route("resident/updateperson/{apartmentId}/{personId}")]
        [HttpPost]
        public IActionResult UpdatePerson(UpdatePersonDTO updatePersonDTO)
        {
            Human toBeUpdatedPerson = _residentService.UpdatePerson(updatePersonDTO);
            return RedirectToAction("residentlist", new { apartmentId = toBeUpdatedPerson.ApartmentId });
        }

        [Route("resident/sethomeowner/{apartmentId}")]
        public IActionResult SetHomeOwner(int apartmentId)
        {
            ViewBag.ResidentList = _residentService.GetHomeOwnerById(apartmentId);
            return View();
        }

        [HttpPost]
        public IActionResult SetHomeOwnerPost(int responsible, int apartmentID)
        {
            _residentService.SetHomeOwner(responsible, apartmentID);
            return RedirectToAction("residentlist", new { apartmentId = apartmentID }); //Ajax succes data bekliyor, burayı ezer.
        }
    }
}
