using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagement.Services
{
    public class CommonService
    {
        readonly SiteManagementDbContext _context;
        public CommonService(SiteManagementDbContext context) 
        {
            _context = context;
        }

        public List<Province> GetCities()
        {
            return _context.Provinces.ToList();
        }

        public List<District> GetDistrictListByCityId(int cityId)
        {
           return _context.Districts.Where(d => d.ProvinceId == cityId).ToList();
        }


    }
}
