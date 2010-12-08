using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using MvcApplication1.Dominio.Model;

namespace MvcApplication1.Dominio.Repositorios
{
    public class PersonaRepositorio : IRepositorioPersona<Persona>
    {
        #region IRepositorio<Persona> Members

        void IRepositorioPersona<Persona>.Save(Persona entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepositorioPersona<Persona>.Update(Persona entity)
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

        void IRepositorioPersona<Persona>.Delete(Persona entity)
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

        Persona IRepositorioPersona<Persona>.GetById(String id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Persona>().Add(Restrictions.Eq("Nickname", id)).UniqueResult<Persona>(); 
        }

        IList<Persona> IRepositorioPersona<Persona>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Persona));
                return criteria.List<Persona>();
            }
        }

        #endregion
    }
}
