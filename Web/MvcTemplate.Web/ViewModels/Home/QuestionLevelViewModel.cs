namespace InterviewSystem.Web.ViewModels.Home
{
    using AutoMapper;
    using InterviewSystem.Data.Models;
    using InterviewSystem.Services.Web;
    using InterviewSystem.Web.Infrastructure.Mapping;

    public class QuestionLevelViewModel : IMapFrom<QuestionLevel>
    {
        public int Id { get; set; }

        public string QuestionLevelName { get; set; }
    }
}