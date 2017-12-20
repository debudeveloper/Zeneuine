using EntityDataAccess.Core;
using EntityDataAccess.GenericRepository;
using EntityObjects.Objects;
using Modules.Admin.Service;
using Modules.Dtos;
using Modules.User.Services;
using SmtpEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

using UtilityBusiness;
using Zenuine.API.Common;
using Zenuine.API.Dtos;

namespace Zenuine.API.Controllers
{
    public class CustomerController : ApiController
    {
        private static readonly IUserService _user = new UserService();
        private static readonly ICustomerService _customer = new CustomerService();

        Emailer _email = new Emailer();

        [Route("SvaeCustomer", Name = "SvaeCustomer")]
        [HttpPost]
        public IHttpActionResult SvaeCustomer(InputCustomerDto model)
        {
            if (model != null || ModelState.IsValid)
            {
                bool isExist = _user.IsAlreadyEXists(model.PhoneNumber);

                if (isExist)
                {
                    var userModel = AutoMapper.Mapper.Map<InputUserMasterDto>(model);
                    model.UserMasterId = _user.SaveUser(userModel);
                    _customer.SaveCustomer(model);
  
                    return Content(HttpStatusCode.BadRequest, ServiceResponse.BadRequest);
                }



                return Content(HttpStatusCode.Accepted,ServiceResponse.OK);
            }

            return Content(HttpStatusCode.NotAcceptable,ModelState.Values);
        }
        [Route("GetCustomers", Name = "GetCustomers")]
        [HttpGet]
        public IHttpActionResult GetCustomers(string email, int id = 0)
        {
            if (email != null)
            {
                using (EFDbContext _ctx = new EFDbContext())
                {
                    var user = _ctx.Users.Where(m => m.Email == email || m.ID == id).FirstOrDefault();
                    if (user != null)
                    {
                        OutputCustomerDto data = AutoMapper.Mapper.Map<OutputCustomerDto>(user); // will update with new design
                        return Ok(data);

                    }
                }
            }

            return Content(HttpStatusCode.BadRequest, "Not Valid");
        }
        [Route("Login", Name = "Login")]
        [HttpGet]
        public IHttpActionResult Login(string phone, string password)
        {
            if (phone != null && password != null)
            {
                using (EFDbContext _ctx = new EFDbContext())
                {
                    var user = _ctx.Users.Where(m => m.PhoneNumber == phone || m.Password == password).FirstOrDefault();
                    if (user != null)
                    {
                        return Content(HttpStatusCode.Found, "Successfull login");

                    }
                }
            }

            return Content(HttpStatusCode.BadRequest, "Not Valid");
        }

        //[HttpPost, Route("ForgetPassword", Name = "ForgetPassword")]
        //public IHttpActionResult ForgetPassword(string email)
        //{
        //    using (EFDbContext _ctx = new EFDbContext())
        //    {
        //        var user = _ctx.Users.Where(m => m.Email.ToLower() == email.ToLower()).FirstOrDefault();
        //        if (user != null)
        //        {
        //            if (
        //                _utility.SendMail("deba.somu@gmail.com", email, "Pasword Reset", "Your Password :" + user.Password)
        //            )
        //                return Ok();
        //            return Content(HttpStatusCode.InternalServerError, "Somthing worng");
        //        }
        //    }
        //    return Content(HttpStatusCode.BadRequest, "email not found");
        //}

        [HttpPost]
        public IHttpActionResult UpdateCustomer(OutputCustomerDto model)
        {
            //var user = _ctx.Users.Where(m => m.Email.Equals(model.Email)).FirstOrDefault();
            //if (ModelState.IsValid)
            //{
            //    _ctx.Users.Attach(user);
            //    _ctx.Entry(user).State = System.Data.Entity.EntityState.Modified;
            //    _ctx.SaveChanges();
            //    return Content(HttpStatusCode.Accepted, "Successfullt done");
            //}
           return Content(HttpStatusCode.BadRequest, "User not found");
        }
    }
}
