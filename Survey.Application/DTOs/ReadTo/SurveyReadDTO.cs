using System;
using System.Collections.Generic;

namespace Survey.Application.DTOs.ReadTo
{
    public class SurveyReadDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreatedAt { get; init; }
        public List<QuestionReadDto> Questions { get; init; } = new();
    }
}
