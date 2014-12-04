using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Company.Fizzbuzz.Domain.DescriptionBuilders;

namespace Company.Fizzbuzz.Repository.Tests
{
    [TestClass]
    public class FizzBuzzRepositoryTest
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_IDescriptionBuilderIsNull_ExpectArgumentNullException()
        {
            // Arrange
            IDescriptionBuilder descriptionBuilder = null;

            // Act
            var repository = new FizzBuzzRepository(descriptionBuilder);

            // Assert
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void Constructor_AllDependenciesAreValid_ExpectInstance()
        {
            // Arrange
            var descriptionBuilder = this.mocks.StrictMock<IDescriptionBuilder>();

            this.mocks.ReplayAll();

            // Act
            var repository = new FizzBuzzRepository(descriptionBuilder);

            // Assert
            Assert.IsNotNull(repository);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Get_ItemsToGetIsNegative_ExpectArgumentOfRangeException()
        {
            // Arrange
            const int ItemsToGet = -1;

            var descriptionBuilder = this.mocks.StrictMock<IDescriptionBuilder>();

            this.mocks.ReplayAll();

            var repository = GetRepository(descriptionBuilder);

            // Act
            repository.Get(ItemsToGet).ToList();

            // Assert
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void Get_ItemsToGetIsZero_ExpectZeroFizzBuzzEntries()
        {
            // Arrange
            const int ItemsToGet = 0;

            var descriptionBuilder = this.mocks.StrictMock<IDescriptionBuilder>();

            this.mocks.ReplayAll();

            var repository = GetRepository(descriptionBuilder);

            // Act
            var result = repository.Get(ItemsToGet).ToList();

            // Assert
            Assert.AreEqual(result.Count, 0);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void Get_ItemsToGetIsOne_ExpectOneFizzBuzzEntry()
        {
            // Arrange
            const int ItemsToGet = 1;

            var descriptionBuilder = this.mocks.StrictMock<IDescriptionBuilder>();
            Expect.Call(descriptionBuilder.GetDescription(1)).Return("1");

            this.mocks.ReplayAll();

            var repository = GetRepository(descriptionBuilder);

            // Act
            var result = repository.Get(ItemsToGet).ToList();

            // Assert
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].Value, 1);
            Assert.AreEqual(result[0].Description, "1");
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void Get_ItemsToGetIsFive_ExpectFiveFizzBuzzEntries()
        {
            // Arrange
            const int ItemsToGet = 5;

            var descriptionBuilder = this.mocks.StrictMock<IDescriptionBuilder>();
            Expect.Call(descriptionBuilder.GetDescription(1)).Return("1");
            Expect.Call(descriptionBuilder.GetDescription(2)).Return("2");
            Expect.Call(descriptionBuilder.GetDescription(3)).Return("Fizz");
            Expect.Call(descriptionBuilder.GetDescription(4)).Return("4");
            Expect.Call(descriptionBuilder.GetDescription(5)).Return("Buzz");

            this.mocks.ReplayAll();

            var repository = GetRepository(descriptionBuilder);

            // Act
            var result = repository.Get(ItemsToGet).ToList();

            // Assert
            Assert.AreEqual(result.Count(), 5);
            Assert.AreEqual(result[0].Value, 1);
            Assert.AreEqual(result[0].Description, "1");
            Assert.AreEqual(result[1].Value, 2);
            Assert.AreEqual(result[1].Description, "2");
            Assert.AreEqual(result[2].Value, 3);
            Assert.AreEqual(result[2].Description, "Fizz");
            Assert.AreEqual(result[3].Value, 4);
            Assert.AreEqual(result[3].Description, "4");
            Assert.AreEqual(result[4].Value, 5);
            Assert.AreEqual(result[4].Description, "Buzz");
        }

        //// ----------------------------------------------------------------------------------------------------------

        private FizzBuzzRepository GetRepository(IDescriptionBuilder descriptionBuilder)
        {
            return new FizzBuzzRepository(descriptionBuilder);
        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}
