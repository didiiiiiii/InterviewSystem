using InterviewSystem.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSystem.Data.Models
{
    public class QuestionLevel : BaseModel<int>
    {
        public QuestionLevel()
        {
            this.Questions = new HashSet<Question>();
        }

        public string QuestionLevelName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
