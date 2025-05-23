using Microsoft.AspNetCore.Mvc;
using Survey.Application.DTOs;
using Survey.Application.Services.Interfaces;

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
            return Ok(surveys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(id);
            if (survey == null) return NotFound();
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
            await _surveyService.DeleteSurveyAsync(id);
            return NoContent();
        }
    }
}



