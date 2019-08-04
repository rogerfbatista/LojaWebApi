using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Loja.WebApi.Attribute;
using Loja.WebApi.Security;

namespace Loja.WebApi.Controllers.Base
{
    [ExceptionAttribute]
    [MyCorsPolicy]
    [AuthorizeRoles]
    public abstract class BaseController : ApiController
    {

    }
}