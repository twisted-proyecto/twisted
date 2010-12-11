using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Dominio.Repositorios;
using MvcApplication1.Dominio;

namespace MvcApplication1.Tests.Controllers
{
    /// <summary>
    ///Se trata de una clase de prueba para ViajeRepositorioTest y se pretende que
    ///contenga todas las pruebas unitarias ViajeRepositorioTest.
    ///</summary>
    [TestClass]
    [DeploymentItem("hibernate.cfg.xml")]
    public class DestinoRepositorioTest
    {
        private Destino _model;
        private Viaje _modelV;
        private IRepositorio<Destino> _repositorio;
        private IRepositorio<Viaje> _repositorioV;
        private string _nombreAModificar;
        private IList<Destino> _todosLosDestinos;
        private Destino _destinoEsperado;

        private Destino ObtenerDestino()
        {
            _todosLosDestinos = _repositorio.GetAll();
            int posicionUltimoDestino = _todosLosDestinos.Count - 1;
            if (posicionUltimoDestino == -1)
                return null;
            else
                return _todosLosDestinos[posicionUltimoDestino];
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            _repositorio = new DestinoRepositorio();
            _repositorioV = new ViajeRepositorio();
            _nombreAModificar = "destinoTestModificado";
           
            _modelV = new Viaje()
            {
                IdViaje = 0,
                Nombre = "viajeTest",
                Privacidad = "Publico",
                Destino = "destinoTest",
                FechaInicio = System.Convert.ToDateTime("01/01/2010"),
                FechaFin = System.Convert.ToDateTime("01/01/2011"),
                Hospedaje = "hospedajeTest"
            };

            _repositorioV.Save(_modelV);
            
            _model = new Destino()
           {
                Nombre = "destinoTest",
                Latitud = 11.1123466,
                Longitud = 123.765432,
                Estatus = "Sugerido",
                Url = "http://www.flickr.com/photos/8230500@N04/1954204399/",
                Fecha = System.Convert.ToDateTime("01/01/2011"),
                Viaje = _modelV
            };
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            _repositorioV.Delete(_modelV);
            _repositorio = null;
            _model = null;
        }

        /// <summary>
        ///Una prueba de MvcApplication1.Dominio.IRepositorio<MvcApplication1.Dominio.Model.Destino>.Save
        ///</summary>
        [TestMethod]
        public void SaveTest()
        {
            Assert.IsTrue(_repositorio.Save(_model), "El destino: " + _model.Nombre + " no se pudo insertar para ser eliminado."); 
            _destinoEsperado = ObtenerDestino();

            Assert.IsTrue(_model.Equals(_destinoEsperado), "El destino: " + _model.Nombre + " no se pudo insertar.");

            _repositorio.Delete(_model);
        }

        /// <summary>
        ///Una prueba de MvcApplication1.Dominio.IRepositorio<MvcApplication1.Dominio.Model.Destino>.Update
        ///</summary>
        [TestMethod]
        public void UpdateTest()
        {
            Assert.IsTrue(_repositorio.Save(_model), "El destino: " + _model.Nombre + " no se pudo insertar para ser eliminado."); 

            string nombreAnterior = _model.Nombre;
            _model.Nombre = _nombreAModificar;
            _destinoEsperado = ObtenerDestino();
            _model.IdDestino = _destinoEsperado.IdDestino;
            _repositorio.Update(_model);

            Assert.IsTrue(_repositorio.GetById(_model.IdDestino).Nombre == _nombreAModificar,"El nombre del destino: " + nombreAnterior +" no es igual al esperado: " + _nombreAModificar);

            _repositorio.Delete(_model);
        }

        /// <summary>
        ///Una prueba de MvcApplication1.Dominio.IRepositorio<MvcApplication1.Dominio.Model.Destino>.Delete
        ///</summary>
        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(_repositorio.Save(_model), "El destino: " + _model.Nombre + " no se pudo insertar para ser eliminado.");
            _repositorio.Delete(_model);
            _destinoEsperado = ObtenerDestino();
            Assert.IsTrue(!_model.Equals(_destinoEsperado), "El destino: " + _model.Nombre + " no se pudo eliminar.");
            
        }

        /// <summary>
        ///Una prueba de MvcApplication1.Dominio.IRepositorio<MvcApplication1.Dominio.Model.Destino>.GetById
        ///</summary>
        [TestMethod]
        public void GetByIdTest()
        {
            Assert.IsTrue(_repositorio.Save(_model), "El destino: " + _model.Nombre + " no se pudo insertar para ser eliminado."); 

            _destinoEsperado = _repositorio.GetById(_model.IdDestino);

            Assert.IsTrue(_model.IdDestino == _destinoEsperado.IdDestino, "El destino: " + _model.Nombre + " id: " + _model.IdDestino + " no se pudo consultar.");
        
            _repositorio.Delete(_model);
        }


    }
}
