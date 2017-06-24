using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public interface IEntity
    {
        // Tüm Entityler tarafından kullanılacak olan Primary Key'i belirtmektedir
        [Key]
        int ID { get; set; }

        // Tüm Entitylerde statüyü belirtmek için kullanılacak olan alandır.
        AppCore.CoreEnum.Status_Type Status { get; set; }
    }
}
