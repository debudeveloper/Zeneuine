using EntityObjects.UtilityObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Dtos
{
  public class InputUserMasterDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public UserType Type { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required")]


        public string Password { get; set; }
        [Required(ErrorMessage = "City is required")]

        public string City { get; set; }

        public string VeryfiCode { get; set; } = string.Empty;
    }
}
