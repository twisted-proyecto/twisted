using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Dominio.Model;
using MvcApplication1.Dominio.Repositorios;
using MvcApplication1.Dominio;

namespace MvcApplication1.Test
{
    /// <summary>
    ///Se trata de una clase de prueba para ViajeRepositorioTest y se pretende que
    ///contenga todas las pruebas unitarias ViajeRepositorioTest.
    ///</summary>
    [TestClass]
    public class ViajeRepositorioTest
    {
        private Viaje _model;
        private IRepositorio<Viaje> _repositorio;
        private string _nombreAModificar;
        private IList<Viaje> _todosLosViajes;
        private Viaje _viajeEsperado;

        private Viaje ObtenerViaje()
        {
            _todosLosViajes = _repositorio.GetAll();
            int posicionUltimoViaje = _todosLosViajes.Count - 1;
            if (posicionUltimoViaje == -1)
                return null;
            else
                return _todosLosViajes[posicionUltimoViaje];
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            _repositorio = new ViajeRepositorio();
            _nombreAModificar = "viajeTestModificado";
            _model = new Viaje()
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
        public void MyTestCleanup()
        {
            _repositorio = null;
            _model = null;
        }

        /// <summary>
        ///Una prueba de MvcApplication1.Dominio.IRepositorio<MvcApplication1.Dominio.Model.Viaje>.Save
        ///</summary>
        [TestMethod]
        public void SaveTest()
        {
            _repositorio.Save(_model);
            _viajeEsperado = ObtenerViaje();

            Assert.IsTrue(_model.EqualsSinId(_viajeEsperado), "El viaje: " + _model.Nombre + " no se pudo insertar.");

            _repositorio.Delete(_model);
        }

        /// <summary>
        ///Una prueba de MvcApplication1.Dominio.IRepositorio<MvcApplication1.Dominio.Model.Viaje>.Update
        ///</summary>
        [TestMethod]
        public void UpdateTest()
        {
            _repositorio.Save(_model);

            string nombreAnterior = _model.Nombre;
            _model.Nombre = _nombreAModificar;
            _viajeEsperado = ObtenerViaje();
            _model.IdViaje = _viajeEsperado.IdViaje;
            _repositorio.Update(_model);

            Assert.IsTrue(_repositorio.GetById(_model.IdViaje).Nombre == _nombreAModificar,"El nombre del viaje: " + nombreAnterior +" no es igual al esperado: " + _nombreAModificar);

            _repositorio.Delete(_model);
        }

        /// <summary>
        ///Una prueba de MvcApplication1.Dominio.IRepositorio<MvcApplication1.Dominio.Model.Viaje>.Delete
        ///</summary>
        [TestMethod]
        public void DeleteTest()
        {
            _repositorio.Save(_model);

            _repositorio.Delete(_model);
            _viajeEsperado = ObtenerViaje();

            Assert.IsTrue(!_model.EqualsSinId(_viajeEsperado), "El viaje: " + _model.Nombre + " no se pudo eliminar.");
        }

        /// <summary>
        ///Una prueba de MvcApplication1.Dominio.IRepositorio<MvcApplication1.Dominio.Model.Viaje>.GetById
        ///</summary>
        [TestMethod]
        public void GetByIdTest()
        {
            _repositorio.Save(_model);

            _viajeEsperado = _repositorio.GetById(_model.IdViaje);

            Assert.IsTrue(_model.IdViaje == _viajeEsperado.IdViaje, "El viaje: " + _model.Nombre + " id: " + _model.IdViaje + " no se pudo consultar.");
        
            _repositorio.Delete(_model);
        }


    }
}
