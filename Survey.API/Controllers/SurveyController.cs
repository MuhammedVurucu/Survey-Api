using Microsoft.AspNetCore.Mvc;
using Survey.Application.DTOs;
using Survey.Application.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Survey.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var surveys = await _surveyService.GetAllSurveysAsync();
            return surveys == null || !surveys.Any()
                ? NoContent()
                : Ok(surveys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(id); // Eğer null ise servis katmanı fırlatmalı
            return Ok(survey);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SurveyCreateDto surveyDto)
        {
            var createdSurvey = await _surveyService.CreateSurveyAsync(surveyDto);
            return CreatedAtAction(nameof(GetById), new { id = createdSurvey.Id }, createdSurvey);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _surveyService.DeleteSurveyAsync(id); // NotFoundException burada servis katmanında atılır
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(Guid id, [FromBody] SurveyUpdateDto dto)
        {
            await _surveyService.UpdateSurveyAsync(id, dto); // NotFoundException burada servis katmanında atılır
            return NoContent();
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _surveyService.GetPagedSurveysAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost("vote")]
        public async Task<IActionResult> Vote([FromBody] VoteCreateDto voteDto)
        {
            await _surveyService.VoteAsync(voteDto);
            return Ok(new { message = "Vote recorded successfully." });
        }
    }
}

