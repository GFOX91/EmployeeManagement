using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedDepartments(modelBuilder);
        SeedEmployees(modelBuilder);
    }

    private void SeedDepartments(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(new[]
        {
            new Department { Id = 1, Name = "IT" },
            new Department { Id = 2, Name = "HR" },
            new Department { Id = 3, Name = "Payroll" },
            new Department { Id = 4, Name = "Admin" }
        });
    }

    private void SeedEmployees(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(new[]
        {
                new Employee
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Hastings",
                    Email = "David@pragimtech.com",
                    DateOfBirth = new DateTime(1980, 10, 5),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/john.png"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Sam",
                    LastName = "Galloway",
                    Email = "Sam@pragimtech.com",
                    DateOfBirth = new DateTime(1981, 12, 22),
                    Gender = Gender.Male,
                    DepartmentId = 2,
                    PhotoPath = "images/sam.jpg"
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Mary",
                    LastName = "Smith",
                    Email = "mary@pragimtech.com",
                    DateOfBirth = new DateTime(1979, 11, 11),
                    Gender = Gender.Female,
                    DepartmentId = 1,
                    PhotoPath = "images/mary.png"
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Sara",
                    LastName = "Longway",
                    Email = "sara@pragimtech.com",
                    DateOfBirth = new DateTime(1982, 9, 23),
                    Gender = Gender.Female,
                    DepartmentId = 3,
                    PhotoPath = "images/sara.png"
                }
     });
    }
}

