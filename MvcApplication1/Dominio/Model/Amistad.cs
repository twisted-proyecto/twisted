using System;
using Iesi.Collections.Generic;

namespace MvcApplication1.Dominio.Model
{
	[Serializable]
	public partial class Amistad
	{
		public virtual DateTime? Fecha
		{
			get;
			set;
		}
		public virtual string Nickname
		{
			get;
			set;
		}
		public virtual string NicknameAmigo
		{
			get;
			set;
		}
		public virtual Persona Persona
		{
			get;
			set;
		}
		public virtual Persona Persona1
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Amistad);
		}
		
		public virtual bool Equals(Amistad obj)
		{
			if (obj == null) return false;

			if (Equals(Fecha, obj.Fecha) == false)
				return false;

			if (Equals(Nickname, obj.Nickname) == false)
				return false;

			if (Equals(NicknameAmigo, obj.NicknameAmigo) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Fecha != null ? Fecha.GetHashCode() : 0);
			result = (result * 397) ^ (Nickname != null ? Nickname.GetHashCode() : 0);
			result = (result * 397) ^ (NicknameAmigo != null ? NicknameAmigo.GetHashCode() : 0);			
			return result;
		}
	}
}