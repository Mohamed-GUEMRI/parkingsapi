using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace WebAPI_Parking.Controllers
{
    public class TokenAuthenticationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorisation(AuthorizationFilterContext context) {
            var tokenManager = (ITokenManager)context.HttpContext.RequestServices.GetService(typeof(ITokenManager));
            var result = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorised"))
                result = false;
            string token = string.Empty;
            if (result)
            {
                token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorisation").Value;
                if (!tokenManager.VerifyToken(token))
                    result = false;
            }
            if (!result)
            {
                context.ModelState.AddModelError("Unauthorised", "you are not authorized");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
        }
    }
}