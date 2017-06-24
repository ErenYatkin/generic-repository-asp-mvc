using Core.Contract;
using Core.Model.Context;
using Core.Repository.RepositoryBase;

namespace Core.Business.BusinessBase
{
    public class BaseBusiness<T> : BusinessCore<T>,IService<T> where T : Entity.Entity
    {
        /// <summary>
        /// GenericRespone defination
        /// </summary>
        GenericResponse<T> Response;

        public  BaseBusiness()
        {
            // These variables comes from BusinessCore
            this.Repository = new BaseRepository<T>();
            this._context = (BaseDbContext)Common.Methods.CommonMethods.GetDbContext<T>();
            this.Repository._context = this._context;
            Response = new GenericResponse<T>();
        }

        /// <summary>
        /// This method is used for the add entities.
        /// Require a GenericRequest and returns a GenericResponse
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public override GenericResponse<T> Add(GenericRequest<T> Request)
        {
            Response = Repository.Add(Request);

            return Response;
        }

        public override GenericResponse<T> AddList(GenericRequest<T> Request)
        {
            Response = Repository.AddList(Request);

            return Response;
        }

        public override GenericResponse<T> GetActives(GenericRequest<T> Request)
        {
            Response = Repository.GetActives(Request);

            return Response;
        }

        public override GenericResponse<T> GetByExpression(GenericRequest<T> Request)
        {
            Response = Repository.GetByExpression(Request);
            return Response;
        }

        public override GenericResponse<T> GetByID(GenericRequest<T> Request)
        {
            Response = Repository.GetByID(Request);
            return Response;
        }

        public override GenericResponse<T> GetDeleted(GenericRequest<T> Request)
        {
            Response = Repository.GetDeleted(Request);

            return Response;
        }

        public override GenericResponse<T> HardDelete(GenericRequest<T> Request)
        {
            Response = Repository.HardDelete(Request);
            return Response;
        }

        public override GenericResponse<T> SoftDelete(GenericRequest<T> Request)
        {
            Response = Repository.SoftDelete(Request);
            return Response;
        }

        public override GenericResponse<T> Update(GenericRequest<T> Request)
        {
            Response = Repository.Update(Request);
            return Response;
        }

        public override GenericResponse<T> ActivateEntity(GenericRequest<T> Request)
        {
            Response = Repository.ActivateEntity(Request);

            return Response;
        }

        public override GenericResponse<T> DisableEntity(GenericRequest<T> Request)
        {
            Response = Repository.DisableEntity(Request);


            return Response;
        }
    }
}
