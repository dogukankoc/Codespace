using Microsoft.EntityFrameworkCore;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
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
    }
}
