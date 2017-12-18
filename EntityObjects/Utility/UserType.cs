using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.UtilityObjects
{
    public enum UserType
    {
       
        [Description("Admin")]
        Admin=1,
        [Description("Customer")]
        Customer,
        [Description("Technician")]
        Technician
    }
}
