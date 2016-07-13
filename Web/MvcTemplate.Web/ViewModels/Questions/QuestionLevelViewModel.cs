namespace InterviewSystem.Web.ViewModels.Questions
{
    using AutoMapper;
    using InterviewSystem.Data.Models;
    using InterviewSystem.Services.Web;
    using InterviewSystem.Web.Infrastructure.Mapping;

    public class QuestionLevelViewModel : IMapFrom<QuestionLevel>
    {
        public int Id { get; set; }

        public string QuestionLevelName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<QuestionLevel, QuestionLevelViewModel>()
                .ForMember(x => x.QuestionLevelName, opt => opt.MapFrom(x => x.QuestionLevelName));
        }
    }
}