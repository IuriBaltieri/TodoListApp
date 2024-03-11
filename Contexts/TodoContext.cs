using Microsoft.EntityFrameworkCore;

using TodoListApp.Models;

namespace TodoListApp.Contexts
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todo { get; set; }

        public TodoContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\Local;Database=Todo;Trusted_Connection=True;");
        }
    }
}
