using Modules.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Admin.Service
{
    public interface ICustomerService
    {
        List<InputCustomerDto> GetAllCustomer();
        InputCustomerDto GetCustomerByUserId(int id);
        int SaveCustomer(InputCustomerDto user);


    }
}
