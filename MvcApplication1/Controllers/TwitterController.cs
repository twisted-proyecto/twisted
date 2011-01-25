using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Repositorios;


namespace MvcApplication1.Controllers
{
  
       
    public class TwitterController : Controller
    {
       
        
        public ActionResult Index()
        {
            string url = "";
            string xml = "";
            oAuthTwitter oAuth = new oAuthTwitter();

            if (Request["oauth_token"] == null)
            {
                //Redirect the user to Twitter for authorization.
                //Using oauth_callback for local testing.
                oAuth.CallBackUrl = "http://localhost/MvcApplication1/Twitter";
                Response.Redirect(oAuth.AuthorizationLinkGet());
            }
            else
            {
                //Get the access token and secret.
                oAuth.AccessTokenGet(Request["oauth_token"], Request["oauth_verifier"]);
                if (oAuth.TokenSecret.Length > 0)
                {
                    //We now have the credentials, so make a call to the Twitter API.
                    url = "http://twitter.com/account/verify_credentials.xml";
                    xml = oAuth.oAuthWebRequest(oAuthTwitter.Method.GET, url, String.Empty);
                    //apiResponse.InnerHtml = Server.HtmlEncode(xml);
                    String parametroApertura = "<screen_name>";
                    String parametroCierre = "</screen_name>";
                    String xmlParseado = parsear(xml, parametroApertura, parametroCierre);

                    ViewData["XML"] = xmlParseado;
                    ViewData["login"] = "Logeado Correctamente Como...";
                    Session.Timeout = 5;
                    Session["data"] = xmlParseado;
                    //POST Test
                    IRepositorioPersona<Persona> repo = new PersonaRepositorio();
                    Persona p = repo.GetById(xmlParseado);
                    if (p == null)
                    {
                        url = "http://twitter.com/statuses/update.xml";
                        xml = oAuth.oAuthWebRequest(oAuthTwitter.Method.POST, url,"status=" +oAuth.UrlEncode("Yo, ya me uni a la red @TwistedUCAB ... que esperas Unete! y comparte tus viajes tambien."));
                    }
                
                //apiResponse.InnerHtml = Server.HtmlEncode(xml);
                    XmlSiteMapProvider my = new XmlSiteMapProvider();
                    return RedirectToAction("Verificar", "Persona");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public String parsear(String xml, String parametroApertura, String parametroCierre) {

            int tamanioParametro = parametroApertura.Length;
            int indexApertura = xml.IndexOf(parametroApertura);
            int indexCierre = xml.IndexOf(parametroCierre);
            indexApertura += parametroApertura.Length;
            indexCierre -= indexApertura;
            String xmlParseado = xml.Substring(indexApertura, indexCierre);
            return xmlParseado;
        }

        public ActionResult LogOut()
        {
            Session.Remove("data");
            return RedirectToAction("Index", "Home");
        }

    }

}
