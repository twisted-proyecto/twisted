using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using MvcApplication1.Dominio.Model;

namespace MvcApplication1.Dominio.Repositorios
{
    public class ComentarioRepositorio : IRepositorioComentario<Comentario>
    {
        #region IRepositorio<Comentario> Members

        bool IRepositorioComentario<Comentario>.Save(Comentario entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entity);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return false;
                    }

                }
            }
        }

        void IRepositorioComentario<Comentario>.Update(Comentario entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepositorioComentario<Comentario>.Delete(Comentario entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        IList<Comentario> IRepositorioComentario<Comentario>.GetAllById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<Comentario>().Add(Restrictions.Eq("idDestino", id));
                return criteria.List<Comentario>();
            }
        }



        IList<Comentario> IRepositorioComentario<Comentario>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Comentario));
                return criteria.List<Comentario>();
            }
        }

        #endregion
    }
}
