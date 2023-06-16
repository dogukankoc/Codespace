﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Controllers;
using SiteManagement;
using Microsoft.IdentityModel.Protocols;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace SiteManagement.Models.Db
{
    public class SiteManagementDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentDept> ApartmentDepts { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<Worker> Workers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Site>()
            //    .HasOne(c => c.District)   
            //    .WithOne(c => c.Site)
            //    .HasForeignKey<Site>(c => c.DistrictId); //CalisanAdresi Depentend olacak burada bildiridk ve Id kolonunun foreign key olduğunu söyledik. Primary key özelliği ezilmesin diye .HasKey ile primary key olduğunu da bildirmemiz gerek

            //modelBuilder.Entity<District>()
            //    .HasKey(c => c.Id); //CalisanAdresi entity'sindeki Id kolonunun Primary key olduğunu bildirmiş olduk.
        }

    }

    

}
