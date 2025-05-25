using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Survey.Application.DTOs.Create
{
    public class SurveyCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; init; } = null!;

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; init; } = null!;

        [Required]
        [MinLength(1, ErrorMessage = "At least one question is required")]
        public List<QuestionCreateDto> Questions { get; init; } = new();
    }
}

