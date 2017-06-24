using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract
{
    public sealed class GenericRequest<T> : IGenericRequest<T> where T : Entity.Entity
    {
        public int ID { get; set; }

        public T Entity { get; set; }

        public List<T> EntityList { get; set; }

        public object GenericVariable { get; set; }

        public Expression<Func<T, bool>> Expression { get; set; }
    }
}
