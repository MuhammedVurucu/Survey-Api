using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Survey.Application.DTOs.Create
{
    public class QuestionCreateDto
    {
        [Required(ErrorMessage = "Question text is required")]
        [MaxLength(250, ErrorMessage = "Question text cannot exceed 250 characters")]
        public string Text { get; init; } = null!;

      
    }
}

