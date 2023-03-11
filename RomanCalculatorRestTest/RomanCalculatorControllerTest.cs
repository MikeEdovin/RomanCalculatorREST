
using Moq;
using RomanCalculatorREST.Controllers;
using RomanCalculatorREST.Entities;
using SimpleRomanCalculator;

namespace RomanCalculatorRestTest
{
    public class RomanCalculatorControllerTest
    {
        [Fact]
        public void RomanCalculatorControllerShouldReturnExpectedValue()
        {
            var mockICalculator = new Mock<ICalculator>();
            string input = "XXX-IV";
            string output= "XXVI";    
            mockICalculator.Setup(calc=>calc.Evaluate(input)).Returns(output);
            var controller = new RomanCalculatorController(mockICalculator.Object);

           //Act
            var response = controller.Calculate(new JsonInput(input));
  
            //Assert
            Assert.NotNull(controller);
            Assert.Equal("JsonOutput",response.Value.GetType().Name);
            Assert.True(response.Value.Output!=null);
            Assert.True(response.Value.Output.Equals(output));
        }

        [Fact]
        public void RomanCalculatorControllerShouldReturnBadRequest()
        {
            var mockICalculator = new Mock<ICalculator>();
            mockICalculator.Setup(calc => calc.Evaluate("")).Throws<ArgumentException>();
            var controller = new RomanCalculatorController(mockICalculator.Object);

            //Assert
            Assert.NotNull(controller);
            Assert.Throws<ArgumentException>(() => controller.Calculate(new JsonInput("")));

        }
    }
}