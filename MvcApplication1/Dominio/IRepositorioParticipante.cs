using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication1.Dominio
{
    public interface IRepositorioParticipante<T>
    {
        /// <summary>
        /// Guarda el objeto T en el repositorio
        /// </summary>
        /// <param name="entity">Representa la entidad que maneja el repositorio</param>
        /// <returns> Retorna true si el objeto pudo ser agregado al repositorio, 
        ///            retorna false en caso contrario</returns>
        bool Save(T entity);

        /// <summary>
        /// Modifica el objeto T del repositorio
        /// </summary>
        /// <param name="entity">Representa la entidad que maneja el repositorio</param>
        void Update(T entity);
       
        /// <summary>
        /// Elimina el objeto T del repositorio
        /// </summary>
        /// <param name="id">Representa la entidad que maneja el repositorio</param>
        void Delete(T entiy);
        
        /// <summary>
        ///  Obtine un objeto del repositorio
        /// </summary>
        /// <param name="id">Parametro utilizado para la buscqueda</param>
        /// <returns>Retorna el objeto que tenga el id especificado</returns>
        T GetById(String id);
       
        /// <summary>
        /// Retorna el todos los objetos del repositorio
        /// </summary>
        /// <returns>Retorna una lista con todos los objetos contenidos en el repositorio</returns>
        IList<T> GetAll();
        
        /// <summary>
        ///  Busca en el repositorio todos los viajes de un participante especifico
        /// </summary>
        /// <param name="nickname">Identificador del participante</param>
        /// <returns>La lista de viajes de un participante</returns>
        IList<T> GetAllByNick(String nickname);
    }
}
