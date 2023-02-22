using ContactManagers.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace ContactManagers.DataAccess
{
    public class ContactsFileRepository : IContactsRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, Contact contactToEdit)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public void Save(Contact contactToSave)
        {
            throw new NotImplementedException();
        }
    }
}
