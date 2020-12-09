using KHSC_Jasper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KHSC_Jasper.Filters
{
    public class AttachViewData : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            Controller controller = context.Controller as Controller;

            controller.ViewBag.IsAuthenticated = controller.HttpContext.Session.GetInt32("IsAuthenticated") == 1;
            controller.ViewBag.IsRegister = controller.HttpContext.Session.GetInt32("role") == (int)Role.Register;
            controller.ViewBag.IsTeacher = controller.HttpContext.Session.GetInt32("role") == (int)Role.Teacher;
            controller.ViewBag.IsStudent = controller.HttpContext.Session.GetInt32("role") == (int)Role.Student;
        }
    }
    
    }

