using AppCore.ResultForMethods;
using ELTTurkey.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Core.Mvc.MvcHelper
{
    public class ControllerTools
    {
        public Results GetControllerAction()
        {
            Results res = new Results();

            List<SystemControllerAction> ControllerActionList = new List<SystemControllerAction>();
            SystemControllerAction ControllerAction = new SystemControllerAction();

            var controllers = Assembly
                              .GetExecutingAssembly()
                              .GetExportedTypes()
                              .Where(t => typeof(ControllerBase).IsAssignableFrom(t))
                              .Select(t => t);

            foreach (Type controller in controllers)
            {
                var actions = controller
                              .GetMethods()
                              .Where(t => t.Name != "Dispose" &&
                              !t.IsSpecialName &&
                              t.DeclaringType.IsSubclassOf(typeof(ControllerBase)) &&
                              t.IsPublic &&
                              !t.IsStatic)
                              .ToList();
                foreach (var action in actions)
                {
                    ControllerAction = new SystemControllerAction();

                    ControllerAction.ControllerName = controller.Name.Replace("Controller", "");
                    ControllerAction.ActionName = action.Name;
                    ControllerAction.Status = AppCore.CoreEnum.Status_Type.Active;

                    var ActionAttributes = action
                                           .GetCustomAttributes()
                                           .ToList();
                    if (ActionAttributes.Count <= 0)
                    {
                        ControllerAction.Method = "GET";
                    }
                    foreach (var Attr in ActionAttributes)
                    {
                        string MethodName = ((Type)Attr.TypeId).Name;

                        if (MethodName.Contains("HttpGet") || MethodName == null)
                        {
                            ControllerAction.Method = "GET";
                        }
                        else if (MethodName.Contains("HttpPost"))
                        {
                            ControllerAction.Method = "POST";
                        }
                    }

                    ControllerActionList.Add(ControllerAction);
                }


            }

            return res;
        }
    }
}
