using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Interfaces;
using System.Threading.Tasks;

namespace Survey.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyPaginationController : ControllerBase
    {
        private readonly ISurveyPaginationService _surveyPaginationService;

        public SurveyPaginationController(ISurveyPaginationService surveyPaginationService)
        {
            _surveyPaginationService = surveyPaginationService;
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _surveyPaginationService.GetPagedSurveysAsync(pageNumber, pageSize);
            return Ok(result);
        }
    }
}

