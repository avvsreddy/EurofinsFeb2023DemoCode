using KnowledgeHubPortal.Data;
using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.WebUI.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebUI.Controllers
{

    public class ArticlesController : Controller
    {

        private IArticlesManager aMgr = null;
        private IArticlesRepository aRepo = null;
        private ICatagoryRepository cRepo = null;
        private ICatagoriesManager cMgr = null;

        public ArticlesController()
        {
            aRepo = new ArticlesRepository();
            cRepo = new CatagoryRepository();
            aMgr = new ArticlesManager(aRepo);
            cMgr = new CatagoryManager(cRepo);
        }

        // GET: Articles



        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SubmitArticle()
        {
            //var catagories = cMgr.ListCatagories();

            var catagories = from c in cMgr.ListCatagories()
                             select new SelectListItem { Text = c.Name, Value = c.CatagoryId.ToString() };
            ViewBag.CatagoryId = catagories;
            return View();
        }

        [HttpPost]
        public ActionResult SubmitArticle(ArticleSubmitViewModel articlevm)
        {
            // validate
            if (!ModelState.IsValid)
            {
                return RedirectToAction("SubmitArticle");
            }

            // convert vm to dm
            Article article = new Article();
            article.Title = articlevm.Title;
            article.Url = articlevm.Url;
            article.Description = articlevm.Description;
            article.CatagoryId = articlevm.CatagoryID;

            // fill the remaining properties
            article.IsApproved = false;
            article.DateSubmited = DateTime.Now;
            if (User.Identity.IsAuthenticated)
                article.Submiter = User.Identity.Name;
            else
                article.Submiter = "Unknow";

            // submit to domain
            aMgr.SubmitArticle(article);
            TempData["Message"] = $"Article {article.Title} submited for review.";
            return RedirectToAction("Index");
        }
    }
}