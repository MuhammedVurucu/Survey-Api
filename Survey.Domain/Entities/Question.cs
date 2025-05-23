using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Domain.Entities;


namespace Survey.Domain.Entities
{
    public class Question 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SurveyId { get; set; }  // Ankete Ait lik
        public string Text { get; set; } = string .Empty; // Soru metni 
        public int Arrangement { get; set; } // Sıralama 

        public Survey? Survey { get; set; }
        public ICollection<Option>? Options { get; set; }
    }
}
