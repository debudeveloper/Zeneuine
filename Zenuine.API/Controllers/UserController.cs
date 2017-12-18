using CustomerModule.Service;
using EntityObjects.Objects;
using EntityObjects.UtilityObjects;
using SmtpEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using UserModule.Models;
using UserModule.Serives;
using UtilityBusiness;
using Zenuine.API.Common;

namespace Zenuine.API.Controllers
{
    [RoutePrefix("users")]
    public class UserController : ApiController
    {
      private static readonly IUserService _user = new UserService();
      private static readonly ICustomerService _customer= new CustomerService();
        public IHttpActionResult SvaeUsers(UserMasterDto model)
        {
            if (model != null)
            {
               bool isExist= _user.IsAlreadyEXists(model.PhoneNumber);

                if (isExist)
                {
                    return Content(HttpStatusCode.BadRequest,ServiceResponse.BadRequest);
                }
                int userId = _user.SaveUser(model); 
            }

            return Ok(); 
        }
        [Route("GetUser", Name = "GetUsers")]
        [HttpGet]
        public IHttpActionResult GetUsers(string Phone, int Id = 0)
        {
            var data = _user.GetUserByPhoneNumberOrId(Phone,Id);
            if(data!=null)
            return Ok(data);
            return Content(HttpStatusCode.NotFound, ServiceResponse.notFound);
        }

        [Route("GetAllUsers", Name = "GetAllUsers")]
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            var data = _user.GetAllUser();
            if (data != null)
                return Ok(data);
            return Content(HttpStatusCode.NotFound, ServiceResponse.notFound);
        }


        [HttpPost, Route("ForgetPassword", Name = "ForgetPassword")]
        public IHttpActionResult ForgetPassword(string Phone)
        {
            var data = _user.GetUserByPhoneNumber(Phone);

            if(data !=null)
            {
                var varyfyCode = UtilityMethods.GenerateRandomString(4);
               // will update encode and decode coversation
                return Ok(new { Name = data.Name, Id = data.Id, PhoneNumber = data.PhoneNumber, Code = varyfyCode });

            }
            return Content(HttpStatusCode.BadRequest, "phone not found");
        }
        [HttpPost, Route("ResetPassword", Name = "ResetPassword")]
        public IHttpActionResult ResetPassword(UserMasterDto model)
        {
            var data = _user.GetUserByPhoneNumber(model.PhoneNumber);
            if(data.PhoneNumber==model.PhoneNumber && data.VeryfiCode.Equals(model.VeryfiCode))
            {
                var _mailMsg = new EmailMessage();
                _mailMsg.email_body = "Reset Password";
                
                Emailer.SendMail(_mailMsg);
            }

            if (data != null)
            {
                var varyfyCode = UtilityMethods.GenerateRandomString(4);

                return Ok(new { Name = data.Name, Id = data.Id, PhoneNumber = data.PhoneNumber, Code = varyfyCode });

            }
            return Content(HttpStatusCode.BadRequest, "email not found");
        }

        [HttpPost]
        public IHttpActionResult UpdateUser(UserMasterDto model)
        {
            
            return Ok();
        }
    }
}