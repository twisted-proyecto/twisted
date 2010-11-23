using System.Collections.Generic;

namespace MvcApplication1.Models
{
    public class Map
    {

        public string Name { get; set; }
        public LatLng LatLng { get; set; }
        public LatLng center { get; set; }
        public int Zoom { get; set; }


        private List<Location>  locations = new List<Location>();

        public List<Location> Locations
        {
            get { return locations; }
            set { locations = value; }
        }
    }
}