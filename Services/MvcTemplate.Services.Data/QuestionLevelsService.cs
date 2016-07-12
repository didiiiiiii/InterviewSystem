namespace InterviewSystem.Services.Data
{
    using System.Linq;

    using InterviewSystem.Data.Common;
    using InterviewSystem.Data.Models;

    public class QuestionLevelsService : IQuestionLevelsService
    {
        private readonly IDbRepository<QuestionLevel> questionLevels;

        public QuestionLevelsService(IDbRepository<QuestionLevel> questionLevels)
        {
            this.questionLevels = questionLevels;
        }

        public QuestionLevel EnsureLevel(string name)
        {
            var level = this.questionLevels.All().FirstOrDefault(x => x.QuestionLevelName == name);
            if (level != null)
            {
                return level ;
            }

            level = new QuestionLevel { QuestionLevelName = name };
            this.questionLevels.Add(level);
            this.questionLevels.Save();
            return level;
        }

        public IQueryable<QuestionLevel> GetAll()
        {
            return this.questionLevels.All().OrderBy(x => x.QuestionLevelName);
        }
    }
}
