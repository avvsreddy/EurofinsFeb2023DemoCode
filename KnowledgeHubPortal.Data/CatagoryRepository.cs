using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeHubPortal.Data
{
    public class CatagoryRepository : ICatagoryRepository
    {

        private readonly KnowledgeHubDBContext db = new KnowledgeHubDBContext();
        public void Delete(int id)
        {
            db.Catagories.Remove(db.Catagories.Find(id));
            db.SaveChanges();
        }

        public void Edit(Catagory catagory)
        {
            db.Entry(catagory).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Catagory> GetAll()
        {
            return db.Catagories.ToList();
        }

        public Catagory GetCatagoryById(int id)
        {
            return db.Catagories.Find(id);
        }

        public void Save(Catagory catagoryToSave)
        {
            db.Catagories.Add(catagoryToSave);
            db.SaveChanges();
        }
    }
}
