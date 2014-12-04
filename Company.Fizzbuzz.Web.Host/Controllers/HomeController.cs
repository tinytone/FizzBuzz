using System;
using System.Web.Mvc;
using Company.Fizzbuzz.Repository;
using Company.Fizzbuzz.Web.Host.Models;
using System.Linq;

namespace Company.Fizzbuzz.Web.Host.Controllers
{
    public class HomeController : Controller
    {
        //// ----------------------------------------------------------------------------------------------------------

        private readonly IFizzBuzzRepository fizzBuzzRepository;

        //// ----------------------------------------------------------------------------------------------------------

        public int PageSize { get; set; }

        //// ----------------------------------------------------------------------------------------------------------

        public HomeController(IFizzBuzzRepository fizzBuzzRepository)
        {
            if (fizzBuzzRepository == null)
                throw new ArgumentNullException("fizzBuzzRepository");

            this.fizzBuzzRepository = fizzBuzzRepository;
            this.PageSize = 10;
        }

        //// ----------------------------------------------------------------------------------------------------------

        public ActionResult List(string totalCount, int page = 1)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(totalCount))
                {
                    int actualTotalCount;

                    if (!int.TryParse(totalCount, out actualTotalCount))
                        ModelState.AddModelError("TotalCountNonNumeric", "Value must be numeric!");
                    else
                    {
                        var pagedResults = this.fizzBuzzRepository.Get(actualTotalCount)
                                                                  .OrderBy(fb => fb.Value)
                                                                  .Skip((page - 1) * PageSize)
                                                                  .Take(PageSize);
                        var pagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = actualTotalCount
                        };

                        var viewModel = new FizzBuzzViewModel
                        {
                            FizzBuzzEntries = pagedResults.ToList(),
                            PagingInfo = pagingInfo
                        };

                        return View(viewModel);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }

            return View();

        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}