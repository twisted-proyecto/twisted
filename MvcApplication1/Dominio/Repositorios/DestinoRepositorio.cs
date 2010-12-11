using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using MvcApplication1.Dominio.Model;

namespace MvcApplication1.Dominio.Repositorios
{
    public class DestinoRepositorio : IRepositorio<Destino>
    {
        #region IRepositorio<Destino> Members

        bool IRepositorio<Destino>.Save(Destino entity)
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

        void IRepositorio<Destino>.Update(Destino entity)
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

        void IRepositorio<Destino>.Delete(Destino entity)
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

        Destino IRepositorio<Destino>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Destino>().Add(Restrictions.Eq("IdDestino", id)).UniqueResult<Destino>();
        }

       

        IList<Destino> IRepositorio<Destino>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Destino));
                return criteria.List<Destino>();
            }
        }

        #endregion
    }
}
