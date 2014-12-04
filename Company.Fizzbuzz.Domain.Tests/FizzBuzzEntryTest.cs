using System;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Company.Fizzbuzz.Domain.DescriptionBuilders;

namespace Company.Fizzbuzz.Domain.Tests
{
    [TestClass]
    public class FizzBuzzEntryTest
    {
        //// ----------------------------------------------------------------------------------------------------------

        private MockRepository mocks;

        //// ----------------------------------------------------------------------------------------------------------

        [TestInitialize]
        public void TestInitialize()
        {
            mocks = new MockRepository();
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestCleanup]
        public void TestCleanup()
        {
            mocks.VerifyAll();
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_ValueIsNegative_ExpectArgumentOutOfRangeException()
        {
            // Arrange
            const int Value = -1;

            var builder = this.mocks.StrictMock<IDescriptionBuilder>();

            this.mocks.ReplayAll();

            // Act
            var fizzBuzzEntry = new FizzBuzzEntry(Value, builder);

            // Assert
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_ValueIsZero_ExpectArgumentOutOfRangeException()
        {
            // Arrange
            const int Value = 0;

            var builder = this.mocks.StrictMock<IDescriptionBuilder>();

            this.mocks.ReplayAll();

            // Act
            var fizzBuzzEntry = new FizzBuzzEntry(Value, builder);

            // Assert
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_DescriptionBuilderIsNull_ExpectArgumentNullException()
        {
            // Arrange
            const int Value = 1;

            IDescriptionBuilder builder = null;

            this.mocks.ReplayAll();

            // Act
            var fizzBuzzEntry = new FizzBuzzEntry(Value, builder);

            // Assert
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void Constructor_WithValidValues_ExpectCallToDescriptionBuilder()
        {
            // Arrange
            const int Value = 1;
            const string Description = "Some Description!";

            var builder = this.mocks.StrictMock<IDescriptionBuilder>();
            Expect.Call(builder.GetDescription(Value)).Return(Description);

            this.mocks.ReplayAll();

            // Act
            var fizzBuzzEntry = new FizzBuzzEntry(Value, builder);

            // Assert
            Assert.IsNotNull(fizzBuzzEntry);
            Assert.AreEqual(Value, fizzBuzzEntry.Value);
            Assert.AreEqual(Description, fizzBuzzEntry.Description);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void ToString_FizzBuzzEntry_ExpectCorrectString()
        {
            // Arrange
            const int Value = 15;
            const string Description = "FizzBuzz!";

            var expectedResult = String.Format("{0}. {1}", Value, Description);

            var builder = this.mocks.StrictMock<IDescriptionBuilder>();
            Expect.Call(builder.GetDescription(Value)).Return(Description);

            this.mocks.ReplayAll();

            var fizzBuzzEntry = new FizzBuzzEntry(Value, builder);

            // Act
            var result = fizzBuzzEntry.ToString();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}
