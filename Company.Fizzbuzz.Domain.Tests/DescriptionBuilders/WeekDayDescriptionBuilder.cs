using Microsoft.VisualStudio.TestTools.UnitTesting;
using Company.Fizzbuzz.Domain.DescriptionBuilders;

namespace Company.WizzWuzz.Domain.Tests.DescriptionBuilders
{
    [TestClass]
    public class WeekDayDescriptionBuilderTest
    {
        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void Constructor_WeekDayDescriptionBuilder_ExpectInstance()
        {
            // Arrange

            // Act
            var builder = new WeekDayDescriptionBuilder();

            // Assert
            Assert.IsNotNull(builder);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void GetDescription_ValueIsZero_ExpectWizzWuzz()
        {
            // Arrange
            const int Value = 0;
            const string ExpectedDescription = "WizzWuzz";

            var builder = GetWeekDayDescriptionBuilder();

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

            var builder = GetWeekDayDescriptionBuilder();

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

            var builder = GetWeekDayDescriptionBuilder();

            // Act
            var result = builder.GetDescription(Value);

            // Assert
            Assert.AreEqual(expectedDescription, result);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void GetDescription_ValueIsThree_ExpectWizz()
        {
            // Arrange
            const int Value = 3;

            var expectedDescription = "Wizz";

            var builder = GetWeekDayDescriptionBuilder();

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

            var builder = GetWeekDayDescriptionBuilder();

            // Act
            var result = builder.GetDescription(Value);

            // Assert
            Assert.AreEqual(expectedDescription, result);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void GetDescription_ValueIsFive_ExpectWuzz()
        {
            // Arrange
            const int Value = 5;

            var expectedDescription = "Wuzz";

            var builder = GetWeekDayDescriptionBuilder();

            // Act
            var result = builder.GetDescription(Value);

            // Assert
            Assert.AreEqual(expectedDescription, result);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void GetDescription_ValueIsFifteen_ExpectWizzWuzz()
        {
            // Arrange
            const int Value = 15;

            var expectedDescription = "WizzWuzz";

            var builder = GetWeekDayDescriptionBuilder();

            // Act
            var result = builder.GetDescription(Value);

            // Assert
            Assert.AreEqual(expectedDescription, result);
        }

        //// ----------------------------------------------------------------------------------------------------------

        private IDescriptionBuilder GetWeekDayDescriptionBuilder()
        {
            return new WeekDayDescriptionBuilder();
        }

        //// ----------------------------------------------------------------------------------------------------------   
    }
}
