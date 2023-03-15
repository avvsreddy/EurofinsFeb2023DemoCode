using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.Domain.Entities;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class CatagoriesController : Controller
    {
        // GET: Catagories

        //private Domain.Data.ICatagoryRepository repo = null;
        private ICatagoriesManager mgr = null;

        //public CatagoriesController()
        //{
        //    repo = new CatagoryRepository();
        //    mgr = new CatagoryManager(repo);
        //}

        public CatagoriesController(ICatagoriesManager mgr)
        {
            this.mgr = mgr;
        }
        public ActionResult Index()
        {
            var catagoryList = mgr.ListCatagories();
            return View(catagoryList);
        }

        // .../catagories/create
        [HttpGet]
        //[AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Catagory catagory)
        {
            // servier side validation
            if (!ModelState.IsValid)
            {
                return View();
            }
            // do not do this - inject with ioc


            mgr.CreateCatagory(catagory);

            TempData["Message"] = $"Catagory {catagory.Name} created successfully...";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //?????
            // fetch the catagory details based on id
            // send that to view for editing
            var catToEdit = mgr.GetCatagoryById(id);
            return View(catToEdit);
        }
        [HttpPost]
        public ActionResult Edit(Catagory editedCatagory)
        {
            // validate
            if (!ModelState.IsValid)
            {
                return View(editedCatagory);
            }
            // update into db
            mgr.EditCatagory(editedCatagory);
            //return View("Index",mgr.ListCatagories());
            TempData["Message"] = $"Catagory edited successfully...";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(mgr.GetCatagoryById(id));
        }

        public ActionResult ConfirmDelete(int id)
        {
            mgr.DeleteCatagory(id);
            TempData["Message"] = $"Catagory {id} deleted successfully...";
            return RedirectToAction("Index");
        }


    }
}