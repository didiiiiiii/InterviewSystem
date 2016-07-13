namespace InterviewSystem.Web.ViewModels.Questions
{
    using AutoMapper;
    using InterviewSystem.Data.Models;
    using InterviewSystem.Services.Web;
    using InterviewSystem.Web.Infrastructure.Mapping;

    public class QuestionTypeViewModel : IMapFrom<QuestionType>
    {
        public int Id { get; set; }

        public string QuestionTypeName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<QuestionType, QuestionTypeViewModel>()
                .ForMember(x => x.QuestionTypeName, opt => opt.MapFrom(x => x.QuestionTypeName));
        }
    }
}
