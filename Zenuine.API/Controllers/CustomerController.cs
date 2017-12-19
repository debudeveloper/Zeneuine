using EntityDataAccess.Core;
using EntityDataAccess.GenericRepository;
using EntityObjects.Objects;
using SmtpEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

using UtilityBusiness;
using Zenuine.API.Dtos;

namespace Zenuine.API.Controllers
{
    public class CustomerController : ApiController
    {
        EFDbContext _ctx = new EFDbContext();
        UtilityMethods _utility = new UtilityMethods();
        Emailer _email = new Emailer();

        [Route("SvaeUsers", Name = "SvaeUsers")]
        [HttpPost]
        public IHttpActionResult SvaeUsers(CustomerDto model)
        {
            if (model != null || ModelState.IsValid)
            {
                using (EFDbContext _ctx = new EFDbContext())
                {
                    var user = AutoMapper.Mapper.Map<UserMaster>(model);
                    _ctx.Users.Add(user);
                    var id = _ctx.SaveChanges();
                }
            }

            return Ok();
        }
        [Route("GetUsers", Name = "GetUsers")]
        [HttpGet]
        public IHttpActionResult GetUsers(string email, int id = 0)
        {
            if (email != null)
            {
                using (EFDbContext _ctx = new EFDbContext())
                {
                    var user = _ctx.Users.Where(m => m.Email == email || m.ID == id).FirstOrDefault();
                    if (user != null)
                    {
                        return Ok(user);

                    }
                }
            }

            return Content(HttpStatusCode.BadRequest,"Not Valid");
        }
        [Route("Login", Name = "Login")]
        [HttpGet]
        public IHttpActionResult Login(string phone, string password)
        {
            if (phone != null && password !=null)
            {
                using (EFDbContext _ctx = new EFDbContext())
                {
                    var user = _ctx.Users.Where(m => m.PhoneNumber == phone || m.Password == password).FirstOrDefault();
                    if (user != null)
                    {
                        return Content(HttpStatusCode.Found,"Successfull login");

                    }
                }
            }

            return Content(HttpStatusCode.BadRequest, "Not Valid");
        }

        [HttpPost, Route("ForgetPassword", Name = "ForgetPassword")]
        public IHttpActionResult ForgetPassword(string email)
        {
            using (EFDbContext _ctx = new EFDbContext())
            {
                var user = _ctx.Users.Where(m => m.Email.ToLower() == email.ToLower()).FirstOrDefault();
                if (user != null)
                {
                    if (
                        _utility.SendMail("deba.somu@gmail.com",email,"Pasword Reset","Your Password :"+user.Password)
                    )
                        return Ok();
                    return Content(HttpStatusCode.InternalServerError, "Somthing worng");
                }
            }
            return Content(HttpStatusCode.BadRequest, "email not found");
        }

        [HttpPost]
        public IHttpActionResult UpdateUser(CustomerDto model)
        {
            var user = _ctx.Users.Where(m => m.Email.Equals(model.Email)).FirstOrDefault();
            if (ModelState.IsValid)
            {
                _ctx.Users.Attach(user);
                _ctx.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _ctx.SaveChanges();
                return Content(HttpStatusCode.Accepted, "Successfullt done");
            }
            return Content(HttpStatusCode.BadRequest, "User not found");
        }
    }
}
