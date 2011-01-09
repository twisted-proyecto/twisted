using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using MvcApplication1.Dominio.Model;

namespace MvcApplication1.Dominio.Repositorios
{
    public class ViajeRepositorio : IRepositorio<Viaje>
    {
        #region IRepositorio<Viaje> Members

        bool IRepositorio<Viaje>.Save(Viaje entity)
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
                       Console.Write(e.Message);
                        return false;
                    }
                    
                }
            }
        }

        void IRepositorio<Viaje>.Update(Viaje entity)
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

        void IRepositorio<Viaje>.Delete(Viaje entity)
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

        Viaje IRepositorio<Viaje>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Viaje>().Add(Restrictions.Eq("IdViaje", id)).UniqueResult<Viaje>(); 
        }

        IList<Viaje> IRepositorio<Viaje>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Viaje));
                return criteria.List<Viaje>();
            }
        }

      
        #endregion
    }
}
