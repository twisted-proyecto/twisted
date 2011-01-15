using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using MvcApplication1.Dominio.Model;

namespace MvcApplication1.Dominio.Repositorios
{
    public class ParticipanteRepositorio : IRepositorioParticipante<Participante>
    {
        #region IRepositorio<Participante> Members

        bool IRepositorioParticipante<Participante>.Save(Participante entity)
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

        void IRepositorioParticipante<Participante>.Update(Participante entity)
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

        void IRepositorioParticipante<Participante>.Delete(Participante entity)
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

        Participante IRepositorioParticipante<Participante>.GetById(String id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Participante>().Add(Restrictions.Eq("Nickname", id)).UniqueResult<Participante>(); 
        }

        IList<Participante> IRepositorioParticipante<Participante>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Participante));
                return criteria.List<Participante>();
            }
        }

        IList<Participante> IRepositorioParticipante<Participante>.GetAllByNick(String id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<Participante>().Add(Restrictions.Eq("Nickname", id));
                return criteria.List<Participante>();

            }
        }

      
        #endregion
    }
}
