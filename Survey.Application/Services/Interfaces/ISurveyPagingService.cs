using Survey.Application.DTOs;
using Survey.Application.DTOs.ReadTo;
using System.Threading.Tasks;

namespace Survey.Application.Services.Interfaces
{
    public interface ISurveyPaginationService
    {
        Task<PagedResult<SurveyReadDto>> GetPagedSurveysAsync(int pageNumber, int pageSize);
    }
}

