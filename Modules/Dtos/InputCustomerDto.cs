using EntityObjects.UtilityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Dtos
{
  public class InputCustomerDto
    {
        public int Id { get; set; }
        public int UserMasterId { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
