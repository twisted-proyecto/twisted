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
        public Viaje viaje;
        private IRepositorio<Viaje> repoViaje;


        static PhotoCollection photos = new PhotoCollection();
        public ActionResult Create(int idViaje)
        {
            int id2 = idViaje;
            ViewData["idViaje"] = id2;
            ViewData["Message"] = "Buscar destinos:";
            return View( );
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Destino Destino,string Button, int idViaje)
        {
            var map = new Map();
            UpdateModel(map);
            if (Button == "Agregar Destino")
            {
                IRepositorio<Destino> repo = new DestinoRepositorio();
                IRepositorio<Viaje> repoViaje = new ViajeRepositorio();
                Destino.Viaje = repoViaje.GetById(idViaje);
                PhotoSearchOptions options = new PhotoSearchOptions();
                options.Extras |= PhotoSearchExtras.Geo;
                options.Tags = map.Name;
                options.HasGeo = true;
                options.PerPage = 24;
                Flickr flickr = new Flickr("3de826e278b4988011ef0227585a7838", "81a96df44a82b16c");
                photos = flickr.PhotosSearch(options);
                foreach (Photo photo in photos)
                {
                    if (Destino.Url.CompareTo(photo.SmallUrl) == 0)
                    {
                        Destino.Latitud = photo.Latitude;
                        Destino.Longitud = photo.Longitude;
                        Destino.Nombre = photo.Title;
                    }
                }
                repo.Save(Destino);
                int id2 = idViaje;
                ViewData["idViaje"] = id2;
                return RedirectToAction("Index", "Destino", new { idViaje = id2 });
            }
            else {
                int i = 0;
                PhotoSearchOptions options = new PhotoSearchOptions();
                //options.BoundaryBox = new BoundaryBox(-1.7, 54.9, -1.4, 55.2); // Roughly Newcastle upon Type, England
                //options.BoundaryBox = BoundaryBox.World;
                options.Extras |= PhotoSearchExtras.Geo;
                options.Tags = map.Name;
                options.HasGeo = true;
                options.PerPage = 24;
                Flickr flickr = new Flickr("3de826e278b4988011ef0227585a7838", "81a96df44a82b16c");
                photos = flickr.PhotosSearch(options);
                foreach (Photo photo in photos)
                {
                    ViewData["Message"] = String.Format("Lugares de \"{0}\".", map.Name);
                    ViewData.Add(("Message" + i), photo.SmallUrl);
                    i++;
                }
                int id2 = idViaje;
                ViewData["idViaje"] = id2;
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
        
        //
        // GET: /Destino/
        public ActionResult Index(int idViaje)
        {
            int id2 = idViaje;
            ViewData["idViaje"] = id2;
            IRepositorio<Destino> repo = new DestinoRepositorio();
            IList<Destino> destinos = repo.GetAll();
            IList<Destino> destinosViaje = new List<Destino>();

            foreach (Destino destino in destinos)
            {
                if (destino.Viaje.IdViaje == id2)
                {
                    destinosViaje.Add(destino);
                }
            }

           
            return View(destinosViaje);
        }

        public ActionResult Details(int id, int idViaje)
        {
            int id2 = idViaje;
            ViewData["idViaje"] = id2;
            IRepositorio<Destino> repo = new DestinoRepositorio();
            return View(repo.GetById(id));
        }


        public ActionResult Edit(int id, int idViaje)
        {
            int id2 = idViaje;
            ViewData["idViaje"] = id2;
            IRepositorio<Destino> repo = new DestinoRepositorio();
            return View(repo.GetById(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Destino Destino, int id, int idViaje)
        {
            IRepositorio<Viaje> repoViaje = new ViajeRepositorio();
            Destino.Viaje = repoViaje.GetById(idViaje);
            IRepositorio<Destino> repo = new DestinoRepositorio();
            repo.Update(Destino);
            int id2 = idViaje;
            ViewData["idViaje"] = id2;
            return RedirectToAction("Index", "Destino", new { idViaje = id2 });
        }

        public ActionResult Delete(int id, int idViaje)
        {
            IRepositorio<Viaje> repoViaje = new ViajeRepositorio();
            IRepositorio<Destino> repo = new DestinoRepositorio();
            Destino Destino = repo.GetById(id);
            Destino.Viaje = repoViaje.GetById(idViaje);
            repo.Delete(Destino);
            int id2 = idViaje;
            ViewData["idViaje"] = id2;
            return RedirectToAction("Index", "Destino", new { idViaje = id2 });
        }
       
    }
}
