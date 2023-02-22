namespace RomanCalculatorREST.Entities
{
    public class JsonOutput
    {
        public string? Output { get; set; }
        public JsonOutput() { }
        public JsonOutput(string output)
        {
            Output = output;
        }
    }
}
