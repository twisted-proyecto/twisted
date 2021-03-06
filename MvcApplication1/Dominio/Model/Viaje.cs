using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Dominio.Model
{
	[Serializable]
	public partial class Viaje
	{

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("destino del viaje")]
		public virtual string Destino {	get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("fecha de inicio del viaje")]
		public virtual DateTime FechaFin { get;	set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("fecha fin del viaje")]
        public virtual DateTime FechaInicio { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("hospedaje del viaje")]
		public virtual string Hospedaje { get; set; }

		public virtual int IdViaje { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("nombre del viaje")]
		public virtual string Nombre { get; set; }

        public virtual string Privacidad { get; set; }

        [DataType(DataType.Text)]
        public virtual string Estatus { get; set; }

        public virtual IList<Destino> Destinos
		{
			get;
			set;
		}
		public virtual Iesi.Collections.Generic.ISet<Foto> Fotos
		{
			get;
			set;
		}
		public virtual Iesi.Collections.Generic.ISet<Participante> Participantes
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Viaje);
		}
		
		public virtual bool Equals(Viaje obj)
		{
			if (obj == null) return false;

			if (Equals(Destino, obj.Destino) == false)
				return false;

			if (Equals(FechaFin, obj.FechaFin) == false)
				return false;

			if (Equals(FechaInicio, obj.FechaInicio) == false)
				return false;

			if (Equals(Hospedaje, obj.Hospedaje) == false)
				return false;

			if (Equals(IdViaje, obj.IdViaje) == false)
				return false;

			if (Equals(Nombre, obj.Nombre) == false)
				return false;

			if (Equals(Privacidad, obj.Privacidad) == false)
				return false;

			return true;
		}

        public virtual bool EqualsSinId(Viaje obj)
        {
            if (obj == null) return false;

            if (Equals(Destino, obj.Destino) == false)
                return false;

            if (Equals(FechaFin, obj.FechaFin) == false)
                return false;

            if (Equals(FechaInicio, obj.FechaInicio) == false)
                return false;

            if (Equals(Hospedaje, obj.Hospedaje) == false)
                return false;

            if (Equals(Nombre, obj.Nombre) == false)
                return false;

            if (Equals(Privacidad, obj.Privacidad) == false)
                return false;

            return true;
        }
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Destino != null ? Destino.GetHashCode() : 0);
			result = (result * 397) ^ (FechaFin != null ? FechaFin.GetHashCode() : 0);
			result = (result * 397) ^ (FechaInicio != null ? FechaInicio.GetHashCode() : 0);
			result = (result * 397) ^ (Hospedaje != null ? Hospedaje.GetHashCode() : 0);
			result = (result * 397) ^ (IdViaje != null ? IdViaje.GetHashCode() : 0);
			result = (result * 397) ^ (Nombre != null ? Nombre.GetHashCode() : 0);
			result = (result * 397) ^ (Privacidad != null ? Privacidad.GetHashCode() : 0);			
			return result;
		}
	}
}
