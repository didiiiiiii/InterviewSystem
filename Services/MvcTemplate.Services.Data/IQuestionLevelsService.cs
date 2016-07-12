namespace InterviewSystem.Services.Data
{
    using System.Linq;

    using InterviewSystem.Data.Models;

    public interface IQuestionLevelsService
    {
        IQueryable<QuestionLevel> GetAll();

        QuestionLevel EnsureLevel(string name);
    }
}
