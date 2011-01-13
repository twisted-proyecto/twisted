using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Infrastructure;
using Norm;

namespace MvcApplication1.Controllers
{
    public class CategoryController : Controller
    {
        
        public ActionResult Index()
        {
            using (var session = new MongoSession<Category>())
            {
                var categories = session.Queryable.AsEnumerable<Category>();
                return View(categories);
            }
        }

       
        [HttpGet]
        public ActionResult Edit(ObjectId id) 
        {
           
            using (var session = new MongoSession<Category>())
            {
                var category = session.Queryable
                      .Where(c => c.Id == id)
                      .FirstOrDefault();

                return View("Save",category);
            }
           
        }
        // GET: /Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            var category = new Category();
            return View("Save", category);
        }
        [HttpPost]
        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", category);
            }
            using (var session = new MongoSession<Category>())
            {
                session.Save(category);
                return RedirectToAction("Index");
            }
           
        }        
        
        public ActionResult Delete(ObjectId id)
        {
            using (var session = new MongoSession<Category>())
            {
                var category = session.Queryable
                      .Where(c => c.Id == id)
                      .FirstOrDefault();
                session.Delete(category);
                var categories = session.Queryable.AsEnumerable<Category>();
                return View("Index", categories);
            }
           
        }        
    }
}
