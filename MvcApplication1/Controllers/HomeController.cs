namespace MvcApplication1.Controllers
{
    using System.Web.Mvc;

    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }
    }
}
