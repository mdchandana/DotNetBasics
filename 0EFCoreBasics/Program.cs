using _0EFCoreBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;


//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{
//    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=CustomerDB;")
//        .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
//}

namespace _0EFCoreBasics
{
    class Program
    {
        static void Main(string[] args)
        {

            

            using (var context = new AppDbContext())
            {




                //=================PROJECTION===================================================================
                // 1 . Anonymouse Type========
                /* Annonymouse types provide an easy way to create a new type without Initializing them..                 
                 * Projecttion queries load data into this anonymouse Type..*/

                var customers = context.Customers
                    .Select(cust => new
                    {
                        Id = cust.Id,
                        CustomerName = cust.Name
                        
                    }).ToList();

                //----------------------------------------------------

                // 2 . Concrete Type
                List<Customer> CustomerList = context.Customers
                                              .Select(cust => new Customer
                                              {
                                                  Id=cust.Id,
                                                  Name=cust.Name
                                              }).ToList();  


                //-------------------------
                //=============================END PROJECTION=====================================================








                Console.WriteLine("Displaying -Product- Informations.......");

                foreach (var product in context.Products.ToList())
                {
                    Console.WriteLine("ProductId :" + product.Id + "\tProductName :" + product.Name + "\tQtyInStock :" + product.QtyInStock);
                }
                Console.WriteLine("");




                Console.WriteLine("Displaying -Order- Informations with Customer Name...");

                //=========Orders with Customer Name==============
                //=========Inner join==================================
                var orders = (from order in context.Orders
                              join customer in context.Customers
                              on order.Id equals customer.Id
                              select new
                              {
                                  OrderId = order.Id,
                                  CustomerName = customer.Name,
                                  OrderedDate = order.OrderedDate
                              }).ToList();



                foreach (var order in orders)
                {
                    Console.WriteLine("Order Id :" + order.OrderId + "\tCustomer Name :" + order.CustomerName + "\tOrderDateTime :" + order.OrderedDate);
                }
                Console.WriteLine("");





                Console.WriteLine("Displaying -OrderDetails- with Products Name...");
                //=========OrderDetails with Product Name==============
                //=========Inner join==================================
                var orderDetailsPName = (from orderDetail in context.OrderDetails
                                         join product in context.Products
                                         on orderDetail.ProductId equals product.Id
                                         select new
                                         {
                                             OrderId = orderDetail.OrderId,
                                             ProductName = product.Name,
                                             Price = orderDetail.UnitPrice,
                                             Qty = orderDetail.Qty,
                                             Discount = orderDetail.Discount
                                         }).ToList();



                foreach (var orderDetails in orderDetailsPName)
                {
                    Console.WriteLine("OrderID :{0}\t Product Name : {1}\t Price :{2}\t Qty :{3}\t Discount :{4}",
                                        orderDetails.OrderId, orderDetails.ProductName, orderDetails.Price, orderDetails.Qty, orderDetails.Discount);
                }








            }

            Console.ReadKey();
        }








        void AddOrder()
        {

            //Console.WriteLine("We are going to add a New Order...");

            //using (var context = new AppDbContext())
            //{

            //    //order1----------------------------------------------
            //    var order1 = new Order()
            //    {
            //        CustomerId = 1,
            //        OrderedDate = DateTime.Today
            //    };


            //    //order2----------------------------------------------
            //    var order2 = new Order()
            //    {
            //        CustomerId = 2,
            //        OrderedDate = DateTime.Today
            //    };

            //    context.Orders.Add(order1);
            //    context.Orders.Add(order2);
            //    context.SaveChanges();



            //    //order1, order details---------------------------------
            //    var order1_Details1 = new OrderDetail()
            //    {
            //        OrderId = order1.Id,
            //        ProductId = 1,
            //        Qty = 1,
            //        UnitPrice = 2200000.00M,
            //        Discount = 0M
            //    };

            //    var order1_Details2 = new OrderDetail()
            //    {
            //        OrderId = order1.Id,
            //        ProductId = 2,
            //        Qty = 1,
            //        UnitPrice = 75000.00M,
            //        Discount = 0M
            //    };
            //    //----------------------------------------------------------



            //    //order2, order details-----------------------------------
            //    var order2_Details1 = new OrderDetail()
            //    {
            //        OrderId = order2.Id,
            //        ProductId = 2,
            //        Qty = 2,
            //        UnitPrice = 75000.00M,
            //        Discount = 0M
            //    };

            //    var order2_Details2 = new OrderDetail()
            //    {
            //        OrderId = order2.Id,
            //        ProductId = 3,
            //        Qty = 2,
            //        UnitPrice = 87000.00M,
            //        Discount = 0M
            //    };
            //    //---------------------------------------------------------


            //    //order1, order details
            //    context.OrderDetails.Add(order1_Details1);
            //    context.OrderDetails.Add(order1_Details2);

            //    //order2, order details
            //    context.OrderDetails.Add(order2_Details1);
            //    context.OrderDetails.Add(order2_Details2);

            //    context.SaveChanges();

            //}

        } //end AddOrder() method





    }
}
