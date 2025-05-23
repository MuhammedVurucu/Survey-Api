using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class SurveySettings
    {
        public Guid  Id { get; set; } = Guid.NewGuid();
        public Guid SurveyId { get; set; }

        public bool IsAnonymous { get; set; } = true;  // İsimsiz
        public bool AllowMultipleAnswers { get; set; } = false; // Çoklu seçim
        public bool CanAfterVote { get; set; } = false; // Oy un değiştirilmesi
        public bool AllowGuestAccess { get; set; } = true;
        public bool AllowResultDownland { get; set; } = false;


        public DateTime? FinishDate { get; set; }
        public int? MaximumPerson {  get; set; }
        public string? PasswordProdection { get; set; } // Tanımsız ise şifre olmayacak 
        public string? CustomRedirectUrl { get; set; }
        public string? Theme { get; set; } = "Default";

        public Survey? Survey { get; set; }
    }
}
