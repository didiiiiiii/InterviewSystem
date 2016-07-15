namespace InterviewSystem.Web.ViewModels.Questions
{
    using AutoMapper;
    using InterviewSystem.Data.Models;
    using InterviewSystem.Services.Web;
    using InterviewSystem.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    public class QuestionViewModel : IMapFrom<Question>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Content { get; set; }

        public int QuestionTypeId { get; set; }

        public int QuestionLevelId { get; set; }

        [Range(0, 1)]
        public double Weight { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Question, QuestionViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForMember(x => x.Weight, opt => opt.MapFrom(x => x.Weight))
                .ForMember(x => x.QuestionTypeId, opt => opt.MapFrom(x => x.TypeId))
                .ForMember(x => x.QuestionLevelId, opt => opt.MapFrom(x => x.LevelId));                
        }
    }
}
