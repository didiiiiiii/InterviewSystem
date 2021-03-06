﻿namespace InterviewSystem.Web.Controllers
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


    // [Authorize]
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
            ViewBag.ButtonText = "Create";
            SetQuestionPropertiesInViewBag();
            return this.View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] QuestionViewModel question)
        {
            ViewBag.ButtonText = "Create";

            if (this.ModelState.IsValid)
            {
                try
                {
                    var questionRequest = new Question
                    {
                        Content = question.Content,
                        Weight = question.Weight,
                        LevelId = question.QuestionLevelId,
                        TypeId = question.QuestionTypeId
                    };

                    this.questionsService.CreateQuestion(questionRequest);
                    TempData["UserMessage"] = "The item has been successfully created. ";
                    TempData["UserMessageStatus"] = "ok";

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["UserMessage"] = "The item cannot be created. ";
                    TempData["UserMessageStatus"] = "ko";
                }
            }

            SetQuestionPropertiesInViewBag();
            TempData["UserMessage"] = "The item cannot be created. ";
            TempData["UserMessageStatus"] = "ko";
            return this.View(question);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ButtonText = "Edit";
            SetQuestionPropertiesInViewBag();

            var question = this.questionsService.GetById(id);
            var viewModel = this.Mapper.Map<QuestionViewModel>(question);
            return this.View(viewModel);
        }

        [HttpPost]
        [LogFilter]
        public ActionResult Edit(QuestionViewModel questionViewModel)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var questionRequest = new Question
                    {
                        Id = questionViewModel.Id,
                        Content = questionViewModel.Content,
                        Weight = questionViewModel.Weight,
                        LevelId = questionViewModel.QuestionLevelId,
                        TypeId = questionViewModel.QuestionTypeId
                    };

                    this.questionsService.EditQuestion(questionRequest);
                    TempData["UserMessage"] = "The item has been successfully updated. ";
                    TempData["UserMessageStatus"] = "ok";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["UserMessage"] = "The item cannot be updated. ";
                    TempData["UserMessageStatus"] = "ko";
                }

            }

            ViewBag.ButtonText = "Edit";
            SetQuestionPropertiesInViewBag();

            var viewModel = this.Mapper.Map<QuestionViewModel>(questionViewModel);
            return this.View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            Question question = this.questionsService.GetById(id.Value);

            if (question == null)
            {
                return View("Error");
            }

            QuestionViewModel questionRequest = new QuestionViewModel
            {
                Content = question.Content,
                Weight = question.Weight,
                QuestionLevelId = question.LevelId,
                QuestionTypeId = question.TypeId
            };

            return View(questionRequest);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (this.questionsService.RemoveQuestion(id))
            {
                TempData["UserMessage"] = "The item has been successfully deleted. ";
                TempData["UserMessageStatus"] = "ok";

                return RedirectToAction("Index");
            }

            TempData["UserMessage"] = "The item cannot be deleted. ";
            TempData["UserMessageStatus"] = "ko";
            return this.View();
        }
    }
}
