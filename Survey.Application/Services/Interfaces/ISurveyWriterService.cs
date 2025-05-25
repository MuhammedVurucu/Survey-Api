using Survey.Application.DTOs.Create;
using Survey.Application.DTOs.ReadTo;
using Survey.Application.DTOs.Update;
using System;
using System.Threading.Tasks;

namespace Survey.Application.Services.Interfaces
{
    public interface ISurveyWriterService
    {
        Task<SurveyReadDto> CreateSurveyAsync(SurveyCreateDto surveyDto);
        Task UpdateSurveyAsync(Guid id, SurveyUpdateDto updateDto);
        Task DeleteSurveyAsync(Guid id);
    }
}

