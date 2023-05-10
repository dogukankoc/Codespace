using Microsoft.EntityFrameworkCore;
using ToDoApp.Db.Entities;

namespace ToDoApp.Db
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=ToDoDb; Integrated Security = true; Encrypt = false");
        }
    }
}
