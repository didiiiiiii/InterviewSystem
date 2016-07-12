namespace InterviewSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class AdministrationViewModel
    {
        public IEnumerable<QuestionViewModel> Questions { get; set; }

        public IEnumerable<QuestionTypeViewModel> Types { get; set; }

        public IEnumerable<QuestionLevelViewModel> Levels { get; set; }
    }
}
