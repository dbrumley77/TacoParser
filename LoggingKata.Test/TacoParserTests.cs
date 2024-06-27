using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.039588, -84.283254, Taco Bell Alpharetta...", -84.283254)]
        [InlineData("30.906033, -87.79328, Taco Bell Bay Minett...", -87.79328)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            TacoParser parserInstance = new TacoParser();

            //Act
            ITrackable actual = parserInstance.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.039588, -84.283254, Taco Bell Alpharetta...", 34.039588)]
        [InlineData("30.906033, -87.79328, Taco Bell Bay Minett...", 30.906033)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLatitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            TacoParser parserInstance = new TacoParser();

            //Act
            ITrackable actual = parserInstance.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Latitude);

        }    
    }
}
