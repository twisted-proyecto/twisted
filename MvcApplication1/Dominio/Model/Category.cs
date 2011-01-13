using System.ComponentModel.DataAnnotations;
using Norm;

namespace MvcApplication1.Dominio.Model
{
    public class Category 
    {
        //public Category()
        //{
        //    this.Id = ObjectId.NewObjectId();
        //}        
        [MongoIdentifier]
        public ObjectId Id { get; set; }

       
        public string Nickname { get; set;}
        public int IdDestino { get; set; }
        public string Voto { get; set; }

    }
}