using Microsoft.AspNetCore.Http;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using System;
using System.Linq;

namespace SiteManagement.Services
{
    public class ApartmentService
    {
        readonly SiteManagementDbContext _context;
        public ApartmentService(SiteManagementDbContext context)
        {
            _context = context;
        }

        public Apartment CreateApartment(CreateApartmentDTO createApartmentDTO, int blockId)
        {
            var apartment = new Apartment()
            {
                Name = createApartmentDTO.Name,
                BlockId = blockId
            };
            _context.Apartments.Add(apartment);
            _context.SaveChanges();
            return apartment;
        }

        public void DeleteApartment(int apartmentId)
        {
            var toBeDeletedApartment = _context.Apartments.FirstOrDefault(a => a.Id == apartmentId);

            _context.Apartments.Remove(toBeDeletedApartment);
            _context.SaveChanges();
        }

        public UpdateApartmentDTO GetApartmentByBlockIdandApartmentId(int blockId, int apartmentId)
        {
            var apartment = _context.Apartments
                    .Where(a => a.Id == apartmentId && a.BlockId == blockId)
                    .Select(a => new UpdateApartmentDTO
                    {
                        ApartmentId = a.Id,
                        BlockId = a.BlockId,
                        ApartmentName = a.Name,
                    }).FirstOrDefault();
            return apartment;
        }

        public Apartment UpdateApartment(UpdateApartmentDTO updateApartmentDTO)
        {
            var toBeUpdatedApartment = _context.Apartments.FirstOrDefault(a => a.Id == updateApartmentDTO.ApartmentId);
            toBeUpdatedApartment.Name = updateApartmentDTO.ApartmentName;
            _context.SaveChanges();
            return toBeUpdatedApartment;
        }

        //public Apartment GetApartmentById()
        //{
            
        //    return null;
        //}

        
    }
}
