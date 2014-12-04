using System;
using Company.Fizzbuzz.Domain.DescriptionBuilders;

namespace Company.Fizzbuzz.Domain
{
    public class FizzBuzzEntry : IFizzBuzzEntry
    {
        //// ----------------------------------------------------------------------------------------------------------

        public int Value { get; private set; }

        //// ----------------------------------------------------------------------------------------------------------

        public string Description { get; private set; }

        //// ----------------------------------------------------------------------------------------------------------

        public FizzBuzzEntry(int value, IDescriptionBuilder builder)
        {
            if (value < 1)
                throw new ArgumentOutOfRangeException("value");

            if (builder == null)
                throw new ArgumentNullException("builder");

            this.Value = value;
            this.Description = builder.GetDescription(value);
        }

        //// ----------------------------------------------------------------------------------------------------------

        public override string ToString()
        {
            return String.Format("{0}. {1}", this.Value, this.Description);
        }

        //// ----------------------------------------------------------------------------------------------------------
    }
}
