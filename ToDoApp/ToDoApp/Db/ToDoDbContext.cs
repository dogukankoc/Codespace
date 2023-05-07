using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Db.Entities;

namespace ToDoApp.Db
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> ToDo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=ToDoDb; Integrated Security = true; Encrypt = false");
        }

    }

   
}
