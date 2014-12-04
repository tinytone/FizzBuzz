using Microsoft.VisualStudio.TestTools.UnitTesting;
using Company.Fizzbuzz.Domain.DescriptionBuilders;

namespace Company.Fizzbuzz.Domain.Tests.DescriptionBuilders
{
    [TestClass]
    public class FizzBuzzDescriptionBuilderTest
    {
        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void Constructor_FizzBuzzDescriptionBuilder_ExpectInstance()
        {
            // Arrange

            // Act
            var builder = new FizzBuzzDescriptionBuilder();

            // Assert
            Assert.IsNotNull(builder);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void GetDescription_ValueIsZero_ExpectFizzBuzz()
        {
            // Arrange
            const int Value = 0;
            const string ExpectedDescription = "FizzBuzz";

            var builder = GetFizzBuzzDescriptionBuilder();

            // Act
            var result = builder.GetDescription(Value);

            // Assert
            Assert.AreEqual(ExpectedDescription, result);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void GetDescription_ValueIsOne_ExpectOne()
        {
            // Arrange
            const int Value = 1;

            var expectedDescription = Value.ToString();

            var builder = GetFizzBuzzDescriptionBuilder();

            // Act
            var result = builder.GetDescription(Value);

            // Assert
            Assert.AreEqual(expectedDescription, result);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void GetDescription_ValueIsTwo_ExpectTwo()
        {
            // Arrange
            const int Value = 2;

            var expectedDescription = Value.ToString();

            var builder = GetFizzBuzzDescriptionBuilder();

            // Act
            var result = builder.GetDescription(Value);

            // Assert
            Assert.AreEqual(expectedDescription, result);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void GetDescription_ValueIsThree_ExpectFizz()
        {
            // Arrange
            const int Value = 3;

            var expectedDescription = "Fizz";

            var builder = GetFizzBuzzDescriptionBuilder();

            // Act
            var result = builder.GetDescription(Value);

            // Assert
            Assert.AreEqual(expectedDescription, result);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void GetDescription_ValueIsFour_ExpectFour()
        {
            // Arrange
            const int Value = 4;

            var expectedDescription = Value.ToString();

            var builder = GetFizzBuzzDescriptionBuilder();

            // Act
            var result = builder.GetDescription(Value);

            // Assert
            Assert.AreEqual(expectedDescription, result);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void GetDescription_ValueIsFive_ExpectBuzz()
        {
            // Arrange
            const int Value = 5;

            var expectedDescription = "Buzz";

            var builder = GetFizzBuzzDescriptionBuilder();

            // Act
            var result = builder.GetDescription(Value);

            // Assert
            Assert.AreEqual(expectedDescription, result);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void GetDescription_ValueIsFifteen_ExpectFizzBuzz()
        {
            // Arrange
            const int Value = 15;

            var expectedDescription = "FizzBuzz";

            var builder = GetFizzBuzzDescriptionBuilder();

            // Act
            var result = builder.GetDescription(Value);

            // Assert
            Assert.AreEqual(expectedDescription, result);
        }

        //// ----------------------------------------------------------------------------------------------------------

        private IDescriptionBuilder GetFizzBuzzDescriptionBuilder()
        {
            return new FizzBuzzDescriptionBuilder();
        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}
