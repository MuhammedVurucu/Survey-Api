using System;
using System.Collections.Generic;
using System.Text.Json.Serialization; // JsonIgnore için

namespace Survey.Domain.Entities
{
    public class Survey
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Anket ID
        public string Title { get; set; } = string.Empty; // Anket Başlığı 
        public string? Description { get; set; } // Anket Açıklaması
        public bool IsActive { get; set; } = true; // Anket Aktif mi ?
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Oluşturulma Tarihi 

        // Navigation property - API'de dönerken sorun çıkarmaması için JsonIgnore koyduk
        [JsonIgnore]
        public SurveySettings? SurveySettings { get; set; }

        [JsonIgnore]
        public ICollection<Question>? Questions { get; set; }
    }
}

