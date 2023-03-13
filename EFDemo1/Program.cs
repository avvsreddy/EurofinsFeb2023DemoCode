using EFDemo1.DataAccess;
using EFDemo1.Entities;
using System;
using System.Linq;

namespace EFDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            //var plist = db.Products.ToList();
            //foreach (var item in plist)
            //{
            //    item.Rate += 1000;
            //db.SaveChanges();
            //}
            db.SaveChanges();

            string sqlUpdate = "update products set rate = rate + 1000";
            db.Database.ExecuteSqlCommand(sqlUpdate);
            Console.WriteLine("done");
        }

        private static void AddCustomerSuppliers()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            // add new customer
            var c = new Customer { Name = "Customer 1", CustomerType = "Gold", Discount = 12, Email = "customer1@mail.com", Location = "location 1", Mobile = "23434234" };

            db.People.Add(c);


            // add new supplier

            var s = new Supplier { Name = "Supplier 1", GST = "424BSDF234", Rating = 8 };
            db.People.Add(s);

            db.SaveChanges();
        }

        private static void NewMethod1()
        {
            // get all products belongs to mobile catagory
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            var allMobiles = (from c in db.Catagories
                              where c.Name == "Mobiles"
                              select c.Products).FirstOrDefault();

            foreach (var item in allMobiles)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void display1()
        {
            // display product name, rate and catagory name
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            var prodcuts = from p in db.Products //.Include("Catagory")
                           select p;

            foreach (var item in prodcuts)
            {
                Console.WriteLine($"{item.Name}\t{item.Rate}\t{item.Catagory.Name}");
            }
        }

        private static void NewProductWithExistingCatagory()
        {
            // Add new product with existing catagory
            // Ex: add a new product into mobiles catagory
            // 
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            var mobiles = (from c in db.Catagories
                           where c.Name == "Mobiles"
                           select c).FirstOrDefault();

            var p = new Product { Name = "Galaxy S23", Brand = "Samsung", Catagory = mobiles, Rate = 79999 };

            db.Products.Add(p);
            db.SaveChanges();
        }

        private static void AddNewCatWithNewProd()
        {
            // Add new catagory with new product
            var cat = new Catagory { Name = "Mobiles" };
            var p = new Product { Name = "I Phone X", Rate = 75000, Brand = "Apple", Country = "India", Catagory = cat };

            ProductsDbContext db = new ProductsDbContext();
            db.Products.Add(p);
            //db.Catagories.Add(cat);
            db.SaveChanges();
        }

        private static void Delete()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            // delete iphone x
            var productToDelete = (from p in db.Products
                                   where p.Name == "IPhone 12"
                                   select p).FirstOrDefault();



            if (productToDelete == null)
            {
                System.Console.WriteLine("Product not found");
            }
            else
            {
                db.Products.Remove(productToDelete);
                System.Console.WriteLine("Deleted...");
            }

            db.SaveChanges();
        }

        private static void Read()
        {
            ProductsDbContext db = new ProductsDbContext();
            // get all produts - Linq to Entities
            var allProducts = from p in db.Products
                              select p;

            var simpleWay = db.Products;

            // display
            foreach (var item in allProducts)
            {
                System.Console.WriteLine($"{item.Name}\t{item.Rate}");
            }
        }

        private static void Save()
        {
            Product p = new Product { Name = "IPhone 12", Description = "Expensive Phone", Rate = 79000 };
            ProductsDbContext db = new ProductsDbContext();
            db.Products.Add(p);
            db.SaveChanges();
            System.Console.WriteLine("done");
        }
    }
}
