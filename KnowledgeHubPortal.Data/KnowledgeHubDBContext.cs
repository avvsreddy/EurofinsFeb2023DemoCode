using KnowledgeHubPortal.Domain.Entities;
using System.Data.Entity;

namespace KnowledgeHubPortal.Data
{
    internal class KnowledgeHubDBContext : DbContext
    {
        public KnowledgeHubDBContext() : base("name=DefaultConnection") { }

        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
