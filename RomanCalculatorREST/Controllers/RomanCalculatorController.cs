using Microsoft.AspNetCore.Mvc;
using SimpleRomanCalculator;

namespace RomanCalculatorREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RomanCalculatorController : ControllerBase
    {
        

        private readonly ILogger<RomanCalculatorController> _logger;

        public RomanCalculatorController(ILogger<RomanCalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Calculate")]
        public string Calculate(HttpContext context)
        {
           ICalculator calculator=context.RequestServices.GetService<ICalculator>();
            calculator.Evaluate(context.Request.Body.);
        }
    }
}