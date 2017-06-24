using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELTTurkey.Entity
{
    public class SystemControllerAction : Core.Entity.Entity
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Method { get; set; }
    }
}
