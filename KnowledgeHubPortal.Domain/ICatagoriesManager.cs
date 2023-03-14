using KnowledgeHubPortal.Domain.Entities;
using System.Collections.Generic;

namespace KnowledgeHubPortal.Domain
{
    public interface ICatagoriesManager
    {
        void CreateCatagory(Catagory catagory);
        List<Catagory> ListCatagories();
        void EditCatagory(Catagory catagoryToEdit);

        void DeleteCatagory(int catagoryId);

        Catagory GetCatagoryById(int id);
    }
}
