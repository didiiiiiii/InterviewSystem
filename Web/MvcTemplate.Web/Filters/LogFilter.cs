using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace InterviewSystem.Web.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        private string filePath = HttpContext.Current.Server.MapPath("~/AppData/Log.txt");

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            File.AppendAllLines(filePath, new[] { "OnActionExecuting" });
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            File.AppendAllLines(filePath, new[] { "OnActionExecuted" });
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            File.AppendAllLines(filePath, new[] { "OnResultExecuting" });
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            File.AppendAllLines(filePath, new[] { "OnResultExecuted" });
            base.OnResultExecuted(context);
        }
    }
}