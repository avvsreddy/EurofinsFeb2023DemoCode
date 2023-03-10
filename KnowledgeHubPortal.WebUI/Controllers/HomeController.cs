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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
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