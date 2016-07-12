namespace InterviewSystem.Services.Data
{
    using System.Linq;

    using InterviewSystem.Data.Common;
    using InterviewSystem.Data.Models;

    public class QuestionTypesService : IQuestionTypesService
    {
        private readonly IDbRepository<QuestionType> questionTypes;

        public QuestionTypesService(IDbRepository<QuestionType> questionTypes)
        {
            this.questionTypes = questionTypes;
        }

        public QuestionType EnsureType(string name)
        {
            var type = this.questionTypes.All().FirstOrDefault(x => x.QuestionTypeName == name);
            if (type != null)
            {
                return type;
            }

            type = new QuestionType { QuestionTypeName = name };
            this.questionTypes.Add(type);
            this.questionTypes.Save();
            return type;
        }

        public IQueryable<QuestionType> GetAll()
        {
            return this.questionTypes.All().OrderBy(x => x.QuestionTypeName);
        }
    }
}
