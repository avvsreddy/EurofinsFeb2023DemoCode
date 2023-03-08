namespace EFDemo1.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDemo1.DataAccess.ProductsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EFDemo1.DataAccess.ProductsDbContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EFDemo1.DataAccess.ProductsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
