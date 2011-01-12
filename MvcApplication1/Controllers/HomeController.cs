using System.Text;

namespace MvcApplication1.Controllers
{
    using System.Web.Mvc;
    using Dominio.Model;

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

        [FormatFilter]
        public ActionResult Index()
        {
            var pizzas = new[]
                         {
                             new Pizza {Number = 1, Name = "Pizza 1", Price = "$10"},
                             new Pizza {Number = 2, Name = "Pizza 2", Price = "$13"},
                             new Pizza {Number = 3, Name = "Pizza 3", Price = "$20"}
                         };
            
            return View(pizzas);
            
        }

       
        public ActionResult Products()
        {
            return View();
        }
    }
}
