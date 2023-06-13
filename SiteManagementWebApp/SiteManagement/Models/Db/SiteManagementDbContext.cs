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
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.ConnectionString);
        }
    }

    //public class Addprovince
    //{ 
    //    public void AddProvince()
    //    {
            
    //    }
    //}

}
