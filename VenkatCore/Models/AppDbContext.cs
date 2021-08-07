using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenkatCore.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sqlserver connection

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Department>().ToTable("Department");



            //Employee Department 1 : M Relationsship and Foreignkey
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(emp => emp.Department)
                .WithMany(dept => dept.Employees)
                .HasForeignKey(emp => emp.DeptId);



            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 1, DeptName = "It"},
                new Department() { Id = 2, DeptName = "Hr" },
                new Department() { Id = 3, DeptName = "Accounting" });
        }





    }
}
