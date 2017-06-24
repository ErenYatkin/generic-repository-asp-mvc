using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore;

namespace Core.Contract
{
    public sealed class GenericResponse<T> : IGenericResponse<T> where T : Entity.Entity
    {
        public T Entity { get; set; }

        public List<T> EntityList { get; set; }

        public object Tag { get; set; }

        public string Message { get; set; }

        public CoreEnum.Result_Type Result_Type { get; set; }
    }
}
