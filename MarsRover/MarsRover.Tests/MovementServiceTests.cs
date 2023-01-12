using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarsRover.Tests
{
    public class MovementServiceTests
    {
        [Theory]
        [InlineData(new string[] { "4 8", "(2, 3, E) LFRFF", "(0, 2, N) FFLFRFF" }, new string[] { "(4, 4, E)", "(0, 4, W) LOST" })]
        [InlineData(new string[] { "4 8", "(2, 3, N) FLLFR", "(1, 0, S) FFRLF" }, new string[] { "(2, 3, W)", "(1, 0, S) LOST" })]

        public void Run_ReturnsValidResponse(string[] input, string[] expectedOutput)
        {
            //Arrange
            var sut = new MovementService();

            //Act
            var output = sut.Run(input.ToList());

            //Assert
            foreach (var outputItem in output.Select((value, i) => (value, i)))
            {
                Assert.Equal(expectedOutput[outputItem.i].Trim(), outputItem.value.Trim());
            }
        }
    }
}
