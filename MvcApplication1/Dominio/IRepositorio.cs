using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication1.Dominio
{
    public interface IRepositorio<T>
    {
        /// <summary>
        ///  Metodo para guardar en el repositorio
        /// </summary>
        /// <param name="entity"> representa la entidad que maneja el repositorio</param>
        bool Save(T entity);

        /// <summary>
        ///  Metodo para modificar el repositorio
        /// </summary>
        /// <param name="entity"> representa la entidad que maneja el repositorio</param>
        void Update(T entity);

        /// <summary>
        ///  Metodo para eleminar del repositorio
        /// </summary>
        /// <param name="entiy"> representa la entidad que maneja el repositorio</param>
        void Delete(T entiy);

       /// <summary>
       /// Obtine un objeto del repositorio
       /// </summary>
       /// <param name="id">parametro utilizado para la buscqueda</param>
       /// <returns>Retorna el objeto que tenga el id especificado</returns>
        T GetById(int id);
        
        /// <summary>
        ///  Retorna el todos los objetos del repositorio
        /// </summary>
        /// <returns>Retorna una lista con todos los objetos contenidos en el repositorio</returns>
        IList<T> GetAll();
       
    }
}
