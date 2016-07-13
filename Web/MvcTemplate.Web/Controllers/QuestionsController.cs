namespace InterviewSystem.Web.Controllers
{
    using System.Web.Mvc;

    using InterviewSystem.Services.Data;
    using InterviewSystem.Web.Infrastructure.Mapping;
    using InterviewSystem.Web.ViewModels.Questions;
    using Data.Models;
    using System;
    using Data;

    [Authorize]
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
            var questionLevels =
                  this.Cache.Get(
                      "levels",
                      () => this.questionLevels.GetAll().To<QuestionLevelViewModel>(), //.ToList(),
                      30 * 60);
            var questionTypes =
                this.Cache.Get(
                    "types",
                    () => this.questionTypes.GetAll().To<QuestionTypeViewModel>(), //.ToList(),
                    30 * 60);

            var viewModel = new QuestionViewModel
            {
            };

            return this.View(viewModel);
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
                    LevelId =  question.QuestionLevelId,
                    TypeId = question.QuestionTypeId
                };              

                db.Questions.Add(questionRequest);
                db.SaveChanges();

                //return RedirectToAction("Index");
            }

            //ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            //ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return this.View(question);
        }

        public ActionResult Edit()
        {
            var viewModel = new QuestionViewModel
            {
            };

            return this.View(viewModel);
        }

        public ActionResult Delete()
        {
            var viewModel = new QuestionViewModel
            {
            };

            return this.View(viewModel);
        }
    }
}
