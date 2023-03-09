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
        [HttpPost(Name = "calculate")]
        public IResult Calculate(JsonInput jsonInput)
        {
            try
            {
                string? expression = jsonInput.Input;
                var result = calculator.Evaluate(expression);
               // return new JsonOutput(result);
                return Results.Json(new JsonOutput(result));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e);
            }
        }
        
    }
}