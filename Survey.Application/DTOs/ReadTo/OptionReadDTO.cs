using System;

namespace Survey.Application.DTOs.ReadTo
{
    public class OptionReadDto
    {
        public Guid Id { get; init; }
        public required string Text { get; init; }
    }
}

