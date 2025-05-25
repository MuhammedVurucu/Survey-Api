using System;
using System.Collections.Generic;

namespace Survey.Application.DTOs.ReadTo
{
    public class QuestionReadDto
    {
        public Guid Id { get; init; }
        public string Text { get; init; }
        public List<OptionReadDto> Options { get; init; } = new();
    }
}
