using System;

namespace Survey.Domain.Entities
{
    public class Option
    {
        // Option kimliği
        public Guid Id { get; set; } = Guid.NewGuid();
        // Hangi Question'a ait olduğunu belirtir
        public Guid QuestionId { get; set; }
        // Seçeneğin metni
        public string Text { get; set; } = string.Empty;
        // Navigation property, Option'ın bağlı olduğu Question nesnesi
        public Question? Question { get; set; }
        // Bu seçeneğe verilen cevap sayısı (istediğin iş mantığı için)
        public int NumberOfAnswers { get; set; } = 0;
    }
}
