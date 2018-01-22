using System.Web.Mvc;

namespace VideoLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //check if a user has no session, then redirect him to login page. Otherwise, proceed to the landing home page/dashboard
            if (Session["LoggedInUser"] ==null)
            {
                return RedirectToAction("Index", "Login");
            }

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
    }
}