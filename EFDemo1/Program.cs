using EFDemo1.DataAccess;
using EFDemo1.Entities;
using System.Linq;

namespace EFDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Delete();

        }

        private static void Delete()
        {
            ProductsDbContext db = new ProductsDbContext();
            // delete iphone x
            var productToDelete = (from p in db.Products
                                   where p.Name == "IPhone X"
                                   select p).FirstOrDefault();

            var productToDel = db.Products.Find(2);

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
