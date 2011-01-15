using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication1.Dominio
{
    public interface IRepositorioPersona<T>
    {
        /// <summary>
        ///  Metodo para guardar en el repositorio
        /// </summary>
        /// <param name="entity"> Representa la entidad que maneja el repositorio</param>
        void Save(T entity);

        /// <summary>
        /// Modifica el objeto T del repositorio
        /// </summary>
        /// <param name="entity">Representa la entidad que maneja el repositorio</param>
        void Update(T entity);

        /// <summary>
        ///  Eleminar el objeto T del repositorio
        /// </summary>
        /// <param name="entiy">Representa la entidad que maneja el repositorio</param>
        void Delete(T entiy);

        /// <summary>
        /// Obtine una persona del repositorio
        /// </summary>
        /// <param name="id">parametro utilizado para la buscqueda</param>
        /// <returns>Retorna la persona que tenga el id especificado</returns>
        T GetById(String id);

        /// <summary>
        ///  Retorna el todas las personas del repositorio
        /// </summary>
        /// <returns>Retorna una lista con todas las personas contenidas en el repositorio</returns>
        IList<T> GetAll();

        /// <summary>
        /// Retorna una lista de personas 
        /// </summary>
        /// <param name="privacidad">Indica el tipo de usuario a consultar, Publico o Privado</param>
        /// <returns>Una lista de personas parametrizada por el tipo de privacidad</returns>
        IList<T> GetByPrivacidad(String privacidad);
    }
}
