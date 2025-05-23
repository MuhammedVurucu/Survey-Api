using Survey.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.Application.Services.Interfaces
{
    public interface ISurveyService
    {
        Task<IEnumerable<SurveyReadDto>> GetAllSurveysAsync();
        Task<SurveyReadDto?> GetSurveyByIdAsync(Guid id);
        Task<SurveyReadDto> CreateSurveyAsync(SurveyCreateDto surveyDto);
        Task DeleteSurveyAsync(Guid id);
        Task CreateSurveyAsync(Domain.Entities.Survey survey);
    }
}
