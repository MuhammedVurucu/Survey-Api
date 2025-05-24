using System;
using System.Collections.Generic;

namespace Survey.Application.DTOs
{
    public class SurveyReadDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreatedAt { get; init; }
        public List<QuestionReadDto> Questions { get; init; } = new();
    }

    public class QuestionReadDto
    {
        public Guid Id { get; init; }
        public string Text { get; init; }
        public List<OptionReadDto> Options { get; init; } = new();
    }

    public class OptionReadDto
    {
        public Guid Id { get; init; }
        public string Text { get; init; }
    }
}


