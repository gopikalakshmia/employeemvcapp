using employeemvcapp.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeSalary> EmployeeSalaries  {get; set; }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    // Seeding data for the Category table
    modelBuilder.Entity<Employee>().HasData(
        new Employee
        {
          id = 1,
          FirstName = "Gopika",
          LastName = "lakshmi",
          City = "Vaughan",
          Zip = "L4K0N7",
          CreatedDate = new DateTime(2025, 6, 14),
        },
        new Employee
        {
          id = 2,
          FirstName = "Vishnu",
          LastName = "Karun",
          City = "Vaughan",
          Zip = "L4K0N7",
          CreatedDate = new DateTime(2025, 6, 14),
        }
    );

  }
}