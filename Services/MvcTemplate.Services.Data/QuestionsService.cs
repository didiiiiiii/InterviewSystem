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

        public IQueryable<Question> GetAll()
        {
            return this.questions.All().OrderBy(x => x.Content);
        }
        public IQueryable<Question> GetRandomQuestions(int count)
        {
            return this.questions.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }

        public bool CreateQuestion(Question question)
        {
            if (question != null)
            {
                this.questions.Add(question);
                this.questions.Save();

                return true;
            }

            return false;
        }

        public bool EditQuestion(Question question)
        {
            if (question != null)
            {
                var q = questions.GetById(question.Id);
                if (q != null)
                {
                    q.Content = question.Content;
                    q.Weight = question.Weight;
                    q.LevelId = question.LevelId;
                    q.TypeId = question.TypeId;
                }

                //this.questions.GetById(question.Id) = q;

                this.questions.Save();

                return true;
            }

            return false;
        }

        public bool RemoveQuestion(int id)
        {
            var question = this.questions.GetById(id);

            if (question != null)
            {
                this.questions.Delete(question);

                this.questions.Save();
                return true;
            }

            return false;
        }      
    }
}
