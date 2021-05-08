using System.Net;

using Microsoft.AspNetCore.Mvc;

namespace ZwiftSteero.Service.Extensions
{

    public static class ControllerBaseExtensions
    {
        [NonAction]
        public static StatusCodeResult StatusCode(this ControllerBase controller,
            HttpStatusCode statusCode)
        {
            return controller.StatusCode((int)statusCode);
        }
    }
}