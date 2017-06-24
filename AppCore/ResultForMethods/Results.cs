using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.ResultForMethods
{
    /// <summary>
    /// This class is used to return many item at once. 
    /// </summary>
    public class Results
    {
        public object ReturnObject { get; set; }
        public string Message { get; set; }
        public CoreEnum.Result_Type ResultType { get; set; }
    }
}
