using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using MvcApplication1.Dominio.Model;

namespace MvcApplication1.Dominio.Repositorios
{
    public class AmistadRepositorio : IRepositorio<Amistad>
    {
        #region IRepositorio<Amistad> Members

        bool IRepositorio<Amistad>.Save(Amistad entity)
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

        void IRepositorio<Amistad>.Update(Amistad entity)
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

        void IRepositorio<Amistad>.Delete(Amistad entity)
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

        Amistad IRepositorio<Amistad>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Amistad>().Add(Restrictions.Eq("nicknameAmigo", id)).UniqueResult<Amistad>();
        }

        IList<Amistad> IRepositorio<Amistad>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Amistad));
                return criteria.List<Amistad>();
            }
        }


        #endregion
    }
}
