using basicWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace basicWebApp.Data;

public class HRDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public HRDbContext(DbContextOptions<HRDbContext> option) : base(option)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Name = "Türkay", LastName = "Ürkmez", Id = 1 },
            new Employee { Name = "Necla", LastName = "Naber", Id = 2 },
            new Employee { Name = "Fatih", LastName = "Baytar", Id = 3 }
        );


    }
}