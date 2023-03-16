using CrezyProductsCatalogService.Models.DomainModels;
using System.Data.Entity;

namespace CrezyProductsCatalogService.Models.Data
{
    public class CrezyProductsDbContext : DbContext
    {
        public CrezyProductsDbContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<CrezyProduct> CrezyProducts { get; set; }
    }
}