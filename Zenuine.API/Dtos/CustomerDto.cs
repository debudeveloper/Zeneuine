using EntityObjects.UtilityObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zenuine.API.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="please Provide a valid Name")]
        public string Name { get; set; }
        public UserType Type { get; set; }
        [Required(ErrorMessage = "please Provide a valid Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "please Provide a valid Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "please Provide a valid City")]
        public string City { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
    }
}