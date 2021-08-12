using LibraryManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
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
        public DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        public DbSet<Hold> Holds { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<BranchHours> BranchHours { get; set; }
        public DbSet<Status> Statuses { get; set; }

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
            modelBuilder.Entity<CheckoutHistory>().ToTable("CheckoutHistory");
            modelBuilder.Entity<Hold>().ToTable("Hold");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Video>().ToTable("Video");
            modelBuilder.Entity<BranchHours>().ToTable("BranchHours");
            modelBuilder.Entity<Status>().ToTable("Status");



            //Define 1 : 1 Relationship - Patron : LibraryCard
            modelBuilder.Entity<Patron>()
                .HasOne<LibraryCard>(p => p.LibraryCard)
                .WithOne(LC => LC.Patron)
                .HasForeignKey<LibraryCard>(LC => LC.Id);


            //Define 1 : 1 Relationship - LibraryBranch : BranchHours 
            modelBuilder.Entity<LibraryBranch>()
                .HasOne<BranchHours>(LB => LB.BranchHours)
                .WithOne(bh => bh.Branch)
                .HasForeignKey<BranchHours>(bh => bh.Id);



            //Define 1 : N Relationship - Patron : LibraryBranch
            modelBuilder.Entity<Patron>()
                .HasOne<LibraryBranch>(p => p.HomeLibraryBranch)
                .WithMany(Lb => Lb.Patrons)
                .HasForeignKey(p => p.LibraryBranchId);



            //Define 1 : N Relationship - Checkout : LibraryCard
            modelBuilder.Entity<Checkout>()
                .HasOne<LibraryCard>(c => c.LibraryCard)
                .WithMany(LC => LC.Checkouts)
                .HasForeignKey(c => c.LibraryCardId);

            //Define 1 : N Relationship - Checkout : LibraryAsset
            modelBuilder.Entity<Checkout>()
                .HasOne<LibraryAsset>(c => c.LibraryAsset)
                .WithMany(LA => LA.Checkouts)
                .HasForeignKey(c => c.LibraryCardId);



            //Define 1 : N Relationship - CheckoutHistory : LibraryCard
            modelBuilder.Entity<CheckoutHistory>()
                .HasOne<LibraryCard>(ch => ch.LibraryCard)
                .WithMany(LC => LC.CheckoutHistories)
                .HasForeignKey(ch => ch.LibraryCardId);

            //Define 1 : N Relationship - CheckoutHistory : LibraryAsset
            modelBuilder.Entity<CheckoutHistory>()
                .HasOne<LibraryAsset>(ch => ch.LibraryAsset)
                .WithMany(LA => LA.CheckoutHistories)
                .HasForeignKey(ch => ch.LibraryAssetId);



            //Define 1 : N Relationship - Hold : LibraryCard
            modelBuilder.Entity<Hold>()
                .HasOne<LibraryCard>(h => h.LibraryCard)
                .WithMany(LC => LC.Holds)
                .HasForeignKey(h => h.LibraryCardId);

            //Define 1 : N Relationship - Hold : LibraryAsset
            modelBuilder.Entity<Hold>()
                .HasOne<LibraryAsset>(h => h.LibraryAsset)
                .WithMany(LA => LA.Holds)
                .HasForeignKey(h => h.LibraryAssetId);
        }

    }
}
