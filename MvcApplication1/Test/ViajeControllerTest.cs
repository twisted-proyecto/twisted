using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Controllers;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Dominio.Repositorios;
using MvcApplication1.Dominio;

namespace MvcApplication1.Test
{
    [TestClass]
    public class ViajeControllerTest
    {
        private ViajeController controller;
        private Viaje model;
        private IRepositorio<Viaje> repo;

        [TestInitialize]
        public void myTestInitialize()
        {
            controller = new ViajeController();
            repo = new ViajeRepositorio();
            model = new Viaje()
            {
                Nombre = "viajeTest",
                Privacidad = "Publico",
                Destino = "destinoTest",
                FechaInicio = System.Convert.ToDateTime("01/01/2010"),
                FechaFin = System.Convert.ToDateTime("01/01/2011"),
                Hospedaje = "hospedajeTest"
            };
        }

        [TestCleanup]
        public void myTestCleanup()
        {

        }

        [TestMethod]
        public void AgregarViaje()
        {

            // Actuar
            ActionResult result = controller.Create(model);

            // Declarar
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult redirectResult = (RedirectToRouteResult) result;
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);

            repo.Delete(model);
        }
    }
}
