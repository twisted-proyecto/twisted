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
    public class DestinoController : Controller
    {
        public string Descripcion = null;   
        public string Direccion = null; 
        public string Estatus = null;
        public DateTime Fecha;       
        public int IdDestino;       
        public double Latitud;     
        public double Longitud;
        public string Nombre = null;      
        public string Url = null;
        public ISet<Comentario> Comentarios = null;
        public Viaje Viaje = null;

        //
        // GET: /Destino/
        public ActionResult Index(int id,String nada)
        {
            IRepositorio<Destino> repo = new DestinoRepositorio();
            return View(repo.GetAll());
        }

        public ActionResult Details(int id)
        {
            IRepositorio<Destino> repo = new DestinoRepositorio();
            return View(repo.GetById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            IRepositorio<Destino> repo = new DestinoRepositorio();
            return View(repo.GetById(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, Destino Destino)
        {

            IRepositorio<Destino> repo = new DestinoRepositorio();
            repo.Update(Destino);

            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Destino Destino)
        {
            IRepositorio<Destino> repo = new DestinoRepositorio();
            repo.Save(Destino);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            IRepositorio<Destino> repo = new DestinoRepositorio();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }
    }
}
