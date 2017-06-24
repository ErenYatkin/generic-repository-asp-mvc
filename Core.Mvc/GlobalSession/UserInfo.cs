using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mvc.GlobalSession
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int ID { get; set; }
        //public List<string> UserRoles { get; set; }

        public List<string> SystemRoleActionPermissions { get; set; }
    }
}
