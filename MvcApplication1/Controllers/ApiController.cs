using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Xml;
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
            if (Request["idviaje"] != "")
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
                        if (destino.Fecha != null)
                            
                            destinosViaje.Add(new DestinoXml
                                                  {
                                                      Descripcion = destino.Descripcion,
                                                      Direccion = destino.Direccion,
                                                      Fecha = (DateTime) destino.Fecha,
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
                if (viaje != null)
                {
                    ViajeXml[] v = new[]
                                       {
                                           new ViajeXml
                                               {
                                                   Destino = viaje.Destino,
                                                   FechaInicio = viaje.FechaInicio,
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
            }
            return View();
        }

        [FormatFilter]
        public ActionResult DatosPersona()
        {
            if (Request["nickname"] != null)
            {
                string nick = Request["nickname"] as string;
                IRepositorioPersona<Persona> repoPer = new PersonaRepositorio();
                Persona per = repoPer.GetById(nick);
                if (per != null)
                {
                    PersonaXml[] personaXml = new[]
                                                  {
                                                      new PersonaXml
                                                          {
                                                              nombre = per.Nombre,
                                                              apellido = per.Apellido,
                                                              email = per.Email,
                                                              fechaNacimiento = per.FechaNacimiento,
                                                              nickname = per.Nickname
                                                          }
                                                  };

                    return View(personaXml);
                }
            }
            return View();
        }

        [FormatFilter]
        public ActionResult ViajesPersona()
        {
            if (Request["nickname"] != null)
            {
                string nick = Request["nickname"] as string;
                IRepositorioParticipante<Participante> repoPar = new ParticipanteRepositorio();
                IList<Participante> participaciones = repoPar.GetAllByNick(nick);
                if(participaciones!=null)
                {
                    IList<int> idsList = new List<int>();
                    foreach (var participacione in participaciones)
                        idsList.Add(participacione.IdViaje);
                    int[] IdViaje = idsList.ToArray();
                    return View(IdViaje);
                }
            }
            return View();
        }

        public ActionResult MostrarViaje(String Url)
        {

            if (ValidateUrl(Url))
            {
                String xml = WebRequest(oAuthTwitter.Method.GET, Url, String.Empty);
                if (xml != "")
                {
                    XmlDocument myXmlDocument = new XmlDocument();
                    myXmlDocument.LoadXml(xml);
                    myXmlDocument.Normalize();

                    XmlNodeList myNodeList = myXmlDocument.GetElementsByTagName("ViajeXml");
                    
                    IList<Viaje> viajes = new List<Viaje>();
                    IList<Destino> destinos = new List<Destino>();
                    var viaje = new Viaje();
                    foreach (XmlNode nodo in myNodeList)
                    {
                        
                        viaje.Destino = nodo.ChildNodes[0].InnerText;
                        viaje.Nombre = nodo.ChildNodes[5].InnerText;
                        viaje.FechaFin = DateTime.Parse(nodo.ChildNodes[1].InnerText);
                        viaje.FechaInicio = DateTime.Parse(nodo.ChildNodes[2].InnerText);
                        viaje.Hospedaje = nodo.ChildNodes[3].InnerText;
                        viaje.IdViaje = Int32.Parse(nodo.ChildNodes[4].InnerText);
                        viaje.Privacidad = nodo.ChildNodes[6].InnerText;
                        XmlNodeList myNodeList2 = nodo.ChildNodes[7].ChildNodes;
                        
                        foreach (XmlNode nodo2 in myNodeList2)
                        {
                            Destino destino = new Destino();
                            destino.Descripcion =nodo2.ChildNodes[0].InnerText;
                            destino.Direccion = nodo2.ChildNodes[1].InnerText;
                            destino.Fecha = DateTime.Parse(nodo2.ChildNodes[2].InnerText);
                            destinos.Add(destino);
                        }
                        viaje.Destinos = destinos;


                    }

                    
                    
                    return View(viaje);
                }
            }
            return View();
        }

        public ActionResult MostrarViaje3(String Url)
        {

            if (ValidateUrl(Url))
            {
                String xml = WebRequest(oAuthTwitter.Method.GET, Url, String.Empty);
                if (xml != "")
                {
                    XmlDocument myXmlDocument = new XmlDocument();
                    myXmlDocument.LoadXml(xml);
                    myXmlDocument.Normalize();

                    XmlNodeList myNodeList = myXmlDocument.GetElementsByTagName("trip");

                    
                    var viaje = new Viaje();
                    foreach (XmlNode nodo in myNodeList)
                    {
                        viaje.FechaFin = DateTime.Parse(nodo.ChildNodes[4].InnerText);
                        viaje.FechaInicio = DateTime.Parse(nodo.ChildNodes[7].InnerText);
                        viaje.Hospedaje = nodo.ChildNodes[5].InnerText;
                        viaje.IdViaje = Int32.Parse(nodo.ChildNodes[1].InnerText);
                    }



                    return View(viaje);
                }
            }
            return View();
        }

        public ActionResult MostrarViaje2(String Url)
        {

            if (ValidateUrl(Url))
            {
                String xml = WebRequest(oAuthTwitter.Method.GET, Url, String.Empty);
                if (xml != "")
                {
                    XmlDocument myXmlDocument = new XmlDocument();
                    myXmlDocument.LoadXml(xml);
                    myXmlDocument.Normalize();

                    XmlNodeList myNodeList = myXmlDocument.GetElementsByTagName("itinerary");

                    IList<Viaje> viajes = new List<Viaje>();
                    IList<Destino> destinos = new List<Destino>();
                    var destino = new Destino();
                    foreach (XmlNode nodo in myNodeList)
                    {
                        destino.Direccion = nodo.ChildNodes[6].InnerText;
                        destino.Descripcion = nodo.ChildNodes[2].InnerText;
                        destino.Fecha = DateTime.Parse(nodo.ChildNodes[8].InnerText);
                        destino.Url = nodo.ChildNodes[4].InnerText;
                      //  XmlNodeList myNodeList2 = nodo.ChildNodes[7].ChildNodes;

                        /*foreach (XmlNode nodo2 in myNodeList2)
                        {
                            Destino destino = new Destino();
                            destino.Descripcion = nodo2.ChildNodes[0].InnerText;
                            destino.Direccion = nodo2.ChildNodes[1].InnerText;
                            destino.Fecha = DateTime.Parse(nodo2.ChildNodes[2].InnerText);
                            destinos.Add(destino);
                        }
                        viaje.Destinos = destinos;*/


                    }



                    return View(destino);
                }
            }
            return View();
        }



        public static bool ValidateUrl(string url)
        {
            if (url == null || url == "") return false;

            Regex oRegExp = new Regex(@"(http)://", RegexOptions.IgnoreCase);
            return oRegExp.Match(url).Success;
        }

        public string WebRequest(oAuthTwitter.Method method, string url, string postData)
        {
            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";
            
            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            //webRequest.UserAgent  = "Identify your application please.";
            //webRequest.Timeout = 20000;

            if (method == oAuthTwitter.Method.POST || method == oAuthTwitter.Method.DELETE)
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";

                //POST the data.
                requestWriter = new StreamWriter(webRequest.GetRequestStream());
                try
                {
                    requestWriter.Write(postData);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    requestWriter.Close();
                    requestWriter = null;
                }
            }

            responseData = WebResponseGet(webRequest);

            webRequest = null;

            return responseData;

        }

        /// <summary>
        /// Process the web response.
        /// </summary>
        /// <param name="webRequest">The request object.</param>
        /// <returns>The response data.</returns>
        public string WebResponseGet(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }
            catch
            {

            }

            return responseData;
        }


    }
}
