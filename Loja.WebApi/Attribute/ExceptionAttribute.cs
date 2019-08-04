using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Loja.WebApi.Attribute
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            throw new HttpResponseException(
             context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception.Message));
           
        }
    }
}