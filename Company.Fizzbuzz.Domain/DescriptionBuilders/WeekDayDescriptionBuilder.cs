
namespace Company.Fizzbuzz.Domain.DescriptionBuilders
{
    public class WeekDayDescriptionBuilder : DescriptionBuilderBase
    {
        //// ----------------------------------------------------------------------------------------------------------

        protected override string GetDivisibleByFiveDescription()
        {
            return "Wuzz";
        }

        //// ----------------------------------------------------------------------------------------------------------

        protected override string GetDivisibleByThreeDescription()
        {
            return "Wizz";
        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}
