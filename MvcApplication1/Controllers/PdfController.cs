using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Dominio.Repositorios;
using Winnovative.WnvHtmlConvert;

namespace MvcApplication1.Controllers
{
    public class PdfController : Controller
    {
        //
        // GET: /Pdf/

        private ImgConverter GetImgConverter()
        {
            ImgConverter imgConverter = new ImgConverter();

            imgConverter.LicenseKey = "Q2hzY3Jjc2N3bXNjcHJtcnFtenp6eg==";


            imgConverter.ScriptsEnabled = true;

            return imgConverter;
        }

        private System.Drawing.Imaging.ImageFormat GetImageFormat(RenderImageFormat format)
        {
            switch (format)
            {
                case RenderImageFormat.Bmp:
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                case RenderImageFormat.Gif:
                    return System.Drawing.Imaging.ImageFormat.Gif;
                case RenderImageFormat.Jpeg:
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case RenderImageFormat.Png:
                    return System.Drawing.Imaging.ImageFormat.Png;
                case RenderImageFormat.Tiff:
                    return System.Drawing.Imaging.ImageFormat.Tiff;
                default:
                    return System.Drawing.Imaging.ImageFormat.Bmp;
            }
        }


        private PdfStandardSubset GetPdfStandard(string standardName)
        {
            switch (standardName)
            {
                case "PDF":
                    return PdfStandardSubset.Full;
                default:
                    return PdfStandardSubset.Full;

            }
        }

        private PdfConverter GetPdfConverter()
        {
            PdfConverter pdfConverter = new PdfConverter();

            pdfConverter.LicenseKey = "Q2hzY3Jjc2N3bXNjcHJtcnFtenp6eg==";

            
                pdfConverter.PageWidth = 0; // autodetect the HTML page width
            

            // set if the generated PDF contains selectable text or an embedded image - default value is true
            pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = true;

            //set the PDF page size 
         
            // set the PDF compression level
          
            // set the PDF page orientation (portrait or landscape)
        
            //set the PDF standard used to generate the PDF document
            pdfConverter.PdfStandardSubset = GetPdfStandard("PDF");
            // show or hide header and footer
            pdfConverter.PdfDocumentOptions.ShowHeader = true;
            pdfConverter.PdfDocumentOptions.ShowFooter = true;
            //set the PDF document margins
           
            // set if the HTTP links are enabled in the generated PDF
            pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = false;
            // set if the HTML content is resized if necessary to fit the PDF page width - default is true
            pdfConverter.PdfDocumentOptions.FitWidth = true;
            // set if the PDF page should be automatically resized to the size of the HTML content when FitWidth is false
            pdfConverter.PdfDocumentOptions.AutoSizePdfPage = true;
            // embed the true type fonts in the generated PDF document
            pdfConverter.PdfDocumentOptions.EmbedFonts = true;
            // compress the images in PDF with JPEG to reduce the PDF document size - default is true
            pdfConverter.PdfDocumentOptions.JpegCompressionEnabled = true;
            // set if the JavaScript is enabled during conversion 
            pdfConverter.ScriptsEnabled = pdfConverter.ScriptsEnabledInImage = true;

            // set if the converter should try to avoid breaking the images between PDF pages
            pdfConverter.AvoidImageBreak = true;
            
            pdfConverter.PdfFooterOptions.DrawFooterLine = true;
            
            pdfConverter.PdfFooterOptions.ShowPageNumber = true;

            
            return pdfConverter;
        }


        public ActionResult Pdf()
        {
            String idViaje = Session["idViajePdf"] as string;
            string urlToConvert = "http://localhost/MvcApplication1/Viaje/ViajeDestinosReporte?idViaje=" + idViaje;
            string downloadName = "Viaje";
            byte[] downloadBytes = null;
            downloadName += ".pdf";
            PdfConverter pdfConverter = GetPdfConverter();
            downloadBytes = pdfConverter.GetPdfBytesFromUrl(urlToConvert);
            
            if (Session["data"] != "")
            {
                using (
                    System.IO.Stream s =
                        System.IO.File.Create(@"c:\inetpub\wwwroot\Pdf\" + Session["data"] + "Viaje" + idViaje +
                                              ".pdf"))
                {
                    s.Write(downloadBytes, 0, downloadBytes.Length);
                }

            }
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }

            string url = "http://" + localIP + "/Pdf/" + Session["data"] + "Viaje" + idViaje +".pdf";
            string urlCorto = Shorten(url);

            IRepositorioPersona<Persona> repoP = new PersonaRepositorio();
            IRepositorioParticipante<Participante> repoParti = new ParticipanteRepositorio();
            IList<Participante> participantes = new List<Participante>();
            IList<Participante> participantesV = new List<Participante>();
            

            participantes = repoParti.GetAll();

            foreach (var item in participantes)
            {
                if (item.IdViaje == Convert.ToInt32(idViaje))
                {
                    participantesV.Add(item);
                }
            }

            IList<Persona> perList = new List<Persona>();

            foreach (var item in participantesV)
            {
                perList.Add(repoP.GetById(item.Nickname));
            }

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            foreach (var persona in perList)
            {
                msg.To.Add(persona.Email);
            }
            IRepositorio<Viaje> repov = new ViajeRepositorio();
            Viaje v = repov.GetById(Convert.ToInt32(idViaje));

            msg.From = new MailAddress("twisted.j2l@gmail.com", "Twisted", System.Text.Encoding.UTF8);
            msg.Subject = "Ha sido cerrado el Viaje " + v.Nombre;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Body = "Hola , \n\n El Viaje " + v.Nombre + " Ha Sido Cerrado.\n Este es el Url del PDF que Contine La hoja de Ruta "+urlCorto+".\nGracias!\n\nTe invitamos a Seguirnos @TwistedUCAB  \n\nSaludos, \nj2l Team Â© ";
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = false;
            String twt = "El viaje "+ v.Nombre +" Ha Sido Cerrado Este el itinerario " + urlCorto;

            Session["twt"] = twt;
            //AquÃ­ es donde se hace lo especial
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("twisted.j2l@gmail.com", "j2ltwisted");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            HttpResponse response = System.Web.HttpContext.Current.Response;
            
         /*   response.Clear();
            response.AddHeader("Content-Type", "binary/octet-stream");
            response.AddHeader("Content-Disposition",
                "attachment; filename=" + downloadName + "; size=" + downloadBytes.Length.ToString());
            response.BinaryWrite(downloadBytes);
            response.Flush();
            response.End();*/
            
            
            return RedirectToAction("CerrarViaje", "Twitter");
        }


        private const string key = "AIzaSyAgLthbi1epnLoVoVfRtLvbQOESdK5KDi8";

        public static string Shorten(string url)
        {
            string post = "{\"longUrl\": \"" + url + "\"}";
            string shortUrl = url;
            HttpWebRequest request =
                (HttpWebRequest) WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url?key=" + key);

            try
            {
                request.ServicePoint.Expect100Continue = false;
                request.Method = "POST";
                request.ContentLength = post.Length;
                request.ContentType = "application/json";
                request.Headers.Add("Cache-Control", "no-cache");

                using (Stream requestStream = request.GetRequestStream())
                {
                    byte[] postBuffer = Encoding.ASCII.GetBytes(post);
                    requestStream.Write(postBuffer, 0, postBuffer.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream))
                        {
                            string json = responseReader.ReadToEnd();
                            shortUrl = Regex.Match(json, @"""id"": ?""(?<id>.+)""").Groups["id"].Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // if Google's URL Shortner is down...
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return shortUrl;
        }


    }
}
