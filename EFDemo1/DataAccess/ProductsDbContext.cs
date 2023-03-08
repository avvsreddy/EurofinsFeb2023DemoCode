using EFDemo1.Entities;
using System.Data.Entity;

namespace EFDemo1.DataAccess
{
    public class ProductsDbContext : DbContext
    {

        // configure database

        public ProductsDbContext() : base("name=default")
        {

        }

        // configure tables

        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory> Catagories { get; set; }

    }
}
