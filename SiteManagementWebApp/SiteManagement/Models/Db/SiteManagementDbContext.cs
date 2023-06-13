using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Controllers;
using SiteManagement;
using Microsoft.IdentityModel.Protocols;
using System.Collections.Generic;
using System.Linq;

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
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }
    }

    

}
