using GamblerX.API.Controllers;
using GamblerX.Contracts.Bet;
using Microsoft.AspNetCore.Mvc;


namespace GamblerX.Tests.Controllers;

public class GambleControllerTests
{

        private GambleController _gambleController;

        public GambleControllerTests()
        {
            _gambleController = new GambleController();
        }
  
        [Fact]
        public void PlaceBet_ValidBet_ReturnsOkWithBetResult()
        {
            // Arrange
            var betRequest = new BetRequest { Points = 100, Number = 5 };

            // Act
            var result = _gambleController.PlaceBet(betRequest);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var valueProperty = result.GetType().GetProperty("Value"); // use reflection to access the Value property of result

            if (valueProperty != null)
            {
                var value = valueProperty.GetValue(result);

                if (value != null)
                {
                    // retrive  the properties of the value                    
                    var account = value.GetType().GetProperty("Account")?.GetValue(value);
                    var status = value.GetType().GetProperty("Status")?.GetValue(value);
                    var answer = value.GetType().GetProperty("Answer")?.GetValue(value);
                    var points = value.GetType().GetProperty("Points")?.GetValue(value);


                    //Assert  (well this is just for show, normally I cannot assert on a gambling event that has not happened)
                    // Assert.Equal(10900, account);
                    // Assert.Equal("won", status);
                    // Assert.Equal(5, answer);
                    // Assert.Equal(100, points);
                }
            }
        }

        [Fact]
        public void PlaceBet_InvalidBet_ReturnsBadRequest()
        {
            // Arrange
            var betRequest = new BetRequest { Points = 0, Number = 10 }; // Invalid bet

            // Act
            var result = _gambleController.PlaceBet(betRequest);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);


            var badRequestResult = result as BadRequestObjectResult;
            if (badRequestResult != null)
            {
                var responseValue = badRequestResult.Value;
                Assert.Equal("Invalid bet.", responseValue);
            }
        }

}