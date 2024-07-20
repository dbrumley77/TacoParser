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
        
        public void ShouldParseLongitude(string line, double expected)
        {
            

            
            TacoParser parserInstance = new TacoParser();

            
            ITrackable actual = parserInstance.Parse(line);

            
            Assert.Equal(expected, actual.Location.Longitude);
        }


        
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.039588, -84.283254, Taco Bell Alpharetta...", 34.039588)]
        [InlineData("30.906033, -87.79328, Taco Bell Bay Minett...", 30.906033)]
        
        public void ShouldParseLatitude(string line, double expected)
        {
            

            
            TacoParser parserInstance = new TacoParser();

            
            ITrackable actual = parserInstance.Parse(line);

            
            Assert.Equal(expected, actual.Location.Latitude);

        }    
    }
}
