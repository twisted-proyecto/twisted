using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Dominio.Repositorios;

namespace MvcApplication1.Controllers
{
    public class PersonaController : Controller
    {
        

        public ActionResult Index()
        {

            IRepositorioPersona<Persona> repo = new PersonaRepositorio();
            return View(repo.GetAll());
        }


        public ActionResult Verificar()
        {
            string nick = Session["data"] as string;
            IRepositorioPersona<Persona> repo = new PersonaRepositorio();
            if (repo.GetById(nick) != null)
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("Create", "Persona");

        }

        public ActionResult Details(String id)
        {
            IRepositorioPersona<Persona> repo = new PersonaRepositorio();
            return View(repo.GetById(id));
        }

        //
        // GET: /Persona/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Persona/Create

        [HttpPost]
        public ActionResult Create(Persona Persona, String id)
        {
            if (ModelState.IsValid)
            {
                if (Session["data"]!=null)
                Persona.Nickname = Session["data"] as string;

                IRepositorioPersona<Persona> repo = new PersonaRepositorio();
                repo.Save(Persona);

                return RedirectToAction("Index");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario

            return View(Persona);
        }
        
        //
        // GET: /Persona/Edit/5
 
        public ActionResult Edit(String id)
        {
            IRepositorioPersona<Persona> repo = new PersonaRepositorio();
            return View(repo.GetById(id));
        }

        //
        // POST: /Persona/Edit/5

        [HttpPost]
        public ActionResult Edit(String id, Persona Persona)
        {
            if (ModelState.IsValid)
            {
                 Persona.Nickname = id;
                 IRepositorioPersona<Persona> repo = new PersonaRepositorio();
                repo.Update(Persona);

                return RedirectToAction("Index");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
           
            return View(Persona);
        }

        //
        // GET: /Persona/Delete/5
 
        public ActionResult Delete(String id)
        {
            IRepositorioPersona<Persona> repo = new PersonaRepositorio();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /Persona/Delete/5

        [HttpPost]
        public ActionResult Delete(String id, Persona Persona)
        {
            if (ModelState.IsValid)
            {
                Persona.Nickname = id;
                IRepositorioPersona<Persona> repo = new PersonaRepositorio();
                repo.Delete(Persona);

                return RedirectToAction("Index");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario

            return View(Persona);
        }
    }
}
