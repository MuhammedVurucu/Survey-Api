using System;
using System.ComponentModel.DataAnnotations;

namespace Survey.Application.DTOs
{
    public class VoteCreateDto
    {
        [Required]
        public Guid SurveyId { get; set; }

        [Required]
        public Guid QuestionId { get; set; }

        [Required]
        public Guid OptionId { get; set; }
    }
}

