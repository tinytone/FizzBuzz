namespace Company.Fizzbuzz.Domain.DescriptionBuilders
{
    public class FizzBuzzDescriptionBuilder : DescriptionBuilderBase
    {
        //// ----------------------------------------------------------------------------------------------------------

        protected override string GetDivisibleByFiveDescription()
        {
            return "Buzz";
        }

        //// ----------------------------------------------------------------------------------------------------------

        protected override string GetDivisibleByThreeDescription()
        {
            return "Fizz";
        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}
