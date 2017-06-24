using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Entity : IEntity
    {
        public int ID { get; set; }
        public AppCore.CoreEnum.Status_Type Status { get; set; }
    }
}
