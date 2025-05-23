using Survey.Application.DTOs;
using Survey.Application.Repository;
using Survey.Application.Services.Interfaces;
using Survey.Domain.Entities;
using AutoMapper;

namespace Survey.Application.Services.Implemantations
{
    public class SurveyService : ISurveyService
    {
        private readonly IRepository<Survey.Domain.Entities.Survey> _surveyRepository;
        private readonly IMapper _mapper;

        public SurveyService(IRepository<Survey.Domain.Entities.Survey> surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SurveyReadDto>> GetAllSurveysAsync()
        {
            var surveys = await _surveyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SurveyReadDto>>(surveys);
        }

        public async Task<SurveyReadDto?> GetSurveyByIdAsync(Guid id)
        {
            var survey = await _surveyRepository.GetByIdAsync(id);
            if (survey == null) return null;

            return _mapper.Map<SurveyReadDto>(survey);
        }

        public async Task CreateSurveyAsync(SurveyCreateDto surveyDto)
        {
            var survey = _mapper.Map<Survey.Domain.Entities.Survey>(surveyDto);

            // Otomatik atanacak alanlar
            survey.Id = Guid.NewGuid();
            survey.CreatedAt = DateTime.UtcNow;
            survey.IsActive = true;

            await _surveyRepository.AddAsync(survey);
            await _surveyRepository.SaveChangesAsync();
        }

        public async Task DeleteSurveyAsync(Guid id)
        {
            var survey = await _surveyRepository.GetByIdAsync(id);
            if (survey != null)
            {
                _surveyRepository.Delete(survey);
                await _surveyRepository.SaveChangesAsync();
            }
        }

        public Task CreateSurveyAsync(Domain.Entities.Survey survey)
        {
            throw new NotImplementedException();
        }

        async Task<SurveyReadDto> ISurveyService.CreateSurveyAsync(SurveyCreateDto surveyDto)
        {
            var surveyEntity = _mapper.Map<Survey.Domain.Entities.Survey>(surveyDto);

            surveyEntity.Id = Guid.NewGuid();
            surveyEntity.CreatedAt = DateTime.UtcNow;
            surveyEntity.IsActive = true;

            foreach (var question in surveyEntity.Questions)
            {
                question.Id = Guid.NewGuid();
                question.SurveyId = surveyEntity.Id;

                foreach (var option in question.Options)
                {
                    option.Id = Guid.NewGuid();
                    option.QuestionId = question.Id;
                }
            }

            await _surveyRepository.AddAsync(surveyEntity);
            await _surveyRepository.SaveChangesAsync();

            var resultDto = _mapper.Map<SurveyReadDto>(surveyEntity);
            return resultDto;
        }
    }
}

