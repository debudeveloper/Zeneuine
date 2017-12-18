using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
   public class RoleMaster : BaseEntity
    {
        public int Name { get; set; }
        public string Descriptions { get; set; }
       public ICollection<UserRole> UserRoles { get; set; }

    }
}