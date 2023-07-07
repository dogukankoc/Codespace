using Microsoft.EntityFrameworkCore;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagement.Services
{
    public class BlockService
    {
        public Site List(int siteId)
        {
            using (var context = new SiteManagementDbContext())
            {
                return context.Sites.Include(x => x.Blocks).Where(x => x.Id == siteId).FirstOrDefault();
            }
        }
    }
}
