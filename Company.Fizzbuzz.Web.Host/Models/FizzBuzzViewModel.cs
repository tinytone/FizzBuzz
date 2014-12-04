using System.Collections.Generic;
using Company.Fizzbuzz.Domain;
using System.Linq;

namespace Company.Fizzbuzz.Web.Host.Models
{
    public class FizzBuzzViewModel
    {
        //// ----------------------------------------------------------------------------------------------------------

        public IEnumerable<IFizzBuzzEntry> FizzBuzzEntries { get; set; }

        //// ----------------------------------------------------------------------------------------------------------

        public bool FizzBuzzEntriesExist 
        {
            get
            {
                return this.FizzBuzzEntries != null && this.FizzBuzzEntries.Count() > 0;
            }
        }

        //// ----------------------------------------------------------------------------------------------------------

        public PagingInfo PagingInfo { get; set; }

        //// ----------------------------------------------------------------------------------------------------------
    }
}