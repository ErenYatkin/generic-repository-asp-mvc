using Core.Common;
using Core.Contract;
using Core.Entity;
using Core.Mvc.CustomAttributes;
using Core.Mvc.GlobalSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Core.Mvc
{
    public class BaseController<T> : Controller where T : Entity.Entity
    {
        public Business.BusinessBase.BaseBusiness<T> _business;

        public BaseController()
        {
            // Loads the system parameters.
            Core.Common.Methods.CommonMethods.SetGlobalVariables();

            // Instance of the GenericBusiness 
            _business = new Business.BusinessBase.BaseBusiness<T>();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // To decide UI is admin panel or public UI
            bool ControlAttribute = false;

            base.OnActionExecuting(filterContext);

            #region Get actions custom attributes
            var CustomAttributes = filterContext.ActionDescriptor.GetCustomAttributes(true);

            foreach (var item in CustomAttributes)
            {
                if (item.GetType() == typeof(NoSecure))
                {
                    ControlAttribute = true;
                }
            }
            #endregion

            // If controllerAttribute is false that means the executing action is in the admin panel
            // if it's true that means the executing action is in the public UI
            if (ControlAttribute == false)
            {
                // Session control for AdminPanel
                var session = Session[GlobalVariables.UserSession];

                if (session == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Security",
                        action = "Login"
                    }));
                }
                else
                {
                    //Get logged in user information from session
                    UserInfo userInfo = (UserInfo)Session[GlobalVariables.UserSession];

                    var descriptor = filterContext.ActionDescriptor;
                    var actionName = descriptor.ActionName;
                    var controllerName = descriptor.ControllerDescriptor.ControllerName;
                    var methodType = filterContext.HttpContext.Request.HttpMethod;

                    // create a route from the variables above
                    string CurrentAction = controllerName + "/" + actionName + "/" + methodType;

                    if (userInfo.SystemRoleActionPermissions.Any(x => x.ToString() == CurrentAction))
                    {
                        // Do nothing
                    }
                    else
                    {
                        // if users does not have the permission then redirect to AuthError Page
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Error",
                            action = "AuthError"
                        }));
                    }

                }
            }
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            GenericResponse<T> response = new GenericResponse<T>();
            GenericRequest<T> request = new GenericRequest<T>();

            response = _business.GetActives(request);
            return View("Index", response);
        }

        [HttpGet]
        public virtual ActionResult Save(int? ID)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            GenericRequest<T> request = new GenericRequest<T>();
            if (ID > 0)
            {

                request.ID = ID.GetValueOrDefault();
                response = _business.GetByID(request);
                return View("Save", response);
            }
            else
            {
                return View("Save");
            }

        }

        [HttpPost]
        public virtual ActionResult Save(T entity)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            GenericRequest<T> request = new GenericRequest<T>();
            request.Entity = entity;

            if (entity.ID > 0)
            {
                response = _business.Update(request);
            }
            else
            {
                response = _business.Add(request);
            }

            return RedirectToAction("Index");
        }

        public virtual ActionResult Details(int ID)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            GenericRequest<T> request = new GenericRequest<T>();

            request.ID = ID;
            response = _business.GetByID(request);
            return View(response);
        }

        public virtual ActionResult SoftDelete(T entity)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            GenericRequest<T> request = new GenericRequest<T>();

            entity.Status = AppCore.CoreEnum.Status_Type.Deleted;
            request.Entity = entity;

            response = _business.SoftDelete(request);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public virtual JsonResult ActivateEntity(int EntityID, bool isActivated)
        {
            GenericResponse<T> response = new GenericResponse<T>();
            GenericRequest<T> request = new GenericRequest<T>();

            if (EntityID > 0)
            {
                if (isActivated)
                {
                    request.ID = EntityID;

                    response = _business.ActivateEntity(request);
                }
                else
                {
                    request.ID = EntityID;

                    response = _business.DisableEntity(request);
                }
            }

            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }
    }
}
