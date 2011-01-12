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
            IList<Viaje> viajes = repo.GetAll();
            IList<Viaje> viajesPublicos = new List<Viaje>();
            foreach (var item in viajes)
            {
                if(item.Privacidad == "Publico")
                  viajesPublicos.Add(item);
            }
            
            return View(viajesPublicos);
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
                if (viaje.FechaInicio < viaje.FechaFin)
                {
                    if (Session["data"]!=null)
                    {
                        IRepositorio<Viaje> repo = new ViajeRepositorio();
                        repo.Save(viaje);
                        IRepositorioParticipante<Participante> repoPar = new ParticipanteRepositorio();
                        Participante par = new Participante();
                        IRepositorioPersona<Persona> repoPer = new PersonaRepositorio();
                        Persona per = new Persona();
                        per = repoPer.GetById(Session["data"] as String);
                        par.IdViaje = viaje.IdViaje;
                        par.Nickname = per.Nickname;
                        par.Tipo = "creador";
                        par.Viaje = viaje;
                        par.Persona = per;

                        if (repoPar.Save(par))
                        {
                            par.Tipo = "creador";
                        }
                        else
                        {
                            par.Tipo = "creador";
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "La fecha de inicio debe ser menor a la fecha fin.");
                }
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

        public ActionResult VerViajes(String nick)
        {
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            IRepositorioParticipante<Participante> repoP = new ParticipanteRepositorio();
            IList<Viaje> viajes = new List<Viaje>();
            IList<Participante> participantes = repoP.GetAllByNick(nick);

            foreach (var item in participantes)
            {
                viajes.Add(repo.GetById(item.IdViaje));
            }

            return View(viajes); ;
        }


    }
}
