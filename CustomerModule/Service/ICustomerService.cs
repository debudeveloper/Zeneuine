using CustomerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerModule.Service
{
   public interface ICustomerService
    {
        List<CustomerDto> GetAllCustomer();
        CustomerDto GetCustomerByUserId(int id);
        int SaveCustomer(CustomerDto user);
      

    }
}
