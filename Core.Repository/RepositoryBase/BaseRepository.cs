using AppCore;
using Core.Contract;
using System;
using System.Linq;
using static AppCore.CoreEnum;

namespace Core.Repository.RepositoryBase
{
    public class BaseRepository<T> : RepositoryCore<T> where T : Entity.Entity
    {

        public override GenericResponse<T> Add(GenericRequest<T> Request)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            try
            {
                _context.Set<T>().Add(Request.Entity);
                _context.SaveChanges();
                response.Result_Type = CoreEnum.Result_Type.Success;
            }
            catch (Exception ex)
            {
                response.Result_Type = CoreEnum.Result_Type.Failed;
                response.Message = ex.Message.ToString();
            }
            finally
            {
                response.Entity = Request.Entity;
            }
            return response;
        }

        public override GenericResponse<T> AddList(GenericRequest<T> Request)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            try
            {
                _context.Set<T>().AddRange(Request.EntityList);
                _context.SaveChanges();
                response.Result_Type = CoreEnum.Result_Type.Success;
            }
            catch (Exception ex)
            {
                response.Result_Type = CoreEnum.Result_Type.Failed;
                response.Message = ex.Message.ToString();
            }
            finally
            {
                response.EntityList = Request.EntityList;
            }
            return response;
        }

        public override GenericResponse<T> GetActives(GenericRequest<T> Request)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            try
            {
                response.EntityList = _context.Set<T>()
                    .Where(x => x.Status == CoreEnum.Status_Type.Active)
                    .ToList();
                if (response.EntityList.Count <= 0)
                {
                    response.Result_Type = CoreEnum.Result_Type.NoData;
                }
                else
                {
                    response.Result_Type = CoreEnum.Result_Type.Success;
                }

            }
            catch (Exception ex)
            {
                response.Result_Type = CoreEnum.Result_Type.Failed;
                response.Message = ex.Message.ToString();
            }
            return response;
        }

        public override GenericResponse<T> GetByExpression(GenericRequest<T> Request)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            try
            {
                response.EntityList = _context.Set<T>()
                    .Where(Request.Expression)
                    .ToList();

                if (response.EntityList.Count <= 0)
                {
                    response.Result_Type = CoreEnum.Result_Type.NoData;
                }
                else
                {
                    response.Result_Type = CoreEnum.Result_Type.Success;
                }

            }
            catch (Exception ex)
            {
                response.Result_Type = CoreEnum.Result_Type.Failed;
                response.Message = ex.Message.ToString();
            }
            return response;
        }

        public override GenericResponse<T> GetByID(GenericRequest<T> Request)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            try
            {
                response.Entity = _context.Set<T>().Find(Request.ID);

                if (response.Entity == null)
                {
                    response.Result_Type = CoreEnum.Result_Type.NoData;
                }
                else
                {
                    response.Result_Type = CoreEnum.Result_Type.Success;
                }
            }
            catch (Exception ex)
            {
                response.Result_Type = CoreEnum.Result_Type.Failed;
                response.Message = ex.Message.ToString();
            }
            return response;
        }

        public override GenericResponse<T> GetDeleted(GenericRequest<T> Request)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            try
            {
                response.EntityList = _context.Set<T>()
                    .Where(x => x.Status == CoreEnum.Status_Type.Deleted)
                    .ToList();
                if (response.EntityList.Count <= 0)
                {
                    response.Result_Type = CoreEnum.Result_Type.NoData;
                }
                else
                {
                    response.Result_Type = CoreEnum.Result_Type.Success;
                }

            }
            catch (Exception ex)
            {
                response.Result_Type = CoreEnum.Result_Type.Failed;
                response.Message = ex.Message.ToString();
            }
            return response;
        }

        public override GenericResponse<T> HardDelete(GenericRequest<T> Request)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            try
            {
                _context.Set<T>().Remove(Request.Entity);
                _context.SaveChanges();
                response.Result_Type = CoreEnum.Result_Type.Success;
            }
            catch (Exception ex)
            {
                response.Result_Type = CoreEnum.Result_Type.Failed;
                response.Message = ex.Message.ToString();
            }
            finally
            {
                response.Entity = Request.Entity;
            }
            return response;
        }

        public override GenericResponse<T> SoftDelete(GenericRequest<T> Request)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            GenericRequest<T> EntityRequest = new GenericRequest<T>();
            EntityRequest.ID = Request.Entity.ID;
            T willUpdated = this.GetByID(EntityRequest).Entity;
            willUpdated.Status = CoreEnum.Status_Type.Deleted;

            Request.Entity = willUpdated;

            _context.Entry(willUpdated).CurrentValues.SetValues(Request.Entity);
            _context.SaveChanges();
            response.Result_Type = CoreEnum.Result_Type.Success;
            return response;
        }

        public override GenericResponse<T> Update(GenericRequest<T> Request)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            try
            {
                GenericRequest<T> EntityRequest = new GenericRequest<T>();
                EntityRequest.ID = Request.Entity.ID;
                T willUpdated = this.GetByID(EntityRequest).Entity;

                _context.Entry(willUpdated).CurrentValues.SetValues(Request.Entity);
                _context.SaveChanges();
                response.Result_Type = CoreEnum.Result_Type.Success;
            }
            catch (Exception ex)
            {
                response.Result_Type = CoreEnum.Result_Type.Failed;
                response.Message = ex.Message.ToString();
            }
            finally
            {
                response.Entity = Request.Entity;
            }
            return response;
        }

        public override GenericResponse<T> ActivateEntity(GenericRequest<T> Request)
        {
            GenericResponse<T> response = new GenericResponse<T>();

            try
            {
                GenericRequest<T> EntityRequest = new GenericRequest<T>();
                EntityRequest.ID = Request.ID;
                T willUpdated = this.GetByID(EntityRequest).Entity;
                willUpdated.Status = Status_Type.Active;

                Request.Entity = willUpdated;

                _context.Entry(willUpdated).CurrentValues.SetValues(Request.Entity);
                _context.SaveChanges();
                response.Result_Type = Result_Type.Success;
            }
            catch (Exception ex)
            {
                response.Result_Type = AppCore.CoreEnum.Result_Type.Failed;
                response.Entity = null;
                response.Message = ex.Message.ToString();
            }

            return response;
        }

        public override GenericResponse<T> DisableEntity(GenericRequest<T> Request)
        {
            GenericResponse<T> response = new GenericResponse<T>();

            try
            {
                GenericRequest<T> EntityRequest = new GenericRequest<T>();
                EntityRequest.ID = Request.ID;
                T willUpdated = this.GetByID(EntityRequest).Entity;
                willUpdated.Status = Status_Type.Passive;

                Request.Entity = willUpdated;

                _context.Entry(willUpdated).CurrentValues.SetValues(Request.Entity);
                _context.SaveChanges();
                response.Result_Type = Result_Type.Success;
            }
            catch (Exception ex)
            {
                response.Result_Type = AppCore.CoreEnum.Result_Type.Failed;
                response.Entity = null;
                response.Message = ex.Message.ToString();
            }

            return response;
        }
    }
}