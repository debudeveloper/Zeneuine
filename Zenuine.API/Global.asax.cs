using AutoMapper;

using EntityObjects.Objects;
using Modules.Admin.Mapping;
using Modules.User.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
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
