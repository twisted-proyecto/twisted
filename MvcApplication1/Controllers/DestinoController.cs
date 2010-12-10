using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Repositorios;
using MvcApplication1.Dominio.Model;
using FlickrNet;

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



        static PhotoCollection photos = new PhotoCollection();
        public ActionResult Create()
        {
            ViewData["Message"] = "Buscar destinos:";

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Destino Destino,string Button)
        {
            if (Button == "Agregar Destino")
            {
                IRepositorio<Destino> repo = new DestinoRepositorio();
                repo.Save(Destino);

                return RedirectToAction("Index");
            }
            else {
                var map = new Map();
                UpdateModel(map);
                int i = 0;
                PhotoSearchOptions options = new PhotoSearchOptions();
                //options.BoundaryBox = new BoundaryBox(-1.7, 54.9, -1.4, 55.2); // Roughly Newcastle upon Type, England
                //options.BoundaryBox = BoundaryBox.World;
                options.Extras |= PhotoSearchExtras.Geo;
                options.Tags = map.Name;
                options.HasGeo = true;
                options.PerPage = 5;
                Flickr flickr = new Flickr("3de826e278b4988011ef0227585a7838", "81a96df44a82b16c");
                photos = flickr.PhotosSearch(options);
                foreach (Photo photo in photos)
                {
                    ViewData["Message"] = String.Format("Lugares de \"{0}\".", map.Name);
                    ViewData.Add(("Message" + i), photo.ThumbnailUrl);
                    i++;
                }
                
                return View();
            }
        }

        public ActionResult Map()
        {
            var mapRepository = new MapRepository();
            var map = new Map();
            if (photos.Count == 0)
                map = mapRepository.SetRepositories();
            else
                map = mapRepository.SetRepositories(photos);

            return Json(map, "1",JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult About()
        {
            return View();
        }

   
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

        public ActionResult Delete(int id)
        {
            IRepositorio<Destino> repo = new DestinoRepositorio();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }
    }
}
