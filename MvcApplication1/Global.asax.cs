namespace MvcApplication1
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Nombre de ruta
                "{controller}/{action}/{id}", // URL con parámetros
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Valores predeterminados de parámetro
            );

            routes.MapRoute(
	            "Format",
	            "{controller}/{action}/{id}.{format}",
	            new {id = "", format = ""}
            );

        }

        protected void Application_Start()
        {
            // build the list of themes
            string physicalPath = Server.MapPath("~/content/themes");
            string[] themeDirs = Directory.GetDirectories(physicalPath);
            IList<string> themes = new List<string>();
            foreach (string themeDir in themeDirs)
            {
                string theme = themeDir.Split(new char[] { '\\' }).Last();
                if (theme != "base")
                    themes.Add(theme);
            }

            Application.Add("themes", themes);

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}