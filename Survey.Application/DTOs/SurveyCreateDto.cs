using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Survey.Application.DTOs
{
    public class SurveyCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = null!;

        [Required]
        [MinLength(1, ErrorMessage = "At least one question is required")]
        public List<QuestionCreateDto> Questions { get; set; } = new();
    }

    public class QuestionCreateDto
    {
        [Required(ErrorMessage = "Question text is required")]
        [MaxLength(250, ErrorMessage = "Question text cannot exceed 250 characters")]
        public string Text { get; set; } = null!;

        [Required]
        [MinLength(1, ErrorMessage = "At least one option is required")]
        public List<OptionCreateDto> Options { get; set; } = new();
    }

    public class OptionCreateDto
    {
        [Required(ErrorMessage = "Option text is required")]
        [MaxLength(150, ErrorMessage = "Option text cannot exceed 150 characters")]
        public string Text { get; set; } = null!;
    }
}
