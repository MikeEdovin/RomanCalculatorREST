using Moq;
using RomanCalculatorREST.Entities;
using SimpleRomanCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalculatorRestTest
{
    public class ProgrammTest
    {
        [Fact]
        public void PostMapShouldReturnExpectedValue()
        {
            var mocICalculator = new Mock<ICalculator>();
            JsonInput input = new JsonInput("XXX-IV");
            
        }
    }
}
