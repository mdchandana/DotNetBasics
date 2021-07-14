
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VenkatMvc5.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() : base("VenkatMvc5-ConnString")  
        {                                                              

        }

        public DbSet<Employeee> Employeees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}