using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using KHSC_Jasper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KHSC_Jasper.Filters
{
    public class CanManageAdmission : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            Controller controller = context.Controller as Controller;
            if (controller.HttpContext.Session.GetInt32("role") != (int)Role.Register)
            {
                context.Result = controller.RedirectToAction("Login", "Auth");
            }

        }
    }
}
