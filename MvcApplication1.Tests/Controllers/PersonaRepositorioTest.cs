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
    public class PersonaRepositorioTest
    {
        private Persona _model;
        private IRepositorioPersona<Persona> _repositorio;
        private string _nombreAModificar;
        private Persona _laPersona;
        private Persona _personaEsperado;

        private Persona ObtenerPersona()
        {
            _laPersona = _repositorio.GetById("nicknameTest");
            return _laPersona;
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            _repositorio = new PersonaRepositorio();
            _nombreAModificar = "personaTestModificado";
            _model = new Persona()
            {
                Nombre          = "nombreTest",
                Apellido        = "apellidoTest",
                Email           = "emailTest@test.com",
                Estatus         = "Activo",
                FechaNacimiento = System.Convert.ToDateTime("01/01/2010"),
                Nickname        = "nicknameTest",
                Privacidad      = "Publico",
                Twitter         =  "nicknameTest"
                                
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
            _personaEsperado = ObtenerPersona();

            Assert.IsTrue(_model.Equals(_personaEsperado), "La Persona: " + _model.Nombre + " no se pudo insertar.");

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
            _personaEsperado = ObtenerPersona();
            _repositorio.Update(_model);

            Assert.IsTrue(_repositorio.GetById(_model.Nickname).Nombre == _nombreAModificar,"El nombre del viaje: " + nombreAnterior +" no es igual al esperado: " + _nombreAModificar);

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
            _personaEsperado = ObtenerPersona();

            Assert.IsTrue(!_model.Equals(_personaEsperado), "La Persona: " + _model.Nombre + " no se pudo eliminar.");
        }

        /// <summary>
        ///Una prueba de MvcApplication1.Dominio.IRepositorio<MvcApplication1.Dominio.Model.Viaje>.GetById
        ///</summary>
        [TestMethod]
        public void GetByIdTest()
        {
            _repositorio.Save(_model);

            _personaEsperado = _repositorio.GetById(_model.Nickname);

            Assert.IsTrue(_model.Nickname == _personaEsperado.Nickname, "La Persona: " + _model.Nombre + " Nickname: " + _model.Nickname + " no se pudo consultar.");
        
            _repositorio.Delete(_model);
        }


    }
}
