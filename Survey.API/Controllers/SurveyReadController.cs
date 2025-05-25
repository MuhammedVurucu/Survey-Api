using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Survey.API.Controllers.Readers
{
    [ApiController]
    [Route("api/[controller]")]  // Route: api/SurveyRead
    public class SurveyReadController : ControllerBase
    {
        private readonly ISurveyReaderService _surveyReaderService;

        // Constructor Dependency Injection ile servisi alıyoruz.
        public SurveyReadController(ISurveyReaderService surveyReaderService)
        {
            _surveyReaderService = surveyReaderService ?? throw new ArgumentNullException(nameof(surveyReaderService));
        }

        // GET api/SurveyRead
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var surveys = await _surveyReaderService.GetAllSurveysAsync();

            // Eğer anket yoksa NoContent dön.
            if (surveys == null || !surveys.Any())
                return NoContent();

            // Varsa 200 OK ve anket listesini döndür.
            return Ok(surveys);
        }

        // GET api/SurveyRead/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var survey = await _surveyReaderService.GetSurveyByIdAsync(id);

            // Anket bulunamazsa 404 döndür.
            if (survey == null)
                return NotFound();

            // Bulunursa 200 OK ve anket detayını döndür.
            return Ok(survey);
        }
    }
}



