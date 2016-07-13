namespace InterviewSystem.Services.Data
{
    using System;
    using System.Linq;

    using InterviewSystem.Data.Common;
    using InterviewSystem.Data.Models;
    using InterviewSystem.Services.Web;

    public class QuestionsService : IQuestionsService
    {
        private readonly IDbRepository<Question> questions;
        private readonly IIdentifierProvider identifierProvider;

        public QuestionsService(IDbRepository<Question> questions, IIdentifierProvider identifierProvider)
        {
            this.questions = questions;
            this.identifierProvider = identifierProvider;
        }

        public Question GetById(int id)
        {
            //var intId = this.identifierProvider.DecodeId(id);
            var question = this.questions.GetById(id);
            return question;
        }

        public IQueryable<Question> GetRandomQuestions(int count)
        {
            return this.questions.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }
    }
}
