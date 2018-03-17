using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Utils.ClientSide.Alerts;
using TaskManager.Utils.DependencyInjection;

namespace TaskManager.WebApplication.Filters
{
    public class UserFriendlyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            var factory = AppDependencyResolver.Current.GetService<ITempDataDictionaryFactory>();

            var alert = new SweetAlertBuilder("Um erro ocorreu! :(", context.Exception.Message, MessageType.Danger);
            ScriptManager.SetStartupScript(factory.GetTempData(context.HttpContext), alert.BuildScript());

            context.ExceptionHandled = true; // mark exception as handled
            context.Result = new RedirectResult($"/{controllerName}/{actionName}");
        }
    }
}
