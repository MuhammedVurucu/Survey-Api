using AutoMapper;
using Survey.Application.DTOs;
using Survey.Application.DTOs.ReadTo;
using Survey.Application.Repository;
using Survey.Application.Services.Interfaces;
using Survey.Domain.Entities;
using System.Threading.Tasks;

namespace Survey.Application.Services.Implemantations
{
    public class SurveyPaginationService : ISurveyPaginationService
    {
        private readonly IRepository<Survey.Domain.Entities.Survey> _surveyRepository;
        private readonly IMapper _mapper;

        public SurveyPaginationService(IRepository<Survey.Domain.Entities.Survey> surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SurveyReadDto>> GetPagedSurveysAsync(int pageNumber, int pageSize)
        {
            var surveys = await _surveyRepository.GetPagedOrderedAsync(pageNumber, pageSize, s => s.CreatedAt, descending: true);
            var totalCount = await _surveyRepository.CountAsync();
            var surveyDtos = _mapper.Map<IEnumerable<SurveyReadDto>>(surveys);

            return new PagedResult<SurveyReadDto>
            {
                Items = surveyDtos,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
