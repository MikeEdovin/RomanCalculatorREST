namespace RomanCalculatorREST.Entities
{
    public class Response
    {
        public string Output { get; set; }
        public Response(string output)
        {
            Output = output;
        }
    }
}
