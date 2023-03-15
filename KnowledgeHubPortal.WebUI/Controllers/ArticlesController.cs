using Humanizer;
using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebUI.Controllers
{

    public class ArticlesController : Controller
    {

        private IArticlesManager aMgr = null;
        //private IArticlesRepository aRepo = null;
        //private ICatagoryRepository cRepo = null;
        private ICatagoriesManager cMgr = null;

        //public ArticlesController()
        //{
        //    aRepo = new ArticlesRepository();
        //    cRepo = new CatagoryRepository();
        //    aMgr = new ArticlesManager(aRepo);
        //    cMgr = new CatagoryManager(cRepo);
        //}

        public ArticlesController(IArticlesManager aMgr, ICatagoriesManager cMgr)
        {
            this.aMgr = aMgr;
            this.cMgr = cMgr;
        }

        // GET: Articles



        public ActionResult Index(string searchTerm = null)
        {
            var articlesForBrowse = from a in aMgr.GetArticlesForBrowse()
                                    select new ArticlesForBrowseViewModel
                                    {
                                        Title = a.Title,
                                        CatagoryName = a.Catagory.Name,
                                        Description = a.Description,
                                        Submiter = a.Submiter,
                                        Url = a.Url,
                                        WhenSubmited = a.DateSubmited.Humanize(false)
                                    };
            if (searchTerm != null)
            {
                var filtredArticlesForBrowse = from a in articlesForBrowse
                                               where a.Title.ToLower().Contains(searchTerm.ToLower()) ||
                                               a.Description.ToLower().Contains(searchTerm.ToLower()) ||
                                               a.Url.ToLower().Contains(searchTerm.ToLower()) ||
                                               a.CatagoryName.ToLower().Contains(searchTerm.ToLower()) ||
                                               a.Submiter.ToLower().Contains(searchTerm.ToLower())
                                               select a;
                return View(filtredArticlesForBrowse);
            }

            return View(articlesForBrowse);
        }


        [Authorize]
        [HttpGet]
        public ActionResult Submit()
        {
            //var catagories = cMgr.ListCatagories();

            var catagories = from c in cMgr.ListCatagories()
                             select new SelectListItem { Text = c.Name, Value = c.CatagoryId.ToString() };
            ViewBag.CatagoryId = catagories;

            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Submit(ArticleSubmitViewModel articlevm)
        {
            var catagories = from c in cMgr.ListCatagories()
                             select new SelectListItem { Text = c.Name, Value = c.CatagoryId.ToString() };
            ViewBag.CatagoryId = catagories;
            // validate
            if (!ModelState.IsValid)
            {

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
            TempData["Message"] = $"Article {article.Title} submited for review. Thanks";
            return View(new ArticleSubmitViewModel());
        }

        [Authorize(Roles = "admin")]
        public ActionResult ReviewArticles()
        {
            var articlesForReview = from a in aMgr.GetArticlesForReview()
                                    select new ReviewArticleViewModel
                                    {
                                        Id = a.Id,
                                        Title = a.Title,
                                        Url = a.Url,
                                        Catagory = a.Catagory.Name,
                                        WhenSubmited = a.DateSubmited.Humanize(false),
                                        Submiter = a.Submiter,
                                    };
            return View(articlesForReview);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Approve(List<int> articlIds)
        {
            aMgr.ApproveArticles(articlIds);
            TempData["Message"] = $"{articlIds.Count} Articles Approved Successfully";
            // send email to the submiter about this action
            return RedirectToAction("ReviewArticles");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Reject(List<int> articlIds)
        {
            aMgr.RejectArticles(articlIds);
            TempData["Message"] = $"{articlIds.Count} Articles Rejected Successfully";
            // send email to the submiter about this action

            return RedirectToAction("ReviewArticles");
        }
    }
}