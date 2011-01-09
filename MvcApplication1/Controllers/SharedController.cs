using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Dominio.Repositorios;

namespace MvcApplication1.Controllers
{
    public class SharedController : Controller
    {

        public String Detalles(String id)
        {
            IRepositorioPersona<Persona> repo = new PersonaRepositorio();
            return repo.GetById(id).Nombre+' '+repo.GetById(id).Apellido;
        }

    }
}
