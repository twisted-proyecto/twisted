using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Repositorios;
using MvcApplication1.Dominio.Model;
using FlickrNet;
using MvcApplication1.Infrastructure;
using Norm;
using Norm.Collections;

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
        static IList<Destino> destinos = new List<Destino>();

        
        public ActionResult Create(int idViaje)
        {
            int id2 = idViaje;
            ViewData["idViaje"] = id2;
            ViewData["Message"] = "Buscar destinos:";
            return View( );
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Destino Destino,string Button, Map map)
        {
            var idViaje = Convert.ToInt32(Request["idViaje"]);

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
                    if (Destino.Url != null)
                    {
                        if (Destino.Url.CompareTo(photo.SmallUrl) == 0)
                        {
                            Destino.Latitud = photo.Latitude;
                            Destino.Longitud = photo.Longitude;
                            Destino.Nombre = photo.Title;
                        }
                    }else
                    {
                        ModelState.AddModelError(string.Empty,"Es Necesario que escoja una foto!");
                        return View();
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
                
                Flickr flickr = new Flickr("18ead65365e9b505cc7f97abd38a33fe", "1b0f7df21b450da8");
               
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
            Map map;
            if (photos.Count == 0)
                map = mapRepository.SetRepositories();
            else
                map = mapRepository.SetRepositories(photos);
            photos = new PhotoCollection();
            return Json(map, "1",JsonRequestBehavior.AllowGet);
        }

        public ActionResult MapDestino()
        {
            var mapRepository = new MapRepository();
            Map map;
            if (destinos.Count == 0)
                map = mapRepository.SetRepositories();
            else
                map = mapRepository.SetRepositories(destinos);
            destinos = new List<Destino>();
            return Json(map, "1", JsonRequestBehavior.AllowGet);
        }
        
        public void setDestinos(Destino destino)
        {
            destinos.Add(destino);
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
            using (var session = new MongoSession<Category>())
            {
                
                foreach (Destino destino in destinos)
                {
                    if (destino.Viaje.IdViaje == id2)
                    {
                        Destino destino1 = destino;
                        var category = session.Queryable
                          .Where(c => c.IdDestino == destino1.IdDestino)
                          .AsEnumerable();
                        destino.Votos = category!=null ? category.Count() : 0;
                        destinosViaje.Add(destino);
                    }
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



        public ActionResult AgregarVoto(int id2)
        {
            var category = new Category {IdDestino = id2, Nickname = Session["data"] as string, Voto = "1"};

            using (var session = new MongoSession<Category>())
            {
                session.Save(category);
                return RedirectToAction("Index", "Destino", new { idViaje = Session["idViaje"] });
            }
        }

        public MvcHtmlString YaHiceUnVoto(int idDestino)
        {
            using (var session = new MongoSession<Category>())
            {
                IQueryable<Category> categorias = session.Queryable
                    .Where(c => c.Nickname == Session["data"] as string);
                foreach (var categoria in categorias)
                {
                    if (categoria.IdDestino == idDestino)
                        return MvcHtmlString.Create("true");
                }
                return MvcHtmlString.Create("false");
            }
        }
    }
}
