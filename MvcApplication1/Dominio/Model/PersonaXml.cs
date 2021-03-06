using System;
using Iesi.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MvcApplication1.Dominio.Model
{
    public class PersonaXml
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string nickname { get; set; }
        public DateTime fechaNacimiento { get; set; }
    }
}
