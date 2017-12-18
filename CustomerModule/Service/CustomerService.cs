using AutoMapper;
using CustomerModule.Models;
using EntityDataAccess.Core;
using EntityObjects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerModule.Service
{
 public class CustomerService : ICustomerService
    {
        private readonly EFDbContext _context = null;
        private static readonly ICustomerMapper _userMapper = new CustomerMapper();

        public CustomerService() : this(new EFDbContext())
        {

        }
        public CustomerService(EFDbContext context)
        {
            _context = context;
        }
        public List<CustomerDto> GetAllCustomer()
        {
            return null;
        }
        public CustomerDto GetCustomerByUserId(int id)
        {
            return null;
        }
        public int SaveCustomer(CustomerDto model)
        {
            Customer entity = _userMapper.MapToCustomer(model);
           _context.Customers.Add(entity);
         return _context.SaveChanges();
                 
        }
    }
}
