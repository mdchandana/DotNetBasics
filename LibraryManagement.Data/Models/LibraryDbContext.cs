using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }


        public DbSet<Patron> Patrons { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<LibraryBranch> LibraryBranches { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //configure connection string
            base.OnConfiguring(optionsBuilder);
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryBranch>().ToTable("LibraryBranch");
            modelBuilder.Entity<Patron>().ToTable("Patron");
            modelBuilder.Entity<LibraryCard>().ToTable("LibraryCard");
            modelBuilder.Entity<Checkout>().ToTable("Checkout");

            //Define 1 : N Relationship - Patron : LibraryBranch




            //Define 1 : N Relationship - Checkout : LibraryCard
            modelBuilder.Entity<Checkout>()
                .HasOne<LibraryCard>(c => c.LibraryCard)
                .WithMany(L => L.Checkouts)
                .HasForeignKey(c => c.LibraryCardId);


            //Define 1 : 1 Relationship - Patron : LibraryCard
            modelBuilder.Entity<Patron>()
                .HasOne<LibraryCard>(p => p.LibraryCard)
                .WithOne(L => L.Patron)
                .HasForeignKey<LibraryCard>(L => L.Id);

        }

    }
}
