using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Dominio.Repositorios;
using System.Net.Mail;

namespace MvcApplication1.Controllers
{
    public class PersonaController : Controller
    {


        public ActionResult Index()
        {
            if (Session["data"] != null)
            {
                string nick = Session["data"] as string;
                IRepositorioPersona<Persona> repo = new PersonaRepositorio();
                IList<Persona> milista = repo.GetByPrivacidad("Publico");
                Persona miPersona = repo.GetById(nick);
                if (miPersona.Privacidad != "Publico")
                    milista.Add(miPersona);
                return View(milista);
            }
            else
            {
                IRepositorioPersona<Persona> repo = new PersonaRepositorio();
                IList<Persona> milista = repo.GetByPrivacidad("Publico");
                return View(milista);
            }
        }


        public ActionResult Verificar()
        {
            string nick = Session["data"] as string;
            IRepositorioPersona<Persona> repo = new PersonaRepositorio();
            if (repo.GetById(nick) != null)
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("Create", "Persona");

        }

        public ActionResult Details(String id)
        {
            IRepositorioPersona<Persona> repo = new PersonaRepositorio();
            return View(repo.GetById(id));
        }

        //
        // GET: /Persona/Create

        public ActionResult Create()
        {
            IEnumerable<string> items = new string[] { "Publico", "Privado" };
            ViewData["Privacidad"] = new SelectList(items);
            return View();
        }

        //
        // POST: /Persona/Create

        [HttpPost]
        public ActionResult Create(Persona Persona, String id)
        {
            if (ModelState.IsValid)
            {
                if (Session["data"] != null)
                    Persona.Nickname = Session["data"] as string;

                IRepositorioPersona<Persona> repo = new PersonaRepositorio();
                repo.Save(Persona);


                return RedirectToAction("Correo", Persona);
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            IEnumerable<string> items = new string[] { "Publico", "Privado" };
            ViewData["Privacidad"] = new SelectList(items);
            return View(Persona);
        }

        //
        // GET: /Persona/Edit/5

        public ActionResult Edit(String id)
        {
            IEnumerable<string> items = new string[] { "Publico", "Privado" };
            ViewData["Privacidad"] = new SelectList(items);
            IRepositorioPersona<Persona> repo = new PersonaRepositorio();
            return View(repo.GetById(id));
        }

        //
        // POST: /Persona/Edit/5

        [HttpPost]
        public ActionResult Edit(String id, Persona Persona)
        {
            if (ModelState.IsValid)
            {
                Persona.Nickname = id;
                IRepositorioPersona<Persona> repo = new PersonaRepositorio();
                repo.Update(Persona);

                return RedirectToAction("Index");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            IEnumerable<string> items = new string[] { "Publico", "Privado" };
            ViewData["Privacidad"] = new SelectList(items);
            return View(Persona);
        }

        //
        // GET: /Persona/Delete/5

        public ActionResult Delete(String id)
        {
            IRepositorioPersona<Persona> repo = new PersonaRepositorio();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        //
        // POST: /Persona/Delete/5

        [HttpPost]
        public ActionResult Delete(String id, Persona Persona)
        {
            if (ModelState.IsValid)
            {
                Persona.Nickname = id;
                IRepositorioPersona<Persona> repo = new PersonaRepositorio();
                repo.Delete(Persona);

                return RedirectToAction("Index");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario

            return View(Persona);
        }

        public ActionResult Correo(Persona p)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(p.Email);
            msg.From = new MailAddress("twisted.j2l@gmail.com", "Twisted", System.Text.Encoding.UTF8);
            msg.Subject = "Bienvenido a Twisted ";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Hola " + p.Nombre + " " + p.Apellido + " bienvenido a Twisted\nTe invitamos a Seguirnos @TwistedUCAB  \n\nSaludos, \nj2l Team © ";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("twisted.j2l@gmail.com", "j2ltwisted");
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
            return RedirectToAction("Index");
        }


    }
}
