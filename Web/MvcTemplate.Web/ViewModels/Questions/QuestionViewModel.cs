namespace InterviewSystem.Web.ViewModels.Questions
{
    using AutoMapper;
    using InterviewSystem.Data.Models;
    using InterviewSystem.Services.Web;
    using InterviewSystem.Web.Infrastructure.Mapping;

    public class QuestionViewModel : IMapFrom<Question>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string QuestionType { get; set; }

        public string QuestionLevel { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                //return $"/Question/{identifier.EncodeId(this.Id)}";
                return $"/Question/{this.Id}";
            }
        }

        public double Weight{ get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Question, QuestionViewModel>()
                .ForMember(x => x.QuestionType, opt => opt.MapFrom(x => x.Type.QuestionTypeName)).ForMember(x => x.QuestionLevel, opt => opt.MapFrom(x => x.Level.QuestionLevelName));
        }
    }
}
