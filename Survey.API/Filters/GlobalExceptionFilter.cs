using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Survey.API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter 
    {
        private readonly ILogger<GlobalExceptionFilter> _logger; 
        
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            // Hata loglama
            _logger.LogError(context.Exception, "Unhandled exception occurred.");

            // Dönülecek genel hata cevabı
            var response = new
            {
                Message = "Bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.",
                Detail = context.Exception.Message 
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
