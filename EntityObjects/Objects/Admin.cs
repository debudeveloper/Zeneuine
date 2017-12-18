using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
    public class Admin : BaseEntity
    {
        public int UsermasterId { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public UserMaster UserMaster { get; set; }
    }
}
