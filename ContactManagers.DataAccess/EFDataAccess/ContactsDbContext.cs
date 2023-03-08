using System.Data.Entity;

namespace ContactManagers.DataAccess.EFDataAccess
{
    internal partial class ContactsDbContext : DbContext
    {
        public ContactsDbContext()
            : base("name=appconfig")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Location)
                .IsFixedLength();
        }
    }
}
