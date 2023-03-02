using ContactManagers.DataAccess;
using ContactManagers.DataAccess.Entities;

namespace ContactManager.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IContactsRepository repo = new ContactsDBRepository();
            Contact c = new Contact { ContactID = 2, Name = "Sachin 2", Email = "sachin@bcci.org", Location = "Mumbai", Phone = "234234234" };
            repo.Save(c);
            System.Console.WriteLine("done");
        }
    }
}
