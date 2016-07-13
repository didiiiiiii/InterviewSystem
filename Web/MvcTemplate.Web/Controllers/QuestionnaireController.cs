using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewSystem.Web.ViewModels.Questionnaire;

namespace InterviewSystem.Web.Controllers
{
    public class QuestionnaireController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
            };

            return this.View(viewModel);
        }
    }
}