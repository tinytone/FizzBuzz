using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Company.Fizzbuzz.Web.Host.Models;

namespace Company.Fizzbuzz.Web.Host.Tests.Models
{
    [TestClass]
    public class PagingInfoTest
    {
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TotalPages_ItemsPerPageIsZero_ExpectDivideByZeroException()
        {
            // Arrange
            const int CurrentPage = 1;
            const int TotalItems = 10;
            const int ItemsPerPage = 0;

            var pagingInfo = new PagingInfo
            {
                CurrentPage = CurrentPage,
                TotalItems = TotalItems,
                ItemsPerPage = ItemsPerPage
            };

            // Act
            var result = pagingInfo.TotalPages;

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TotalPages_TotalItemsIsZero_ExpectZero()
        {
            // Arrange
            const int CurrentPage = 1;
            const int TotalItems = 0;
            const int ItemsPerPage = 10;

            var pagingInfo = new PagingInfo
            {
                CurrentPage = CurrentPage,
                TotalItems = TotalItems,
                ItemsPerPage = ItemsPerPage
            };

            // Act
            var result = pagingInfo.TotalPages;

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TotalPages_TotalItemsIs10AndIsLessThanItemsPerPage_ExpectOne()
        {
            // Arrange
            const int CurrentPage = 1;
            const int ItemsPerPage = 10;

            for (var totalItems = 1; totalItems < ItemsPerPage; totalItems++)
            {

                var pagingInfo = new PagingInfo
                {
                    CurrentPage = CurrentPage,
                    TotalItems = totalItems,
                    ItemsPerPage = ItemsPerPage
                };

                // Act
                var result = pagingInfo.TotalPages;

                // Assert
                Assert.AreEqual(result, 1);

            }
        }

        [TestMethod]
        public void TotalPages_TotalItemsIs10AndEqualsItemsPerPage_ExpectOne()
        {
            // Arrange
            const int CurrentPage = 1;
            const int TotalItems = 10;
            const int ItemsPerPage = 10;

            var pagingInfo = new PagingInfo
            {
                CurrentPage = CurrentPage,
                TotalItems = TotalItems,
                ItemsPerPage = ItemsPerPage
            };

            // Act
            var result = pagingInfo.TotalPages;

            // Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TotalPages_TotalItemsIs20ItemsPerPageIs10_ExpectTwo()
        {
            // Arrange
            const int CurrentPage = 1;
            const int TotalItems = 20;
            const int ItemsPerPage = 10;

            var pagingInfo = new PagingInfo
            {
                CurrentPage = CurrentPage,
                TotalItems = TotalItems,
                ItemsPerPage = ItemsPerPage
            };

            // Act
            var result = pagingInfo.TotalPages;

            // Assert
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TotalPages_TotalItemsIs25ItemsPerPageIs10_ExpectThree()
        {
            // Arrange
            const int CurrentPage = 1;
            const int TotalItems = 25;
            const int ItemsPerPage = 10;

            var pagingInfo = new PagingInfo
            {
                CurrentPage = CurrentPage,
                TotalItems = TotalItems,
                ItemsPerPage = ItemsPerPage
            };

            // Act
            var result = pagingInfo.TotalPages;

            // Assert
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TotalPages_TotalItemsIs30ItemsPerPageIs10_ExpectThree()
        {
            // Arrange
            const int CurrentPage = 1;
            const int TotalItems = 30;
            const int ItemsPerPage = 10;

            var pagingInfo = new PagingInfo
            {
                CurrentPage = CurrentPage,
                TotalItems = TotalItems,
                ItemsPerPage = ItemsPerPage
            };

            // Act
            var result = pagingInfo.TotalPages;

            // Assert
            Assert.AreEqual(result, 3);
        }
    }
}
