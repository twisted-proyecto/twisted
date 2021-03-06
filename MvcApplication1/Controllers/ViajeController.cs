﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iesi.Collections.Generic;
using MvcApplication1.Dominio;
using MvcApplication1.Dominio.Repositorios;
using MvcApplication1.Dominio.Model;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class ViajeController : Controller
    {
        //
        // GET: /Viaje/
        public ActionResult Index()
        {
          
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            IList<Viaje> viajes = repo.GetAll();
            IList<Viaje> viajesPublicos = new List<Viaje>();
            foreach (var item in viajes)
            {
                if(item.Privacidad == "Publico")
                  viajesPublicos.Add(item);
            }
            
            return View(viajesPublicos);
        }

        public ActionResult Details(int id)
        {
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            return View(repo.GetById(id));
        }
        
        public ActionResult Create()
        {
            IEnumerable<string> items = new string[] { "Publico", "Privado" };
            ViewData["Privacidad"] = new SelectList(items);
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            IEnumerable<string> items = new string[] {"Publico","Privado"};
            ViewData["Privacidad"] = new SelectList(items);
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                viaje.IdViaje = id;
                IRepositorio<Viaje> repo = new ViajeRepositorio();
                repo.Update(viaje);

                return RedirectToAction("Index");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            IEnumerable<string> items = new string[] { "Publico", "Privado" };
            ViewData["Privacidad"] = new SelectList(items);
            return View(viaje);
        }

        [HttpPost]
        public ActionResult Create(Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                if (viaje.FechaInicio < viaje.FechaFin)
                {
                    if (Session["data"]!=null)
                    {
                        IRepositorio<Viaje> repo = new ViajeRepositorio();
                        repo.Save(viaje);
                        IRepositorioParticipante<Participante> repoPar = new ParticipanteRepositorio();
                        Participante par = new Participante();
                        IRepositorioPersona<Persona> repoPer = new PersonaRepositorio();
                        Persona per = new Persona();
                        per = repoPer.GetById(Session["data"] as String);
                        par.IdViaje = viaje.IdViaje;
                        par.Nickname = per.Nickname;
                        par.Tipo = "creador";
                        par.Viaje = viaje;
                        par.Persona = per;

                        if (repoPar.Save(par))
                        {
                            par.Tipo = "creador";
                        }
                        else
                        {
                            par.Tipo = "creador";
                        }
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "La fecha de inicio debe ser menor a la fecha fin.");
                }
                
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            IEnumerable<string> items = new string[] { "Publico", "Privado" };
            ViewData["Privacidad"] = new SelectList(items);
            return View(viaje);
        }

        public ActionResult Delete(int id)
        {
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            repo.Delete(repo.GetById(id));
            return RedirectToAction("Index");
        }

        public ActionResult VerViajes(String nick)
        {
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            IRepositorioParticipante<Participante> repoP = new ParticipanteRepositorio();
            IList<Viaje> viajes = new List<Viaje>();
            IList<Participante> participantes = repoP.GetAllByNick(nick);

            foreach (var item in participantes)
            {
                viajes.Add(repo.GetById(item.IdViaje));
            }

            return View(viajes); ;
        }

        public MvcHtmlString EsMiViajeOParticipo(int idViaje)
        {
            string nick = Session["data"] as string;
            if (nick == null)
                return MvcHtmlString.Create("false");
            IRepositorioParticipante<Participante> repoP = new ParticipanteRepositorio();
            IList<Participante> participantes = repoP.GetAllByNick(nick);

            foreach (var item in participantes)
            {
                if (item.IdViaje == idViaje)
                {
                    return MvcHtmlString.Create("true");
                }
            }
            return MvcHtmlString.Create("false");
        }

        public MvcHtmlString EsMiViaje(int idViaje)
        {
            string nick = Session["data"] as string;
            if (nick == null)
                return MvcHtmlString.Create("false");
            IRepositorioParticipante<Participante> repoP = new ParticipanteRepositorio();
            IList<Participante> participantes = repoP.GetAllByNick(nick);

            foreach (var item in participantes)
            {
                if (item.IdViaje == idViaje && item.Tipo == "creador")
                {
                    return MvcHtmlString.Create("true");
                }
            }
            return MvcHtmlString.Create("false");
        }

        public ActionResult CerrarViaje(int idViaje)
        {
            string nick = Session["data"] as string;
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            Viaje viaje = repo.GetById(idViaje);
            viaje.Estatus = "cerrado";
            repo.Update(viaje);
            return RedirectToAction("Pdf", "Pdf", new { idViaje = idViaje });
        }

        public MvcHtmlString ViajeCerrado(int idViaje)
        {
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            IList<Viaje> viajes = repo.GetAll();

            foreach (var item in viajes)
            {
                if (item.Estatus != null)
                {
                    String estatus = item.Estatus.Trim().ToLower();
                    if (item.IdViaje == idViaje && estatus == "cerrado")
                    {
                        return MvcHtmlString.Create("true");
                    }
                }
            }
            return MvcHtmlString.Create("false");
        }

        public ActionResult ViajeDestinosReporte(int idViaje)
        {
            IRepositorio<Viaje> repo = new ViajeRepositorio();
            Viaje viaje = repo.GetById(idViaje);

            IRepositorio<Destino> repoD = new DestinoRepositorio();
            IList<Destino> todosDestinos = repoD.GetAll();

            IList<Destino> destinos = new List<Destino>();
            foreach (var destino in todosDestinos)
            {
                if (destino.Viaje.IdViaje == idViaje)
                {
                    destinos.Add(destino);
                }
            }
            viaje.Destinos = new List<Destino>();
            foreach (var item in destinos)
            {
                viaje.Destinos.Add(item);
            }
            return View(viaje);
        }
    }
}
