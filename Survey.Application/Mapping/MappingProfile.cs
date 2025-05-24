using AutoMapper;
using Survey.Application.DTOs;
using Survey.Domain.Entities;

namespace Survey.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Survey
            CreateMap<SurveyCreateDto, Survey.Domain.Entities.Survey>();
            CreateMap<Survey.Domain.Entities.Survey, SurveyReadDto>();

            // Question
            CreateMap<QuestionCreateDto, Question>();
            CreateMap<Question, QuestionReadDto>();

            // Option
            CreateMap<OptionCreateDto, Option>();
            CreateMap<Option, OptionReadDto>();

            // Survey Update
            CreateMap<SurveyUpdateDto, Survey.Domain.Entities.Survey>();
        }
    }
}

