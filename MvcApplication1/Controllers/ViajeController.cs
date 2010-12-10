using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Repositorios;
using MvcApplication1.Dominio.Model;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class ViajeController : Controller
    {
        //
        // GET: /Viaje/
        public ActionResult Index()
        {
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            return View(repo.GetAll());
        }

        public ActionResult Details(int id)
        {
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            return View(repo.GetById(id));
        }
        
        public ActionResult Create()
        {
            IEnumerable<string> items = new string[] { "Publico", "Privado" };
            ViewData["Privacidad"] = new SelectList(items);
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            IEnumerable<string> items = new string[] {"Publico","Privado"};
            ViewData["Privacidad"] = new SelectList(items);
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                viaje.IdViaje = id;
                IRepositorio<Viaje> repo = new ViajeRepositorio();
                repo.Update(viaje);

                return RedirectToAction("Index");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            IEnumerable<string> items = new string[] { "Publico", "Privado" };
            ViewData["Privacidad"] = new SelectList(items);
            return View(viaje);
        }

        [HttpPost]
        public ActionResult Create(Viaje viaje)
        {
            if (ModelState.IsValid)
            {                
                IRepositorio<Viaje> repo = new ViajeRepositorio();
                repo.Save(viaje);

                return RedirectToAction("Index");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            IEnumerable<string> items = new string[] { "Publico", "Privado" };
            ViewData["Privacidad"] = new SelectList(items);
            return View(viaje);
        }

        public ActionResult Delete(int id)
        {
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }
    }
}
