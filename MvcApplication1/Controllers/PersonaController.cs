using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Dominio.Repositorios;
using System.Net.Mail;
using System.Web.Security;
using System.Web.Routing;

namespace MvcApplication1.Controllers
{
    public class PersonaController : Controller
    {
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }


        public ActionResult Index()
        {
            if (Session["data"] != null)
            {
                string nick = Session["data"] as string;
                IRepositorioPersona<Persona> repo = new PersonaRepositorio();
                IList<Persona> milista = repo.GetByPrivacidad("Publico");
                Persona miPersona = repo.GetById(nick);
                if (miPersona != null)
                {
                    milista.Remove(miPersona);
                }
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
            {
                FormsService.SignIn(nick, false /* createPersistentCookie */);
                return RedirectToAction("Index", "Home");
            }
            
            return RedirectToAction("Create", "Persona");

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
                MembershipCreateStatus createStatus = MembershipService.CreateUser(Persona.Nickname, "12345678", Persona.Email);
                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(Persona.Nickname, false /* createPersistentCookie */);
                }
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
            IEnumerable<string> items2 = new string[] { "Activo", "Desactivado" };
            ViewData["Estatus"] = new SelectList(items2);
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

                return RedirectToAction("Index","Home");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            IEnumerable<string> items = new string[] { "Publico", "Privado" };
            ViewData["Privacidad"] = new SelectList(items);
            IEnumerable<string> items2 = new string[] { "Activo", "Desactivado" };
            ViewData["Estatus"] = new SelectList(items2);
            return View(Persona);
        }

        //
        // GET: /Persona/Delete/5

        public ActionResult Delete(String id)
        {
            Session.Remove("data");
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

        public ActionResult Viajes(String id)
        {

            return RedirectToAction("VerViajes", "Viaje", new { nick = id });
        }

        public ActionResult Amigos(String id)
        {

            return RedirectToAction("VerAmigos", "Persona", new { nick = id });
        }

        public ActionResult Invitar(int id)
        {

            return RedirectToAction("InvitarAmigos", "Persona", new { id = id });
        }

        public ActionResult AgregarAmigo(String id)
        {
            Persona persona = new Persona();
            if (ModelState.IsValid)
            {
                
                if (Session["data"] != null)
                    persona.Nickname = Session["data"] as string;

                Persona amigo = new Persona();
                IRepositorioPersona<Persona> repo = new PersonaRepositorio();
                amigo = repo.GetById(id);
                Amistad amistad = new Amistad();
                amistad.Nickname = persona.Nickname;
                amistad.NicknameAmigo = id;
                amistad.Fecha = System.DateTime.Today;
                persona = repo.GetById(persona.Nickname);
                amistad.Persona1 = persona;
                amistad.Persona = amigo;
                IRepositorio<Amistad> repoAmistad = new AmistadRepositorio();
                repoAmistad.Save(amistad);
                return RedirectToAction("CorreoAmistad", "Persona", new { personaNick = persona.Nickname, amigoNick = amigo.Nickname });    
            }
            return RedirectToAction("Index", "Persona");
        }

        public ActionResult VerAmigos(String nick)
        {
            IRepositorio<Amistad> repo = new AmistadRepositorio();
            IRepositorioPersona<Persona> repoP = new PersonaRepositorio();
            IList<Amistad> amistades= repo.GetAll();
            IList<Persona> amigos = new List<Persona>();
            
            foreach (var item in amistades)
            {
                if (item.Nickname == nick)
                {
                    amigos.Add(repoP.GetById(item.NicknameAmigo));
                }
            }
            return View(amigos); ;
        }


        public ActionResult InvitarAmigos(int id)
        {
            string nick = Session["data"] as string;

            IRepositorio<Amistad> repo = new AmistadRepositorio();
            IRepositorioPersona<Persona> repoPer = new PersonaRepositorio();
            IList<Amistad> amistades = repo.GetAll();
            IList<Persona> amigos = new List<Persona>();

            foreach (var item in amistades)
            {
                if (item.Nickname == nick)
                {
                    amigos.Add(repoPer.GetById(item.NicknameAmigo));
                }
            }

            IRepositorioPersona<Persona> repoP = new PersonaRepositorio();
            IRepositorioParticipante<Participante> repoParti = new ParticipanteRepositorio();
            IList<Participante> participantes = new List<Participante>();
            IList<Participante> participantesV = new List<Participante>();
            IList<Persona> amigosNoInv = new List<Persona>();
  
            participantes = repoParti.GetAll();

            foreach (var item in participantes)
            {
                if (item.IdViaje == id)
                {
                    participantesV.Add(item);
                }
            }


            bool flag = false;
            foreach (var item in amigos)
            {
                foreach (var itemPar in participantesV)
                {
                    if (item.Nickname == itemPar.Nickname)
                    {
                        flag = true;
                    }
                }

                if (!flag)
                {
                  amigosNoInv.Add(repoP.GetById(item.Nickname));   
                }
                flag = false;
            }
            Session["idViajeInvitado"] = id;
            return View(amigosNoInv);
        }

        public MvcHtmlString EsAmigo(String nick)
        {
            IRepositorio<Amistad> repo = new AmistadRepositorio();
            IRepositorioPersona<Persona> repoP = new PersonaRepositorio();
            IList<Amistad> amistades = repo.GetAll();

            foreach (var item in amistades)
            {
                if (item.Nickname == (string) Session["data"])
                {
                    if(item.NicknameAmigo == nick)
                    {
                        return MvcHtmlString.Create("true");
                    }
                }
            }
            return MvcHtmlString.Create("false");
        }

        public ActionResult EliminarAmigo(String nick)
        {
            IRepositorio<Amistad> repo = new AmistadRepositorio();
            IRepositorioPersona<Persona> repoP = new PersonaRepositorio();
            IList<Amistad> amistades = repo.GetAll();

            foreach (var item in amistades)
            {
                if (item.Nickname == (string)Session["data"])
                {
                    if (item.NicknameAmigo == nick)
                    {
                        repo.Delete(item);
                    }
                }
            }
            return RedirectToAction("Index", "Persona");
        }

        public ActionResult InvitarAmigoViaje(string nick, int idViaje)
        {
            IRepositorioParticipante<Participante> repoP = new ParticipanteRepositorio();
            Participante miParticipante = new Participante();
            miParticipante.IdViaje = idViaje;
            miParticipante.Nickname = nick;
            miParticipante.Tipo = "Participante";
            repoP.Save(miParticipante);
            return RedirectToAction("InvitarAmigos", "Persona", new { id = idViaje });
        }


        public ActionResult consultarInvitados(int idViaje)
        {
            IRepositorioParticipante<Participante> repoParti = new ParticipanteRepositorio();
            IRepositorioPersona<Persona> repoP = new PersonaRepositorio();
            IList<Participante> participantes = new List<Participante>();
            IList<Persona> personas = new List<Persona>();
           
            participantes = repoParti.GetAll();

            foreach (var item in participantes)
            {
                if (item.IdViaje == idViaje)
                {
                    personas.Add(repoP.GetById(item.Nickname));
                }
            }


            return View("VerAmigos", personas);
        }

        public ActionResult CorreoAmistad(String personaNick, String amigoNick)
        {
            IRepositorioPersona<Persona> repoP = new PersonaRepositorio();
            Persona persona = repoP.GetById(personaNick);
            Persona amigo = repoP.GetById(amigoNick);
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(amigo.Email);
            msg.From = new MailAddress("twisted.j2l@gmail.com", "Twisted", System.Text.Encoding.UTF8);
            msg.Subject = persona.Nombre + " " + persona.Apellido + " ahora es tu amigo!";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Hola " + amigo.Nombre + " " + amigo.Apellido + ", \n\n" + persona.Nombre + " " + persona.Apellido + " te agrego como amigo en Twisted,\nahora el podra ver tus viajes privados y publicos e invitarte a viajes planificados por el.\nGracias!\n\nTe invitamos a Seguirnos @TwistedUCAB  \n\nSaludos, \nj2l Team Â© ";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            //AquÃ­ es donde se hace lo especial
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
            return RedirectToAction("Index", "Persona");
        }

    }
}
