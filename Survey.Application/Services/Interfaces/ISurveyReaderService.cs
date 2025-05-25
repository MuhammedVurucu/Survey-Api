using Survey.Application.DTOs.ReadTo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.Application.Services.Interfaces
{
    public interface ISurveyReaderService
    {
        Task<IEnumerable<SurveyReadDto>> GetAllSurveysAsync();
        Task<SurveyReadDto?> GetSurveyByIdAsync(Guid id);
    }
}
