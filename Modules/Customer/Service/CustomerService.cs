using EntityDataAccess.Core;
using EntityObjects.Objects;
using Modules.Admin.Models;
using Modules.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Admin.Service
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
        public List<InputCustomerDto> GetAllCustomer()
        {
            return null;
        }
        public InputCustomerDto GetCustomerByUserId(int id)
        {
            return null;
        }
        public int SaveCustomer(InputCustomerDto model)
        {
            Customer entity = _userMapper.MapToCustomer(model);
            _context.Customers.Add(entity);
            return _context.SaveChanges();

        }
    }
}
