using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSystem.Data.Models
{
    public class InterviewSystemEntites : DbContext
    {

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<QuestionLevel> QuestionLevels { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
