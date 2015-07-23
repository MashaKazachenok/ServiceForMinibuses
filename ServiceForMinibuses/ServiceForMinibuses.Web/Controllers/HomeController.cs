using System.Web.Mvc;

namespace ServiceForMinibuses.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ActiveMenuItem = "home";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.ActiveMenuItem = "about";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.ActiveMenuItem = "contact";
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}