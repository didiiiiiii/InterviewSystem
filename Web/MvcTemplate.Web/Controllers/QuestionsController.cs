namespace InterviewSystem.Web.Controllers
{
    using System.Web.Mvc;

    using InterviewSystem.Services.Data;
    using InterviewSystem.Web.Infrastructure.Mapping;
    using InterviewSystem.Web.ViewModels.Questions;

    public class QuestionsController : BaseController
    {
        private readonly IQuestionsService questions;
        private readonly IQuestionTypesService questionTypes;
        private readonly IQuestionLevelsService questionLevels;

        public QuestionsController(
            IQuestionsService questions,
            IQuestionTypesService questionTypes,
            IQuestionLevelsService questionLevels)
        {
            this.questions = questions;
            this.questionTypes = questionTypes;
            this.questionLevels = questionLevels;
        }

        [Authorize]
        public ActionResult Index()
        {
            var questions = this.questions.GetRandomQuestions(3).To<QuestionViewModel>(); //.ToList();
            var questionTypes =
                this.Cache.Get(
                    "types",
                    () => this.questionTypes.GetAll().To<QuestionTypeViewModel>(), //.ToList(),
                    30 * 60);
            var questionLevels =
                this.Cache.Get(
                    "levels",
                    () => this.questionLevels.GetAll().To<QuestionLevelViewModel>(), //.ToList(),
                    30 * 60);
            var viewModel = new QuestionsViewModel
            {
                Questions = questions,
                Types = questionTypes,
                Levels = questionLevels
            };

            return this.View(viewModel);
        }
        public ActionResult ById(string id)
        {
            var question = this.questions.GetById(id);
            var viewModel = this.Mapper.Map<QuestionViewModel>(question);
            return this.View(viewModel);
        }
    }
}
