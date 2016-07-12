using InterviewSystem.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSystem.Data.Models
{
    public class Question : BaseModel<int>
    {
        public string Content { get; set; }

        public double Weight
        {
            get; set;
        }

        public int TypeId { get; set; }

        public virtual QuestionType Type { get; set; }

        public int LevelId { get; set; }

        public virtual QuestionLevel Level { get; set; }
    }
}
