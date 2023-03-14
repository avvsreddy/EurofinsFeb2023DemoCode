namespace KnowledgeHubPortal.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<KnowledgeHubPortal.Data.KnowledgeHubDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "KnowledgeHubPortal.Data.KnowledgeHubDBContext";
        }

        protected override void Seed(KnowledgeHubPortal.Data.KnowledgeHubDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
