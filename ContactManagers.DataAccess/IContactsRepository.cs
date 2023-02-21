using ContactManagers.DataAccess.Entities;
using System.Collections.Generic;

namespace ContactManagers.DataAccess
{
    public interface IContactsRepository
    {
        void Save(Contact contactToSave);
        void Delete(int id);
        void Edit(int id, Contact contactToEdit);
        Contact GetContact(int id);
        List<Contact> GetAll();
        List<Contact> GetContactsByLocation(string location);



    }
}
