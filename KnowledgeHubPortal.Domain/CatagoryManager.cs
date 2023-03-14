using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System.Collections.Generic;

namespace KnowledgeHubPortal.Domain
{
    public class CatagoryManager : ICatagoriesManager
    {
        private ICatagoryRepository repo = null;
        public CatagoryManager(ICatagoryRepository repo)
        {
            this.repo = repo;
        }

        public void CreateCatagory(Catagory catagory)
        {
            // apply any business rules here

            // call data layer for saving
            repo.Save(catagory);
        }

        public void DeleteCatagory(int catagoryId)
        {
            repo.Delete(catagoryId);
        }

        public void EditCatagory(Catagory catagoryToEdit)
        {
            repo.Edit(catagoryToEdit);
        }

        public Catagory GetCatagoryById(int id)
        {
            return repo.GetCatagoryById(id);
        }

        public List<Catagory> ListCatagories()
        {
            return repo.GetAll();
        }
    }
}
