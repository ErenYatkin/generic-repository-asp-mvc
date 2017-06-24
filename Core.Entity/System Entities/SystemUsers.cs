using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELTTurkey.Entity
{
    public class SystemUsers : Core.Entity.EntityHistorical
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public List<UserRoles> UserRoles { get; set; }

        [NotMapped]
        public List<RolePermission> SystemRoleActionPermissions { get; set; }

        [NotMapped]
        public List<SystemControllerAction> ControllerActionList { get; set; }
    }
}
