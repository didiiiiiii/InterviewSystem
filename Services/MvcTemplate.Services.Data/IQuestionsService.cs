namespace InterviewSystem.Services.Data
{
    using System.Linq;

    using InterviewSystem.Data.Models;

    public interface IQuestionsService
    {
        IQueryable<Question> GetAll();

        IQueryable<Question> GetRandomQuestions(int count);

        Question GetById(int id);
    }
}
