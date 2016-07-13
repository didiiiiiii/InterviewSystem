using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo;
using Kendo.Mvc;
using AutoMapper;

namespace InterviewSystem.Web.ViewModels.Questions
{
    public class IndexViewModel
    {
        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}