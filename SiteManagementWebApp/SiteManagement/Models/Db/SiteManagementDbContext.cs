using Microsoft.EntityFrameworkCore;
using SiteManagement.Models.Db.Entities;

namespace SiteManagement.Models.Db
{
    public class SiteManagementDbContext : DbContext
    {
       public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=SiteManagementDb; Integrated Security= true; Encrypt=false");
        }
    }
}
