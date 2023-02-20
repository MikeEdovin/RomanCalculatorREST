namespace RomanCalculatorREST.Middlewares
{
    using RomanCalculatorREST.Entities;
    using Services;
    public class RomanCalculatorMiddleware
    {
        RequestDelegate next;
        ICalculatorService calculatorService;

        public RomanCalculatorMiddleware(RequestDelegate next, ICalculatorService calculatorService)
        {
            this.next = next;
            this.calculatorService = calculatorService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path = "/Calculate")
            {
                //Input input = context.Request.Body.;
                context.Response.ContentType = "application/json";
                Response output=new Output(calculatorService.Calculate(context.Request)
            }
        }
    }
}
