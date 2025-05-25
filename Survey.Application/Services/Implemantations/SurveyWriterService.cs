using AutoMapper;
using Survey.Application.DTOs.Create;
using Survey.Application.DTOs.ReadTo;
using Survey.Application.DTOs.Update;
using Survey.Application.Exceptions;
using Survey.Application.Repository;
using Survey.Application.Services.Interfaces;
using Survey.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Survey.Application.Services.Implemantations
{
    public class SurveyWriterService : ISurveyWriterService
    {
        private readonly IRepository<Survey.Domain.Entities.Survey> _surveyRepository;
        private readonly IMapper _mapper;

        public SurveyWriterService(IRepository<Survey.Domain.Entities.Survey> surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<SurveyReadDto> CreateSurveyAsync(SurveyCreateDto surveyDto)
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

            return _mapper.Map<SurveyReadDto>(surveyEntity);
        }

        public async Task UpdateSurveyAsync(Guid id, SurveyUpdateDto updateDto)
        {
            var survey = await _surveyRepository.GetByIdAsync(id);
            if (survey == null)
                throw new NotFoundException($"Survey with id '{id}' not found.");

            survey.Title = updateDto.Title;
            survey.Description = updateDto.Description;

            _surveyRepository.Update(survey);
            await _surveyRepository.SaveChangesAsync();
        }

        public async Task DeleteSurveyAsync(Guid id)
        {
            var survey = await _surveyRepository.GetByIdAsync(id);
            if (survey == null)
                throw new NotFoundException($"Survey with id '{id}' not found.");

            _surveyRepository.Delete(survey);
            await _surveyRepository.SaveChangesAsync();
        }
    }
}

