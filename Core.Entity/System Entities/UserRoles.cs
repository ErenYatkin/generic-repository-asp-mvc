using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELTTurkey.Entity
{
    public class UserRoles : Core.Entity.EntityHistorical
    {

        public int SystemUserID { get; set; }
        public int SystemRoleID { get; set; }

        [ForeignKey("SystemUserID")]
        public SystemUsers SystemUsers { get; set; }

        [ForeignKey("SystemRoleID")]
        public SystemRoles SystemRoles { get; set; }


    }
}
