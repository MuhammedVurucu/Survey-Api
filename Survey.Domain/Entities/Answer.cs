using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class Answer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid  SurveyId { get; set; }
        public Guid QuestionID { get; set; }
        public Guid OptionID { get; set; }
        public DateTime AnsweredAt { get; set; }

        public Survey? Survey { get; set; }
        public Question? Question { get; set; }
        public Option? Option { get; set; }
    }
}
