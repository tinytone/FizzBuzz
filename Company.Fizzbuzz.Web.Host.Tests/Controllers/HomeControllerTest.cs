using Company.Fizzbuzz.Domain;
using Company.Fizzbuzz.Repository;
using Company.Fizzbuzz.Web.Host.Controllers;
using Company.Fizzbuzz.Web.Host.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Company.Fizzbuzz.Web.Host.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
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
        public void Constructor_FizzBuzzRepositoryIsNull_ExpectArgumentNullException()
        {
            // Arrange
            IFizzBuzzRepository fizzBuzzRepository = null;

            // Act
            var controller = new HomeController(fizzBuzzRepository);

            // Assert
        }

        //// ----------------------------------------------------------------------------------------------------------

        //[TestMethod]
        //public void Index_HttpGet_ExpectViewResult()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void List_TotalCountIsAlphabeticChars_ExpectErrorInModelState()
        {
            // Arrange
            const string totalCount = "asdb";

            var fizzBuzzRepository = this.mocks.StrictMock<IFizzBuzzRepository>();

            this.mocks.ReplayAll();

            var controller = new HomeController(fizzBuzzRepository);

            // Act
            var result = controller.List(totalCount) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData);
            Assert.IsNotNull(result.ViewData.ModelState);
            Assert.IsNotNull(result.ViewData.ModelState["TotalCountNonNumeric"]);
            Assert.AreEqual(result.ViewData.ModelState["TotalCountNonNumeric"].Errors.Count, 1);
            Assert.AreEqual(result.ViewData.ModelState["TotalCountNonNumeric"].Errors[0].ErrorMessage, "Value must be numeric!");
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void List_TotalCountIsFive_ExpectViewResult()
        {
            // Arrange
            const string totalCount = "5";

            var fakeFizzBuzzEntries = new List<IFizzBuzzEntry>
            {
                GetFizzBuzzEntry(1),
                GetFizzBuzzEntry(2),
                GetFizzBuzzEntry(3),
                GetFizzBuzzEntry(4),
                GetFizzBuzzEntry(5),
            };

            var fizzBuzzRepository = this.mocks.StrictMock<IFizzBuzzRepository>();
            Expect.Call(fizzBuzzRepository.Get(5)).Return(fakeFizzBuzzEntries);

            this.mocks.ReplayAll();

            var controller = new HomeController(fizzBuzzRepository);

            // Act
            ViewResult result = controller.List(totalCount) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData);

            var viewModel = result.ViewData.Model as FizzBuzzViewModel;
            Assert.IsNotNull(viewModel);

            var fizzBuzzEntries = viewModel.FizzBuzzEntries.ToList();
            Assert.AreEqual(5, fizzBuzzEntries.Count);
            Assert.AreEqual(fakeFizzBuzzEntries[0], fizzBuzzEntries[0]);
            Assert.AreEqual(fakeFizzBuzzEntries[1], fizzBuzzEntries[1]);
            Assert.AreEqual(fakeFizzBuzzEntries[2], fizzBuzzEntries[2]);
            Assert.AreEqual(fakeFizzBuzzEntries[3], fizzBuzzEntries[3]);
            Assert.AreEqual(fakeFizzBuzzEntries[4], fizzBuzzEntries[4]);
        }

        //// ----------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void List_TotalCountIsEmptyString_ExpectViewResultWithNoViewModel()
        {
            // Arrange
            const string totalCount = "";

            var fizzBuzzRepository = this.mocks.StrictMock<IFizzBuzzRepository>();

            this.mocks.ReplayAll();

            var controller = new HomeController(fizzBuzzRepository);

            // Act
            var result = controller.List(totalCount) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData);
            Assert.IsNull(result.ViewData.Model);
            Assert.IsNotNull(result.ViewData.ModelState);
            Assert.AreEqual(result.ViewData.ModelState.Count, 0);
        }

        [TestMethod]
        public void List_FiveItemsAndPageSizeIs2AndCurrentPageIs3_ExpectViewResultWithCorrectPagingInfo()
        {
            // Arrange
            const int Page = 3;
            const int PageSize = 2;

            const string totalCount = "5";

            var fakeFizzBuzzEntries = new List<IFizzBuzzEntry>
            {
                GetFizzBuzzEntry(1),
                GetFizzBuzzEntry(2),
                GetFizzBuzzEntry(3),
                GetFizzBuzzEntry(4),
                GetFizzBuzzEntry(5),
            };

            var fizzBuzzRepository = this.mocks.StrictMock<IFizzBuzzRepository>();
            Expect.Call(fizzBuzzRepository.Get(5)).Return(fakeFizzBuzzEntries);

            this.mocks.ReplayAll();

            var controller = new HomeController(fizzBuzzRepository);
            controller.PageSize = PageSize;

            // Act
            ViewResult result = controller.List(totalCount, Page) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData);

            var viewModel = result.ViewData.Model as FizzBuzzViewModel;
            Assert.IsNotNull(viewModel);

            Assert.IsNotNull(viewModel.PagingInfo);
            Assert.AreEqual(viewModel.PagingInfo.CurrentPage, Page);
            Assert.AreEqual(viewModel.PagingInfo.ItemsPerPage, PageSize);
            Assert.AreEqual(viewModel.PagingInfo.TotalItems, fakeFizzBuzzEntries.Count);
            Assert.AreEqual(viewModel.PagingInfo.TotalPages, 3);
        }

        //// ----------------------------------------------------------------------------------------------------------

        private IFizzBuzzEntry GetFizzBuzzEntry(int value)
        {
            var fizzBuzzentry = this.mocks.StrictMock<IFizzBuzzEntry>();
            Expect.Call(fizzBuzzentry.Value).Return(value);

            return fizzBuzzentry;
        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}
