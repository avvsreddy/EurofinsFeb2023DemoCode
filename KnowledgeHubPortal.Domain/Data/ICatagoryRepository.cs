using KnowledgeHubPortal.Domain.Entities;
using System.Collections.Generic;

namespace KnowledgeHubPortal.Domain.Data
{
    public interface ICatagoryRepository
    {
        void Save(Catagory catagoryToSave);
        List<Catagory> GetAll();
        void Delete(int id);
        void Edit(Catagory catagory);

        Catagory GetCatagoryById(int id);
    }
}
