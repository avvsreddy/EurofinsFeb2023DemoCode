using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebUI.Controllers
{
    public class HomeController : Controller
    {

        // URL: http://domainname.com
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(Duration = 60, VaryByParam = "*", Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult About()
        {
            ViewBag.Message = DateTime.Now;
            return View();
        }

        public async Task<ActionResult> Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // /Home/Hello
        public ActionResult Hello()
        {
            string greeting = "Hello, Welcome to MVC";
            ViewBag.Message = greeting; // 
            //ViewData["Message"] = greeting;
            //TempData["Message"] = greeting;
            return View();
        }


    }
}