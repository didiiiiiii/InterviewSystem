using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InterviewSystem.Web.Controllers
{
    public class ErrorController : BaseController
    {
        public ActionResult Error()
        {
            return this.View();
        }
    }
}
