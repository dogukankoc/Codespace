using Microsoft.EntityFrameworkCore;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagement.Services
{
    public class SiteService
    {
        readonly SiteManagementDbContext _context;
        public SiteService(SiteManagementDbContext context)
        {
            _context = context;
        }

        public Site GetSiteWithBlocks(int siteId)
        {
            return _context.Sites.Include(x => x.Blocks).Where(x => x.Id == siteId).FirstOrDefault();
        }

        public List<Site> GetSiteListOrdered()
        {
            return _context.Sites.OrderByDescending(x => x.Id).ToList();
        }

        public void CreateNewSite(CreateSiteDTO createSiteDTO)
        {
            var site = new Site()
            {
                Name = createSiteDTO.Name,
                DistrictId = createSiteDTO.DistrictId,
                Adress = createSiteDTO.Adress
            };
            _context.Sites.Add(site);
            _context.SaveChanges();
        }

        public UpdateSiteDTO GetSiteById(int id)
        {
            var site = _context.Sites
                    .Include(x => x.District)
                    .Where(x => x.Id == id)
                    .Select(x => new UpdateSiteDTO
                    {
                        Id = x.Id,
                        SiteName = x.Name,
                        DistrictId = x.DistrictId,
                        SiteAdress = x.Adress,
                        CityId = x.District.ProvinceId
                    }).FirstOrDefault();

            return site;
        }

        public void UpdateSite(UpdateSiteDTO updateSiteDTO)
        {
            var toBeUpdatedSite = _context.Sites.FirstOrDefault(x => x.Id == updateSiteDTO.Id);
            toBeUpdatedSite.Name = updateSiteDTO.SiteName;
            toBeUpdatedSite.Adress = updateSiteDTO.SiteAdress;
            toBeUpdatedSite.DistrictId = updateSiteDTO.DistrictId;
            _context.SaveChanges();
        }

        public void DeleteSite(int siteId)
        {
            var toBeDeletedSite = _context.Sites.FirstOrDefault(x => x.Id == siteId);
            _context.Sites.Remove(toBeDeletedSite);
            _context.SaveChanges();
        }

        //public string GetSiteBySiteId(int siteId)
        //{
        //    return _context.Sites.Where(s => s.Id == siteId).FirstOrDefault();
        //}

        public Site GetSiteWithWorkers(int siteId)
        {
            return _context.Sites.Include(x => x.Workers).Where(x => x.Id == siteId).FirstOrDefault();
        }
    }
}
