namespace InterviewSystem.Web.Controllers
{
    using System.Web.Mvc;

    using InterviewSystem.Services.Data;
    using InterviewSystem.Web.Infrastructure.Mapping;
    using InterviewSystem.Web.ViewModels.Questions;
    using InterviewSystem.Web.Filters;
    using Data.Models;
    using System;
    using Data;
    using System.Net;
    using System.Linq;


    [Authorize]
    [LogFilter]
    public class QuestionsController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private readonly IQuestionsService questionsService;
        private readonly IQuestionTypesService questionTypes;
        private readonly IQuestionLevelsService questionLevels;

        public QuestionsController(
            IQuestionsService questions,
            IQuestionTypesService questionTypes,
            IQuestionLevelsService questionLevels)
        {
            this.questionsService = questions;
            this.questionTypes = questionTypes;
            this.questionLevels = questionLevels;
        }

        public void SetQuestionPropertiesInViewBag()
        {
            var questionLevels = this.Cache.Get(
                            "levels",
                             () => this.questionLevels.GetAll().To<QuestionLevelViewModel>().ToList(),
                            30 * 60);
            var questionTypes = this.Cache.Get(
                    "types",
                     () => this.questionTypes.GetAll().To<QuestionTypeViewModel>().ToList(),
                    30 * 60);

            ViewBag.QuestionLevels = new SelectList(questionLevels, "Id", "QuestionLevelName");
            ViewBag.QuestionTypes = new SelectList(questionTypes, "Id", "QuestionTypeName");
        }

        public ActionResult Index()
        {
            var questions = this.questionsService.GetAll().To<QuestionViewModel>();

            var viewModel = new IndexViewModel
            {
                Questions = questions
            };

            return this.View(viewModel);
        }

        [HttpGet, ActionName("ById")]
        public ActionResult ById(int id)
        {
            var question = this.questionsService.GetById(id);
            var viewModel = this.Mapper.Map<QuestionViewModel>(question);
            return this.View(viewModel);
        }

        public ActionResult Create()
        {

            SetQuestionPropertiesInViewBag();
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(QuestionViewModel question)
        {
            if (this.ModelState.IsValid)
            {
                var questionRequest = new Question
                {
                    Content = question.Content,
                    Weight = question.Weight,
                    LevelId = question.QuestionLevelId,
                    TypeId = question.QuestionTypeId
                };

                this.questionsService.CreateQuestion(questionRequest);

                return RedirectToAction("Index");
            }

            SetQuestionPropertiesInViewBag();
            return this.View(question);


        }

        public ActionResult Edit()
        {
            var viewModel = new QuestionViewModel
            {
            };

            return this.View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = this.questionsService.GetById(id.Value);
            QuestionViewModel questionRequest = new QuestionViewModel
            {
                Content = question.Content,
                Weight = question.Weight,
                QuestionLevelId = question.LevelId,
                QuestionTypeId = question.TypeId
            };
            if (question == null)
            {
                ViewBag.Title = "Not found question!";
            }
            return View(questionRequest);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.questionsService.RemoveQuestion(id);

            return RedirectToAction("Index");
        }
    }
}
