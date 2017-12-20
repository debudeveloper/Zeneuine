using AutoMapper;
using EntityObjects.Objects;
using Modules.Admin.Service;
using Modules.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Admin.Models
{
    class CustomerMapper : ICustomerMapper
    {
        private static readonly ICustomerService _userService = new CustomerService();

        public CustomerMapper()
        {
        }
        public InputCustomerDto MapToCustomerDto(Customer userEntity)
        {
            //map common fields
            var user = Mapper.Map<InputCustomerDto>(userEntity);


            return user;
        }
        public Customer MapToCustomer(InputCustomerDto userEntity)
        {
            //map common fields
            var user = Mapper.Map<Customer>(userEntity);


            return user;
        }
    }
    public interface ICustomerMapper
    {
        Customer MapToCustomer(InputCustomerDto user);
        InputCustomerDto MapToCustomerDto(Customer model);

    }

}
