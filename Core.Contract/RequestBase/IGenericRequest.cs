using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Contract
{
    /// <summary>
    /// Used for to give many parameters at once.
    /// </summary>
    /// <typeparam name="T">Entity that inherits Core.Entity or Core.EntityHistorical</typeparam>
    public interface IGenericRequest<T> where T : Entity.Entity
    {
        /// <summary>
        /// Entity ID
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Entity itself
        /// </summary>
        T Entity { get; set; }

        /// <summary>
        /// Entity List
        /// </summary>
        List<T> EntityList { get; set; }

        /// <summary>
        /// Generic variable list, object, int
        /// </summary>
        object GenericVariable { get; set; }

        /// <summary>
        /// Expression
        /// </summary>
        Expression<Func<T,bool>> Expression { get; set; }
    }
}
