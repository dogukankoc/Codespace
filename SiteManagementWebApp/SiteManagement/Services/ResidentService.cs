using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagement.Services
{
    public class ResidentService
    {
        readonly SiteManagementDbContext _context;
        public ResidentService(SiteManagementDbContext context)
        {
            _context = context;
        }

        public Human CreatePerson(CreatePersonDTO createPersonDTO, int apartmentId)
        {
            var newPerson = new Human()
            {
                NameSurname = createPersonDTO.NameSurname,
                ApartmentId = apartmentId
            };
            _context.Humans.Add(newPerson);
            _context.SaveChanges();
            return newPerson;
        }

        public void DeletePerson(int personId)
        {
            var toBeDeletedPerson = _context.Humans.FirstOrDefault(a => a.Id == personId);
            _context.Humans.Remove(toBeDeletedPerson);
            _context.SaveChanges();
        }

        public UpdatePersonDTO GetPersonByPersonIdandApartmentId (int apartmentId, int personId)
        {
            return _context.Humans
                    .Where(a => a.Id == personId && a.ApartmentId == apartmentId)
                    .Select(a => new UpdatePersonDTO
                    {
                        PersonId = a.Id,
                        NameSurname = a.NameSurname,
                        ApartmentId = a.ApartmentId,
                    }).FirstOrDefault();
        }

        public Human UpdatePerson(UpdatePersonDTO updatePersonDTO)
        {
            var toBeUpdatedPerson = _context.Humans.FirstOrDefault(a => a.Id == updatePersonDTO.PersonId);
            toBeUpdatedPerson.NameSurname = updatePersonDTO.NameSurname;
            _context.SaveChanges();
            return toBeUpdatedPerson;
        }

        public List<Human> GetHomeOwnerById(int apartmentId)
        {
           return _context.Humans.Where(h => h.ApartmentId == apartmentId).ToList();
        }

        public void SetHomeOwner(int responsible, int apartmentID)
        {
            var homeOwner = _context.Apartments.FirstOrDefault(a => a.Id == apartmentID);
            homeOwner.HomeOwnerId = responsible;
            _context.SaveChanges();
        }
    }
}
