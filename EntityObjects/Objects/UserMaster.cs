﻿using EntityObjects.UtilityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObjects.Objects
{
   public class UserMaster :BaseEntity
    {
        public string Name { get; set; }
        public UserType Type { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string VeryfiCode  { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
       // public ICollection<RoleMaster> RoleMasters { get; set; }

    }
}