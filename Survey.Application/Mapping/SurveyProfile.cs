using AutoMapper;
using Survey.Application.DTOs.Create;
using Survey.Application.DTOs.ReadTo;
using Survey.Application.DTOs.Update;
using Survey.Domain.Entities;

namespace Survey.Application.Mapping
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<SurveyCreateDto, Survey.Domain.Entities.Survey>();
            CreateMap<Survey.Domain.Entities.Survey, SurveyReadDto>();
            CreateMap<SurveyUpdateDto, Survey.Domain.Entities.Survey>();
        }
    }
}
