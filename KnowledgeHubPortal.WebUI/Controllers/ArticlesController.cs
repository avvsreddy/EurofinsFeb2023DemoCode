using Humanizer;
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
            var articlesForBrowse = from a in aMgr.GetArticlesForBrowse()
                                    select new ArticlesForBrowseViewModel
                                    {
                                        Title = a.Title,
                                        CatagoryName = a.Catagory.Name,
                                        Description = a.Description,
                                        Submiter = a.Submiter,
                                        Url = a.Url,
                                        WhenSubmited = a.DateSubmited.Humanize(true)
                                    };
            return View(articlesForBrowse);
        }

        [HttpGet]
        public ActionResult SubmitArticle()
        {
            //var catagories = cMgr.ListCatagories();

            var catagories = from c in cMgr.ListCatagories()
                             select new SelectListItem { Text = c.Name, Value = c.CatagoryId.ToString() };
            ViewBag.CatagoryId = catagories;
            //DateTime.Now.Humanize();
            return View();
        }

        [HttpPost]
        public ActionResult SubmitArticle(ArticleSubmitViewModel articlevm)
        {
            // validate
            if (!ModelState.IsValid)
            {
                var catagories = from c in cMgr.ListCatagories()
                                 select new SelectListItem { Text = c.Name, Value = c.CatagoryId.ToString() };
                ViewBag.CatagoryId = catagories;
                return View();
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
            return View();
        }
    }
}