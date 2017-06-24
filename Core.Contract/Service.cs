using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract
{
    public class Service<T> : IService<T> where T : Entity.Entity
    {
        public virtual GenericResponse<T> ActivateEntity(GenericRequest<T> Request)
        {
            throw new NotImplementedException();
        }

        public virtual GenericResponse<T> Add(GenericRequest<T> Request)
        {
            throw new NotImplementedException();
        }

        public virtual GenericResponse<T> AddList(GenericRequest<T> Request)
        {
            throw new NotImplementedException();
        }

        public virtual GenericResponse<T> DisableEntity(GenericRequest<T> Request)
        {
            throw new NotImplementedException();
        }

        public virtual GenericResponse<T> GetActives(GenericRequest<T> Request)
        {
            throw new NotImplementedException();
        }

        public virtual GenericResponse<T> GetByExpression(GenericRequest<T> Request)
        {
            throw new NotImplementedException();
        }

        public virtual GenericResponse<T> GetByID(GenericRequest<T> Request)
        {
            throw new NotImplementedException();
        }

        public virtual GenericResponse<T> GetDeleted(GenericRequest<T> Request)
        {
            throw new NotImplementedException();
        }

        public virtual GenericResponse<T> HardDelete(GenericRequest<T> Request)
        {
            throw new NotImplementedException();
        }

        public virtual GenericResponse<T> SoftDelete(GenericRequest<T> Request)
        {
            throw new NotImplementedException();
        }

        public virtual GenericResponse<T> Update(GenericRequest<T> Request)
        {
            throw new NotImplementedException();
        }

        
    }
}
