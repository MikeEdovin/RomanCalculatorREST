using Microsoft.AspNetCore.Mvc;
using RomanCalculatorREST.Entities;
using SimpleRomanCalculator;

namespace RomanCalculatorREST.Controllers
{
    [ApiController]
    [Route("calculate")]
    public class RomanCalculatorController : ControllerBase
    {
      private readonly ICalculator calculator;
      public RomanCalculatorController(ICalculator calc) {
            this.calculator = calc;
        }
        [HttpPost]
        public ActionResult<JsonOutput> Calculate(JsonInput jsonInput)
        {
                string? expression = jsonInput.Input;
                var result = calculator.Evaluate(expression);
                return new JsonOutput(result);  
        }
    }
}