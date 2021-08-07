using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<EmployeeLeave> EmployeeLeaves { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            
        //    optionsBuilder.UseSqlServer("server=CHANDANA\\SQLEXPRESS2012;database=JqueryAjaxDB;Integrated Security=true");

        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<EmployeeLeave>().ToTable("EmployeeLeave");
            modelBuilder.Entity<EmployeePosition>().ToTable("EmployeePosition");

            modelBuilder.Entity<Employee>()
                .HasOne<EmployeePosition>(emp => emp.EmployeePosition)
                .WithMany(empPosition => empPosition.Employees)
                .HasForeignKey(emp => emp.EmployeePositionId);


            modelBuilder.Entity<EmployeeLeave>()
                .HasOne<Employee>(empLeave => empLeave.Employee)
                .WithMany(emp => emp.EmployeeLeaves);


            modelBuilder.Entity<EmployeePosition>().HasData(
                    new EmployeePosition() { Id=1, PositionCode="IE", Position="Irrigation Engineer" },
                    new EmployeePosition() { Id = 2, PositionCode = "EA", Position = "Engineer Assistant" },
                    new EmployeePosition() { Id = 3, PositionCode = "DO", Position = "Development Officer" },
                    new EmployeePosition() { Id = 4, PositionCode = "MA", Position = "Management Assistant" }
                );

            modelBuilder.Entity<Employee>().HasData(
                    new Employee() { Id = 1, Name = "Buddika", Address = "Matara", EmployeePositionId = 1 } ,
                    new Employee() { Id = 2, Name = "Perl", Address = "Matara", EmployeePositionId = 2 },
                    new Employee() { Id = 3, Name = "Bandusiri", Address = "Galle", EmployeePositionId = 2 },
                    new Employee() { Id = 4, Name = "Ranaweera", Address = "Weeraketiya", EmployeePositionId = 2 },
                    new Employee() { Id = 5, Name = "Kumara", Address = "Dickwella", EmployeePositionId = 3 },
                    new Employee() { Id = 6, Name = "Lucky", Address = "Middeniya", EmployeePositionId = 3 },
                    new Employee() { Id = 7, Name = "Udayanga", Address = "Matara", EmployeePositionId = 3 },
                    new Employee() { Id = 8, Name = "Anjana", Address = "Matara", EmployeePositionId = 4 },
                    new Employee() { Id = 9, Name = "Hansika", Address = "Matara", EmployeePositionId = 4 },
                    new Employee() { Id = 10, Name = "Gamage", Address = "Matara", EmployeePositionId = 4 }
                );

        }

    }
}
