using AutoMapper;
using Survey.Application.DTOs.ReadTo;
using Survey.Application.Repository;
using Survey.Application.Services.Interfaces;
using Survey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.Application.Services.Implemantations
{
    public class SurveyReaderService : ISurveyReaderService
    {
        private readonly IRepository<Survey.Domain.Entities.Survey> _surveyRepository;
        private readonly IMapper _mapper;

        public SurveyReaderService(IRepository<Survey.Domain.Entities.Survey> surveyRepository, IMapper mapper)
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
            if (survey == null)
                return null;

            return _mapper.Map<SurveyReadDto>(survey);
        }
    }
}

