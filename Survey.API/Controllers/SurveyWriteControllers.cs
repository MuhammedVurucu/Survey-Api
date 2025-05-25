using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Interfaces;
using Survey.Application.DTOs.Create;
using Survey.Application.DTOs.Update;
using System;
using System.Threading.Tasks;

namespace Survey.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyWriteController : ControllerBase
    {
        private readonly ISurveyWriterService _surveyWriterService;

        public SurveyWriteController(ISurveyWriterService surveyWriterService)
        {
            _surveyWriterService = surveyWriterService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SurveyCreateDto surveyDto)
        {
            var createdSurvey = await _surveyWriterService.CreateSurveyAsync(surveyDto);
            return CreatedAtAction(nameof(GetById), new { id = createdSurvey.Id }, createdSurvey);
        }

        private object GetById()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SurveyUpdateDto dto)
        {
            await _surveyWriterService.UpdateSurveyAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _surveyWriterService.DeleteSurveyAsync(id);
            return NoContent();
        }

        // Not: CreatedAtAction'da GetById yok burada, dilersen onu Reader controller'dan farklı route ile çağırabilirsin.
    }
}
