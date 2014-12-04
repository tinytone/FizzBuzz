using Company.Fizzbuzz.Domain;
using System.Collections.Generic;

namespace Company.Fizzbuzz.Repository
{
    public interface IFizzBuzzRepository
    {
        //// ----------------------------------------------------------------------------------------------------------

        IEnumerable<IFizzBuzzEntry> Get(int entriesToRetrieve);

        //// ----------------------------------------------------------------------------------------------------------
    }
}
