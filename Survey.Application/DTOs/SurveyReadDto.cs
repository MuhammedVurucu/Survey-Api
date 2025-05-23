using System;
using System.Collections.Generic;

namespace Survey.Application.DTOs
{
    public class SurveyReadDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public List<QuestionReadDto> Questions { get; set; } = new();
    }

    public class QuestionReadDto
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public List<OptionReadDto> Options { get; set; } = new();
    }

    public class OptionReadDto
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;
    }
}


