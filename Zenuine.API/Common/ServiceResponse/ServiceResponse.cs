using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Zenuine.API.Common
{
    public enum ServiceResponse
    {
        [Description("Success")]
        OK = 200,

        [Description("Bad Request")]
        BadRequest = 400,

        [Description("Forbidden")]
        forbidden = 403,

        [Description("Server Error")]
        InternalServerError = 500,

        [Description("Not Found")]
        notFound = 404,

        [Description("Un Authorized")]
        Unauthorized = 401,

        [Description("General Error")]
        GeneralError = 999,

        [Description("Not Found")]
        DataNotFound = 99
    }
}
