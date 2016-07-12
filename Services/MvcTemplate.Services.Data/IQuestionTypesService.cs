namespace InterviewSystem.Services.Data
{
    using System.Linq;

    using InterviewSystem.Data.Models;

    public interface IQuestionTypesService
    {
        IQueryable<QuestionType> GetAll();

        QuestionType EnsureType(string name);
    }
}
