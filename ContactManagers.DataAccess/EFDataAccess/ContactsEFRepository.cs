using System.Collections.Generic;
using System.Linq;

namespace ContactManagers.DataAccess.EFDataAccess
{
    public class ContactsEFRepository : IContactsRepository
    {
        private ContactsDbContext db = new ContactsDbContext();
        public void Delete(int id)
        {
            db.Contacts.Remove(db.Contacts.Find(id));
            db.SaveChanges();
        }

        public void Edit(int id, Entities.Contact contactToEdit)
        {
            var c = db.Contacts.Find(id);
            c.Name = contactToEdit.Name;
            c.Email = contactToEdit.Email;
            c.Location = contactToEdit.Location;
            c.Phone = contactToEdit.Phone;
            //db.Entry(contactToEdit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Entities.Contact> GetAll()
        {
            //return db.Contacts.ToList<ContactManagers.DataAccess.Entities.Contact>();
            var contacts = from c in db.Contacts
                           select new Entities.Contact
                           {
                               ContactID = c.ContactID,
                               Email = c.Email,
                               Name = c.Name,
                               Location = c.Location,
                               Phone = c.Phone,

                           };

            //db.Contacts.ToList().ConvertAll()
            return contacts.ToList();
        }

        public Entities.Contact GetContact(int id)
        {
            var c = db.Contacts.Find(id);
            return new Entities.Contact
            {
                ContactID = c.ContactID,
                Name = c.Name,
                Location = c.Location,
                Email = c.Email,
                Phone = c.Phone
            };
        }

        public List<Entities.Contact> GetContactsByLocation(string location)
        {
            var contacts = from c in db.Contacts
                           where c.Location == location
                           select new Entities.Contact
                           {
                               ContactID = c.ContactID,
                               Email = c.Email,
                               Name = c.Name,
                               Location = c.Location,
                               Phone = c.Phone,

                           };
            return contacts.ToList();
        }

        public void Save(Entities.Contact c)
        {
            db.Contacts.Add(new Contact
            {
                ContactID = c.ContactID,
                Name = c.Name,
                Location = c.Location,
                Email = c.Email,
                Phone = c.Phone
            });
            db.SaveChanges();

        }
    }
}
