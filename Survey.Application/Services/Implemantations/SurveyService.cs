using AutoMapper;
using Survey.Application.DTOs;
using Survey.Application.Exceptions;
using Survey.Application.Repository;
using Survey.Application.Services.Interfaces;
using Survey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Application.Services.Implemantations
{
    public class SurveyService : ISurveyService
    {
        private readonly IRepository<Domain.Entities.Survey> _surveyRepository;
        private readonly IRepository<Answer> _answerRepository;  // Burada doğru tipi kullan
        private readonly IMapper _mapper;

        public SurveyService(
            IRepository<Domain.Entities.Survey> surveyRepository,
            IRepository<Answer> answerRepository,  // constructor'da da al
            IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _answerRepository = answerRepository;
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
            if (survey == null)
                return null;

            return _mapper.Map<SurveyReadDto>(survey);
        }

        public async Task<SurveyReadDto> CreateSurveyAsync(SurveyCreateDto surveyDto)
        {
            var surveyEntity = _mapper.Map<Domain.Entities.Survey>(surveyDto);

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

        public async Task<PagedResult<SurveyReadDto>> GetPagedSurveysAsync(int pageNumber, int pageSize)
        {
            var surveys = await _surveyRepository
                .GetPagedOrderedAsync(pageNumber, pageSize, s => s.CreatedAt, descending: true);

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

        public async Task VoteAsync(VoteCreateDto voteDto)
        {
            var survey = await _surveyRepository.GetByIdAsync(voteDto.SurveyId)
                ?? throw new NotFoundException("Survey not found.");

            var question = survey.Questions.FirstOrDefault(q => q.Id == voteDto.QuestionId)
                ?? throw new NotFoundException("Question not found in this survey.");

            var option = question.Options.FirstOrDefault(o => o.Id == voteDto.OptionId)
                ?? throw new NotFoundException("Option not found in this question.");

            var answer = new Answer
            {
                SurveyId = voteDto.SurveyId,
                QuestionID = voteDto.QuestionId,
                OptionID = voteDto.OptionId
            };

            await _answerRepository.AddAsync(answer);
            await _answerRepository.SaveChangesAsync();  
        }
    }
}







