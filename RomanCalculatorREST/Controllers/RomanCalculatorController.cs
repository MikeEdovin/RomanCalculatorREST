using Microsoft.AspNetCore.Mvc;
using RomanCalculatorREST.Entities;
using SimpleRomanCalculator;

namespace RomanCalculatorREST.Controllers
{
    [ApiController]
    [Route("calculate")]
    public class RomanCalculatorController : ControllerBase
    {
      
        [HttpPost]
        public async Task<IResult> Calculate(ICalculator calculator,JsonInput jsonInput)
        {
                try
                {
                    string? expression = jsonInput.Input;
                    var result = calculator.Evaluate(expression);
                    return Results.Json(new JsonOutput(result));
                }
                catch(ArgumentException e)
                {
                    return Results.BadRequest(e.Message);
                }
        }
        
    }
}