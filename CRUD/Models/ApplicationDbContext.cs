using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { 
                    Id = 1, 
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Email = "Ivanov@gmail.com"
                },
                new Customer { 
                    Id = 2, 
                    FirstName = "Alex",
                    LastName = "Alexov",
                    Email = "Alexov@gmail.com"
                },
                new Customer { 
                    Id = 3, 
                    FirstName = "Vladimir",
                    LastName = "Vladimirov",
                    Email = "Vladimirov@gmail.com"
                }
                );
        }
    }
}
