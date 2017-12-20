using EntityObjects.UtilityObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zenuine.API.Dtos
{
    public class OutputCustomerDto
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public UserType Type { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string City { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
    }
}