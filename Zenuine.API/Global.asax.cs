using AutoMapper;
using CustomerModule.Mapping;
using EntityObjects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using UserModule.Mapping;
using UserModule.Models;
using Zenuine.API.Common;

namespace Zenuine.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Mapper.Initialize(c =>
            {
                c.AddProfile<MappingProfile>();
                c.AddProfile<UserMappgingProfile>();
                c.AddProfile<CustomerMappingProfile>();
            });
        }
    }
}
