using System.Text.Json.Serialization;

namespace RomanCalculatorREST.Entities
{
    public class JsonInput
    {
        public string? Input { get; set; }

        public JsonInput() { }
        public JsonInput(string input)
        {
            Input = input;
        }
    }
}
