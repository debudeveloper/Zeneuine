using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
   public class UserRole :BaseEntity
    {
        public int UserMasterId { get; set; }
        public int RoleMasterId { get; set; }
        public UserMaster UserMaster { get; set; }
        public RoleMaster RoleMaster { get; set; }

    }
}
