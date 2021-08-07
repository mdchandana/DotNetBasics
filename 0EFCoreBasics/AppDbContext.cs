using _0EFCoreBasics.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0EFCoreBasics
{
    public class AppDbContext : DbContext
    {
        /*
        * IF WE NEED TO RUN THIS CLASS LIBRY PROJECT STAND ALONE WITH DbCOntext....
        *    1. Comment or,Remove 'AppDbContext(DbContextOptions<AppDbContext> options) : base(options)' method..
        *       [this is only need when we run our project through WebApp..  ]
        *       
        *    2. override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        *       [have to set Database provider and connectionString]
        */


        /*We Only need this DbContextOption method when we run through WebApp Project..
        *This method call By 'void ConfigureServices(IServiceCollection services)' -
        method inside Startup.cs in WebApp Project..*/
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{

        //}





        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders  { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }




        /* WORKED.......IF WE NEED THIS OnConfiguring Method Only If We RUN EfCoreBasics ClassLibry STAND ALONE.....
         * We Don't need this OnConfiguring method to configure, when our WebApp project set as statup project..Eg:EFCoreTestingWebApp ...
         * This method is configuring DatabaseProvider using UseSqlServer() method and 
         * Read ConnString by appsettings.json file Withing EfCoreBasics ClassLibry ...(appsettings.json File inside ClassLib Project)..
         * appsettings.json" properties should be configured to  'Copy To Output Derectory'  'copyIfNewer' or 'Always'
         */



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //WORKED..Access with hard coded connstring
            optionsBuilder.UseSqlServer("Server=CHANDANA\\SQLEXPRESS2012;Database=EFCoreBasicsDB;Integrated Security=True;");

            //Below code is Used appsetting.json file to read connection string
            //Need package Microsoft.Extensions.Configuration.Json

            //IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            //IConfiguration configuration = configurationBuilder.Build();
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("EFCoreBasicsDbConnString"));
        }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //In EfCore ,By Manually,For Bridge Table , we can't define Composite key for  primaryKey..
            //So solution is below lines.. easily we can define OrderId,ProductId define as composite key
            modelBuilder.Entity<OrderDetail>()
                .HasKey(orderDetail => new { orderDetail.OrderId, orderDetail.ProductId });


            //configure table name FluentAPI
            //modelBuilder.Entity<Customer>().ToTable("Customer");
            //modelBuilder.Entity<Order>().ToTable("Order");
            //modelBuilder.Entity<Product>().ToTable("Product");
            //modelBuilder.Entity<Category>().ToTable("Category");
            //modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");


            //============= Configure Relationships with Fluent API============================
            /*HasOne / WithOne are used for reference navigation properties and-
             HasMany / WithMany are used for collection navigation properties.*/


            //==== [Order]       [Customer] 1 : M  ============
            //modelBuilder.Entity<Order>()
            //    .HasOne<Customer>(o => o.Customer)
            //    .WithMany(c => c.Orders)
            //    .HasForeignKey(o => o.CustomerId);


            //==== [Product]       [Category] 1 : M  ============          
            //modelBuilder.Entity<Product>()
            //    .HasOne<Category>(p => p.Category)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey(p => p.CategoryId);


            //==== [OrderDetail]     [Order] 1 : M  ==========    
            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne<Order>(od => od.Order)
            //    .WithMany(o => o.OrderDetails)
            //    .HasForeignKey(od => od.OrderId);


            //==== [OrderDetail]    [Product] 1 : M ============
            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne<Product>(od => od.Product)
            //    .WithMany(p => p.OrderDetails)
            //    .HasForeignKey(od => od.ProductId);

            //=====================================================================



            //======================SEED DATA=======================================
            /*
            Seed data is data that you populate the database with at the time it is created. 
            You use seeding to provide initial values for lookup lists, for demo purposes, proof of concepts etc.
             
            EF Core Seed data means pre-populating the database with default data. This is useful in scenarios 
            where you want to provide some test data in the development environment. You could use this to set up 
            the application for the first time in a production environment by providing the sample or useful master data.

            How to Seed Data in EF Core
            In the EF Core, the database seeding has now become part of the Model Configuration. We discussed how to Configure the model using the Fluent API. This is done by overriding the OnModelCreating method.
             */

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id=1, Name = "sidath" },
                new Customer { Id = 2, Name = "chandana" },
                new Customer { Id = 3, Name = "yasiru" });

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Laptop" },
                new Category() { Id = 2, Name = "Phone" });

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "hp dv5", Price = 175000.00M, QtyInStock = 5, CategoryId = 1 },
                new Product() { Id = 2, Name = "hp dv6",Price=200000.00M, QtyInStock=5,CategoryId=1},                
                new Product() { Id = 3, Name = "iphone 6s", Price = 50000.00M, QtyInStock = 5, CategoryId = 2 },
                new Product() { Id = 4, Name = "iphone 7", Price = 70000.00M, QtyInStock = 5, CategoryId = 2 }
                );



            //adding some orders-----------
            modelBuilder.Entity<Order>().HasData(
                new Order() { Id = 1, CustomerId = 1, OrderedDate = DateTime.Today},
                new Order() { Id = 2, CustomerId = 2, OrderedDate = DateTime.Today }
                );

            //adding some ordersDetails-- for order1
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail()
                {
                    OrderId=1,
                    ProductId=1,
                    Qty=1,
                    UnitPrice=175000.00M,
                    Discount=0M
                },
                new OrderDetail()
                {
                    OrderId = 1,
                    ProductId = 2,
                    Qty = 1,
                    UnitPrice = 200000.00M,
                    Discount = 0M
                },
                new OrderDetail()
                {
                    OrderId = 2,
                    ProductId = 2,
                    Qty = 1,
                    UnitPrice = 50000.00M,
                    Discount = 0M
                },
                new OrderDetail()
                {
                    OrderId = 2,
                    ProductId = 3,
                    Qty = 1,
                    UnitPrice = 70000.00M,
                    Discount = 0M
                }
                );

        }

    }
}
