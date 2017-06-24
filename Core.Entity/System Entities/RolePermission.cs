using System.ComponentModel.DataAnnotations.Schema;

namespace ELTTurkey.Entity
{
    public class RolePermission : Core.Entity.Entity
    {
        public int ControllerActionID { get; set; }
        public int RoleID { get; set; }

        [ForeignKey("ControllerActionID")]
        public SystemControllerAction SystemControllerAction { get; set; }

        [ForeignKey("RoleID")]
        public SystemRoles SystemRoles { get; set; }
    }
}
