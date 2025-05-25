using AutoMapper;
using Survey.Application.DTOs.Create;
using Survey.Application.DTOs.ReadTo;
using Survey.Domain.Entities;

namespace Survey.Application.Mapping
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionCreateDto, Question>();
            CreateMap<Question, QuestionReadDto>();
        }
    }
}
