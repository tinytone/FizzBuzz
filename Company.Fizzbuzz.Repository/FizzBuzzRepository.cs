using System;
using System.Collections.Generic;
using Company.Fizzbuzz.Domain;
using Company.Fizzbuzz.Domain.DescriptionBuilders;

namespace Company.Fizzbuzz.Repository
{
    public class FizzBuzzRepository : IFizzBuzzRepository
    {
        //// ----------------------------------------------------------------------------------------------------------

        private readonly IDescriptionBuilder descriptionBuilder;

        //// ----------------------------------------------------------------------------------------------------------

        public FizzBuzzRepository(IDescriptionBuilder descriptionBuilder)
        {
            if (descriptionBuilder == null)
                throw new ArgumentNullException("descriptionBuilder");

            // Note: descriptionBuilder is injected by the IOC Container: See Company.Fizzbuzz.Web.Host.DependencyResolution.DefaultRegistry.
            // This could also be implemented using a Factory to determine the appropriate descriptionBuilder.
            // For now, Keeping It Simple Stupid (KISS)
            this.descriptionBuilder = descriptionBuilder;
        }

        //// ----------------------------------------------------------------------------------------------------------

        public IEnumerable<IFizzBuzzEntry> Get(int entriesToRetrieve)
        {
            if (entriesToRetrieve < 0)
                throw new ArgumentOutOfRangeException("entriesToRetrieve");
                        
            for (var i = 1; i <= entriesToRetrieve; i++)
                yield return new FizzBuzzEntry(i, descriptionBuilder);
        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}
