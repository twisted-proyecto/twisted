using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication1.Dominio
{
    public interface IRepositorioParticipante<T>
    {
        bool Save(T entity);
        void Update(T entity);
        void Delete(T entiy);
        T GetById(String id);
        IList<T> GetAll();
        IList<T> GetAllByNick(String nickname);
    }
}
