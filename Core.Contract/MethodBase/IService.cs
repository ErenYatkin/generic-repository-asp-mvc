using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract
{
    public interface IService<T> where T : Entity.Entity
    {

        /// <summary>
        /// This method is used for to get "Active" entities.
        /// Require a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request">GenericRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse<T> GetActives(GenericRequest<T> Request);

        /// <summary>
        /// This method is used for to get Deleted entities.
        /// Requires a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request">GenericRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse<T> GetDeleted(GenericRequest<T> Request);


        /// <summary>
        /// This method is used for to get entity by its ID.
        /// Require a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request">GenericRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse<T> GetByID(GenericRequest<T> Request);


        /// <summary>
        /// This method is used for to get entities by given Expression.
        /// Require a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request">GenericRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse<T> GetByExpression(GenericRequest<T> Request);

        /// <summary>
        /// This method is used for to add entity.
        /// Require a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request">GenericRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse<T> Add(GenericRequest<T> Request);

        /// <summary>
        /// This method is used for to add entities.
        /// Require a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request">GenericRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse<T> AddList(GenericRequest<T> Request);

        /// <summary>
        /// This method is used for to update single entity.
        /// Require a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request">GenericRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse<T> Update(GenericRequest<T> Request);

        /// <summary>
        /// This method is used for to delete entity from database.
        /// Require a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request">GenericRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse<T> HardDelete(GenericRequest<T> Request);

        /// <summary>
        /// This method is used for to change the status of the entity .
        /// Require a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request">GenericRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse<T> SoftDelete(GenericRequest<T> Request);

        /// <summary>
        /// This method is used for to change the status of the entity .
        /// Require a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request">GenericRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse<T> DisableEntity(GenericRequest<T> Request);

        /// <summary>
        /// This method is used for to change the status of the entity .
        /// Require a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request">GenericRequest</param>
        /// <returns>GenericResponse</returns>
        GenericResponse<T> ActivateEntity(GenericRequest<T> Request);

    }
}
