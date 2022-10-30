using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Parking.Controllers
{
    public class AuthenticationFilterContext
    {
        public object HttpContent { get; internal set; }
        public UnauthorizedObjectResult Result { get; internal set; }
        public object ModelState { get; internal set; }
    }
}