namespace Company.Fizzbuzz.Domain.DescriptionBuilders
{
    /// <summary>
    ///  Abstract Description Builder base class - uses the Template Pattern.
    /// </summary>
    public abstract class DescriptionBuilderBase : IDescriptionBuilder
    {
        public string GetDescription(int value)
        {
            // Is the number divisible by 3?
            var divisibleByThree = (value % 3) == 0;

            // Is the number divisible by 5?
            var divisibleByFive = (value % 5) == 0;

            // Is the number divisible by 3 and 5?
            if (divisibleByFive && divisibleByThree)
                return GetDivisibleByThreeAndFiveDescription();

            if (divisibleByThree)
                return GetDivisibleByThreeDescription();

            if (divisibleByFive)
                return GetDivisibleByFiveDescription();

            return value.ToString();
        }

        //// ----------------------------------------------------------------------------------------------------------

        private string GetDivisibleByThreeAndFiveDescription()
        {
            return GetDivisibleByThreeDescription() + GetDivisibleByFiveDescription();
        }

        //// ----------------------------------------------------------------------------------------------------------

        protected abstract string GetDivisibleByThreeDescription();

        //// ----------------------------------------------------------------------------------------------------------

        protected abstract string GetDivisibleByFiveDescription();

        //// ----------------------------------------------------------------------------------------------------------
    }
}
