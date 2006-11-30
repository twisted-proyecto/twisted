using System;
using Iesi.Collections.Generic;

namespace MvcApplication1.Dominio.Model
{
	[Serializable]
	public partial class Destino
	{
		public virtual string Descripcion
		{
			get;
			set;
		}
		public virtual string Direccion
		{
			get;
			set;
		}
		public virtual string Estatus
		{
			get;
			set;
		}
		public virtual DateTime? Fecha
		{
			get;
			set;
		}
		public virtual int IdDestino
		{
			get;
			set;
		}
		public virtual double Latitud
		{
			get;
			set;
		}
		public virtual double Longitud
		{
			get;
			set;
		}
		public virtual string Nombre
		{
			get;
			set;
		}
		public virtual string Url
		{
			get;
			set;
		}
		public virtual ISet<Comentario> Comentarios
		{
			get;
			set;
		}
		public virtual Viaje Viaje
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Destino);
		}
		
		public virtual bool Equals(Destino obj)
		{
			if (obj == null) return false;

			if (Equals(Descripcion, obj.Descripcion) == false)
				return false;

			if (Equals(Direccion, obj.Direccion) == false)
				return false;

			if (Equals(Estatus, obj.Estatus) == false)
				return false;

			if (Equals(Fecha, obj.Fecha) == false)
				return false;

			if (Equals(IdDestino, obj.IdDestino) == false)
				return false;

			if (Equals(Latitud, obj.Latitud) == false)
				return false;

			if (Equals(Longitud, obj.Longitud) == false)
				return false;

			if (Equals(Nombre, obj.Nombre) == false)
				return false;

			if (Equals(Url, obj.Url) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Descripcion != null ? Descripcion.GetHashCode() : 0);
			result = (result * 397) ^ (Direccion != null ? Direccion.GetHashCode() : 0);
			result = (result * 397) ^ (Estatus != null ? Estatus.GetHashCode() : 0);
			result = (result * 397) ^ (Fecha != null ? Fecha.GetHashCode() : 0);
			result = (result * 397) ^ (IdDestino != null ? IdDestino.GetHashCode() : 0);
			result = (result * 397) ^ (Latitud != null ? Latitud.GetHashCode() : 0);
			result = (result * 397) ^ (Longitud != null ? Longitud.GetHashCode() : 0);
			result = (result * 397) ^ (Nombre != null ? Nombre.GetHashCode() : 0);
			result = (result * 397) ^ (Url != null ? Url.GetHashCode() : 0);			
			return result;
		}
	}
}