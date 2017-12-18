using AutoMapper;
using CustomerModule.Service;
using EntityObjects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerModule.Models
{
    class CustomerMapper : ICustomerMapper
    {
        private static readonly ICustomerService _userService = new CustomerService();

        public CustomerMapper()
        {
        }
        public CustomerDto MapToCustomerDto(Customer userEntity)
        {
            //map common fields
            var user = Mapper.Map<CustomerDto>(userEntity);


            return user;
        }
        public Customer MapToCustomer(CustomerDto userEntity)
        {
            //map common fields
            var user = Mapper.Map<Customer>(userEntity);


            return user;
        }
    }
    public interface ICustomerMapper
    {
        Customer MapToCustomer(CustomerDto user);
        CustomerDto MapToCustomerDto(Customer model);

    }

}
