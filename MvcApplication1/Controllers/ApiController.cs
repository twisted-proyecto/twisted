using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Dominio.Repositorios;

namespace MvcApplication1.Controllers
{
    public class ApiController : Controller
    {
        private static int _cont;

        [FormatFilter]
        public ActionResult Viaje()
        {
            int idViajeConsulta = Convert.ToInt32(Request["idviaje"]);
            IRepositorio<Destino> repoDes = new DestinoRepositorio();
            IList<Destino> destinos = repoDes.GetAll();
            IList<DestinoXml> destinosViaje = new List<DestinoXml>();
            _cont = 0;
            foreach (Destino destino in destinos)
            {

                if (destino.Viaje.IdViaje == idViajeConsulta)
                {

                    destinosViaje.Add(new DestinoXml
                    {
                        Descripcion = destino.Descripcion,
                        Direccion = destino.Direccion,
                        Fecha = (DateTime)destino.Fecha,
                        IdDestino = destino.IdDestino,
                        Latitud = destino.Latitud,
                        Longitud = destino.Longitud,
                        Nombre = destino.Nombre,
                        UrlFoto = destino.Url
                    });
                    
                }

            }
            DestinoXml[] Dest = destinosViaje.ToArray();
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            Viaje viaje = repo.GetById(idViajeConsulta);
            ViajeXml[] v = new[] {
                                        new ViajeXml 
                                        {
                                        Destino=viaje.Destino, 
                                        FechaInicio  = viaje.FechaInicio,
                                        FechaFin = viaje.FechaFin, 
                                        Hospedaje = viaje.Hospedaje, 
                                        IdViaje = viaje.IdViaje,
                                        Nombre = viaje.Nombre,
                                        Privacidad = viaje.Privacidad,
                                        Destinos = Dest
                                       }
                                    };
            
            return View(v);
        }

        [FormatFilter]
        public ActionResult DatosPersona()
        {
            string nick = Request["nickname"] as string;
            IRepositorioPersona < Persona > repoPer = new PersonaRepositorio();
            Persona per = repoPer.GetById(nick);
            PersonaXml[] personaXml = new[] {
                                            new PersonaXml {
                                                                nombre = per.Nombre,
                                                                apellido = per.Apellido,
                                                                email = per.Email,
                                                                fechaNacimiento = per.FechaNacimiento,
                                                                nickname = per.Nickname
                                                            }
                                        };

            return View(personaXml);
        }

        [FormatFilter]
        public ActionResult ViajesPersona()
        {
            
            string nick = Request["nickname"] as string;
            IRepositorioParticipante<Participante> repoPar = new ParticipanteRepositorio();
            IList<Participante> participaciones = repoPar.GetAllByNick(nick);
            IList<int> idsList = new List<int>();
            foreach (var participacione in participaciones)
            idsList.Add(participacione.IdViaje);
            int[] IdViaje = idsList.ToArray();
            return View(IdViaje);
        }


    }
}
