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

        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // for TPC

            modelBuilder.Entity<Customer>().Map(c =>
            {
                c.MapInheritedProperties();
                c.ToTable("Customers");
            });

            modelBuilder.Entity<Supplier>().Map(s =>
            {
                s.MapInheritedProperties();
                s.ToTable("Suppliers");
            });

            // for Stored Procedures

            //modelBuilder.Entity<Customer>().MapToStoredProcedures();
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
            // INSERT/UPDATE/DELETE
        }


    }
}
