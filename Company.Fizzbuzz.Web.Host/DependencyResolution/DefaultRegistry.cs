using System;
using Company.Fizzbuzz.Repository;
using StructureMap.Configuration.DSL;
using Company.Fizzbuzz.Domain.DescriptionBuilders;

namespace Company.Fizzbuzz.Web.Host.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        //// ----------------------------------------------------------------------------------------------------------

        public DefaultRegistry()
        {
            // Inject a WeekDayDescriptionBuilder instead of a FizzBuzzDescriptionBuilder under certain circumstances
            if (ShouldUseWeekDayDescriptionBuilder())
                For<IDescriptionBuilder>().Use<WeekDayDescriptionBuilder>();
            else
                For<IDescriptionBuilder>().Use<FizzBuzzDescriptionBuilder>();

            For<IFizzBuzzRepository>().Use<FizzBuzzRepository>();
        }

        //// ----------------------------------------------------------------------------------------------------------

        private bool ShouldUseWeekDayDescriptionBuilder()
        {
            // Note: This setting could be read in the from the app.config file
            return DateTime.UtcNow.DayOfWeek == DayOfWeek.Wednesday;
        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}