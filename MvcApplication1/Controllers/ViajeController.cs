using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Repositorios;
using MvcApplication1.Dominio.Model;

namespace MvcApplication1.Controllers
{
    public class ViajeController : Controller
    {
        private string nombre = null;
        private DateTime fechaI;
        private DateTime fechaF;
        private string destino = null;
        private string hospedaje = null;
        private string privacidad = null;

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

        public ActionResult Edit(int id)
        {
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            return View(repo.GetById(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formCollection)
        {
            nombre = formCollection.Get("Nombre");
            fechaI = System.Convert.ToDateTime(formCollection.Get("fechaInicio"));
            if (formCollection.Get("fechaFin").CompareTo("") != 0)
                fechaF = System.Convert.ToDateTime(formCollection.Get("fechaFin"));
            destino = formCollection.Get("Destino");
            hospedaje = formCollection.Get("Hospedaje");
            privacidad = formCollection.Get("Privacidad");

            Viaje Viaje = new Viaje();
            Viaje.IdViaje = id;
            Viaje.Nombre = nombre;
            Viaje.FechaInicio = fechaI;
            Viaje.FechaFin = fechaF;
            Viaje.Destino = destino;
            Viaje.Hospedaje = hospedaje;
            Viaje.Privacidad = privacidad;


            IRepositorio<Viaje> repo = new ViajeRepositorio();
            repo.Update(Viaje);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection formCollection)
        {
            nombre = formCollection.Get("Nombre");
            fechaI = System.Convert.ToDateTime(formCollection.Get("fechaInicio"));
            if (formCollection.Get("fechaFin").CompareTo("") != 0)
                fechaF = System.Convert.ToDateTime(formCollection.Get("fechaFin"));
            destino = formCollection.Get("Destino");
            hospedaje = formCollection.Get("Hospedaje");
            privacidad = formCollection.Get("Privacidad");
   
            Viaje Viaje = new Viaje();
            Viaje.Nombre = nombre;
            Viaje.FechaInicio = fechaI;
            Viaje.FechaFin = fechaF;
            Viaje.Destino = destino;
            Viaje.Hospedaje = hospedaje;
            Viaje.Privacidad = privacidad;
   
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            repo.Save(Viaje);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }
    }
}
