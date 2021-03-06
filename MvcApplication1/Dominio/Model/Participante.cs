using System;
using Iesi.Collections.Generic;

namespace MvcApplication1.Dominio.Model
{
	[Serializable]
	public partial class Participante
	{
		public virtual int IdViaje
		{
			get;
			set;
		}
		public virtual string Nickname
		{
			get;
			set;
		}
		public virtual string Tipo
		{
			get;
			set;
		}
		public virtual Persona Persona
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
				
			return Equals(obj as Participante);
		}
		
		public virtual bool Equals(Participante obj)
		{
			if (obj == null) return false;

			if (Equals(IdViaje, obj.IdViaje) == false)
				return false;

			if (Equals(Nickname, obj.Nickname) == false)
				return false;

			if (Equals(Tipo, obj.Tipo) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (IdViaje != null ? IdViaje.GetHashCode() : 0);
			result = (result * 397) ^ (Nickname != null ? Nickname.GetHashCode() : 0);
			result = (result * 397) ^ (Tipo != null ? Tipo.GetHashCode() : 0);			
			return result;
		}
	}
}