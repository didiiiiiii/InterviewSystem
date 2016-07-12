namespace InterviewSystem.Web.Controllers
{
    using System.Web.Mvc;

    using InterviewSystem.Services.Data;
    using InterviewSystem.Web.Infrastructure.Mapping;
    using InterviewSystem.Web.ViewModels.Home;

    public class QuestionsController : BaseController
    {
        private readonly IQuestionsService questions;

        public QuestionsController(
            IQuestionsService questions)
        {
            this.questions = questions;
        }

        public ActionResult ById(string id)
        {
            var question = this.questions.GetById(id);
            var viewModel = this.Mapper.Map<QuestionViewModel>(question);
            return this.View(viewModel);
        }
    }
}
