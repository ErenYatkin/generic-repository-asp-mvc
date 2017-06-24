using System.Collections.Generic;
using AppCore;
namespace Core.Contract
{
    /// <summary>
    /// Used to return many items at once
    /// </summary>
    /// <typeparam name="T">Entity that inherits Core.Entity or Core.EntityHistorical</typeparam>
    public interface IGenericResponse<T> where T : Entity.Entity
    {
        /// <summary>
        /// Entity itself
        /// </summary>
        T Entity { get; set; }

        /// <summary>
        /// Entity List
        /// </summary>
        List<T> EntityList { get; set; }

        /// <summary>
        /// Stores generic variable
        /// </summary>
        object Tag { get; set; }

        /// <summary>
        /// Used to store Exception Message
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Specifies the process is Successful or Failure.
        /// </summary>
        CoreEnum.Result_Type Result_Type { get; set; }

    }
}
