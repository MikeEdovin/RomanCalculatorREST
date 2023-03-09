
using SimpleRomanCalculator;
using RomanCalculatorREST.Controllers;
using RomanCalculatorREST.Entities;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;
using Moq;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.AspNetCore.Mvc;

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
           var result = controller.Calculate(new JsonInput(input));
            
            
           
           //Assert
           Assert.NotNull(controller);
           Assert.IsType<JsonHttpResult<JsonOutput>>(result);
           

        }

        [Fact]
        public void RomanCalculatorControllerShouldReturnBadRequest()
        {
            var mockICalculator = new Mock<ICalculator>();
           
            mockICalculator.Setup(calc => calc.Evaluate("")).Throws<ArgumentException>();


            var controller = new RomanCalculatorController(mockICalculator.Object);
            //Act
            var badRequestResult = controller.Calculate(new JsonInput(""));

            //Assert
            Assert.NotNull(controller);
            Assert.IsType<BadRequest>(badRequestResult);
            
        }
    }
}