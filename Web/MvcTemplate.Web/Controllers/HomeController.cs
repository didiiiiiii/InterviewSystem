namespace InterviewSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IQuestionsService questions;
        private readonly IQuestionTypesService questionTypes;
        private readonly IQuestionLevelsService questionLevels;

        public HomeController(
            IQuestionsService questions,
            IQuestionTypesService questionTypes,
            IQuestionLevelsService questionLevels)
        {
            this.questions = questions;
            this.questionTypes = questionTypes;
            this.questionLevels = questionLevels;
        }

        public ActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
            };

            return this.View(viewModel);
        }

        [Authorize]
        public ActionResult Administration()
        {
            var questions = this.questions.GetRandomQuestions(3).To<QuestionViewModel>(); //.ToList();
            var questionTypes =
                this.Cache.Get(
                    "types",
                    () => this.questionTypes.GetAll().To<QuestionTypeViewModel>().ToList(),
                    30 * 60);
            var questionLevels =
                this.Cache.Get(
                    "levels",
                    () => this.questionLevels.GetAll().To<QuestionLevelViewModel>().ToList(),
                    30 * 60);
            var viewModel = new AdministrationViewModel
            {
                Questions = questions,
                Types = questionTypes,
                Levels = questionLevels
            };

            return this.View(viewModel);
        }

        public ActionResult Candidation()
        {
            var viewModel = new CandidationViewModel
            {
            };

           return this.View(viewModel);
        }

    }
}
