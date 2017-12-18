using EntityObjects.UtilityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModule.Models
{
   public class UserMasterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string VeryfiCode { get; set; } = string.Empty;
    }
}
