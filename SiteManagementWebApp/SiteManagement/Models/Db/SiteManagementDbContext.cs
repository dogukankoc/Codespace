using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Controllers;
using SiteManagement;
using Microsoft.IdentityModel.Protocols;

namespace SiteManagement.Models.Db
{
    public class SiteManagementDbContext : DbContext
    {
       public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.ConnectionString);
        }
    }
}
