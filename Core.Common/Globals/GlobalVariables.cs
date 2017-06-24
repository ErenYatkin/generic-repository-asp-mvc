using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class GlobalVariables
    {
        public static string ConnectionStringName { get; set; }
        public static string AppStartUpPath { get; set; }

        public static string RootFolder { get; set; }

        public const string UserSession = "LoggedInUser";
    }
}
