namespace RomanCalculatorREST.Services
{
    using SimpleRomanCalculator;

    public class CalculatorService:ICalculatorService
    {
        private readonly ICalculator calculator;
        public CalculatorService(ICalculator calc) {
            this.calculator = calc;
        }

        string ICalculatorService.Calculate(string input)
        {
            try
            {
                return calculator.Evaluate(input);
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }
    }
}
