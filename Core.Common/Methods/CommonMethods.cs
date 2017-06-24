using Core.Model.Context;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace Core.Common.Methods
{
    public class CommonMethods
    {
        public CommonMethods()
        {

        }

        public static object GetDbContext<T>()
        {
            BaseDbContext context = null;
            string nameOfEntityAssembly;
            string nameOfModelAssembly;
            Assembly asmEntity = null;
            Assembly asmModel = null;
            Type typeDbContext = null;

            try
            {
                nameOfEntityAssembly = typeof(T).Assembly.ManifestModule.Name;
                nameOfModelAssembly = nameOfEntityAssembly.Replace("Entity", "Model");

                asmEntity = Assembly.LoadFile(GlobalVariables.AppStartUpPath + "//" + nameOfEntityAssembly);
                asmModel = Assembly.LoadFile(GlobalVariables.AppStartUpPath + "//" + nameOfModelAssembly);

                typeDbContext = asmModel.GetTypes().Where(x => typeof(BaseDbContext).IsAssignableFrom(x)).FirstOrDefault();

                context = (BaseDbContext)Activator.CreateInstance(typeDbContext, new object[]
                {
                    ConfigurationManager.ConnectionStrings[GlobalVariables.ConnectionStringName].ToString()
                });
            }
            catch (Exception)
            {

                context = null;
            }

            return context;
        }

        public static void SetGlobalVariables()
        {
            try
            {
                GlobalVariables.ConnectionStringName = ConfigurationManager.AppSettings["ConnectionStringName"].ToString();

                GlobalVariables.AppStartUpPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\","");
            }
            catch (Exception)
            {
                GlobalVariables.ConnectionStringName = null;
                GlobalVariables.AppStartUpPath = null;
            }
        }
    }
}
