using MvcApplication1.Dominio.Model;
using FlickrNet;
using System.Collections.Generic;

namespace MvcApplication1.Dominio.Repositorios
{
    public class MapRepository
    {
        public Map SetRepositories(PhotoCollection photos)
        {
            List<Location> locations = new List<Location>();
            Location loc = new Location();
            for (int i = 0; i < photos.Count; i++)
            {
                loc.Image = photos[i].ThumbnailUrl;
                loc.LatLng = new LatLng { Latitude = photos[i].Latitude, Longitude = photos[i].Longitude };
                loc.Name = photos[i].Title;
                locations.Add(loc);
                loc = new Location();
            }
            return new Map
            {
                Name = "",
                Zoom = 8,
                center = new LatLng { Latitude = photos[0].Latitude, Longitude = photos[0].Longitude },
                LatLng = new LatLng { Latitude = photos[0].Latitude, Longitude = photos[0].Longitude },
                Locations = locations
            };
        }
        public Map SetRepositories(IList<Destino> destinos)
        {
            List<Location> locations = new List<Location>();
            Location loc = new Location();
            for (int i = 0; i < destinos.Count; i++)
            {
                loc.Image = destinos[i].Url;
                loc.LatLng = new LatLng { Latitude = destinos[i].Latitud, Longitude = destinos[i].Longitud };
                loc.Name = destinos[i].Nombre;
                locations.Add(loc);
                loc = new Location();
            }
            return new Map
            {
                Name = "",
                Zoom = 8,
                center = new LatLng { Latitude = destinos[0].Latitud, Longitude = destinos[0].Longitud },
                LatLng = new LatLng { Latitude = destinos[0].Latitud, Longitude = destinos[0].Longitud },
                Locations = locations
            };
        }
        public Map SetRepositories()
        {
            return new Map
            {
                Name = "",
                Zoom = 2,
                center = new LatLng { Latitude = 0, Longitude = 0 },
                LatLng = new LatLng { Latitude = 0, Longitude = 0 },
                Locations = null
            };    
        }
    }
}