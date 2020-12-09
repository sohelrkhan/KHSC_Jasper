using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace KHSC_Jasper.Filters
{
    public class RedirectIfAuthenticated : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            Controller controller = context.Controller as Controller;
            if (controller.HttpContext.Session.GetInt32("IsAuthenticated") == 1) {
                context.Result = controller.RedirectToAction("Index", "Home");
            }
        }
    }
}
