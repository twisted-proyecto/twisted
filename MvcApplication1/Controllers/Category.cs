using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Norm;

namespace MvcApplication1.Controllers
{
    class Category
    {
        [MongoIdentifier]
        public ObjectId Id { get; set; }

        public string Nickname { get; set; }
        public int IdDestino { get; set; }
        public string Voto { get; set; }

    }
}
