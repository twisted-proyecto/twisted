using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Dominio.Repositorios;
using FlickrNet;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Dominio;


namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        static PhotoCollection photos = new PhotoCollection();
        public ActionResult Index()
        {
            ViewData["Message"] = "Buscar destinos:";
            
            
            return View();
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(FormCollection form)
        {
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
        public ActionResult Map()
        {
            var mapRepository = new MapRepository();
            var map = new Map();
            if (photos.Count == 0)
                map = mapRepository.SetRepositories();
            else
                map = mapRepository.SetRepositories(photos);
            return Json(map, JsonRequestBehavior.AllowGet);
        }




        public ActionResult About()
        {
           return View();
        }

   

    }
}
