namespace InterviewSystem.Web.Controllers
{
    using System.Web.Mvc;

    using InterviewSystem.Services.Data;
    using InterviewSystem.Web.Infrastructure.Mapping;
    using InterviewSystem.Web.ViewModels.Questions;
    using Data.Models;
    using System;
    public class QuestionsController : BaseController
    {
        private InterviewSystemEntites db = new InterviewSystemEntites();

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
            var viewModel = new IndexViewModel
            {
                Questions = questions,
                Types = questionTypes,
                Levels = questionLevels
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet, ActionName("ById")]
        public ActionResult ById(int id)
        {
            var question = this.questions.GetById(id);
            var viewModel = this.Mapper.Map<QuestionViewModel>(question);
            return this.View(viewModel);
        }

        [Authorize]    
        public ActionResult Create()
        {
            var viewModel = new QuestionViewModel
            {
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Question question)
        {
            if (this.ModelState.IsValid)
            {              
                question.Level = new QuestionLevel();
                question.Level.Id = 3;

                question.Type = new QuestionType();
                question.Type.Id = 2;

                question.CreatedOn = DateTime.Now.Date;
                question.ModifiedOn = DateTime.Now;
                question.IsDeleted = false;
                question.DeletedOn = null;

                db.Questions.Add(question);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
           // ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            //ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return this.View(question);
        }

        [Authorize]
        public ActionResult Edit()
        {
            var viewModel = new QuestionViewModel
            {
            };

            return this.View(viewModel);
        }

        [Authorize]
        public ActionResult Delete()
        {
            var viewModel = new QuestionViewModel
            {
            };

            return this.View(viewModel);
        }
    }
}
