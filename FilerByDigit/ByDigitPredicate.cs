using System;
using System.Globalization;
using FilterByPredicate;

namespace FilterByDigit
{
    /// <summary>
    /// Predicate that determines the presence of some digit in integer.
    /// </summary>
    public class ByDigitPredicate : IPredicate
    {
        /// <summary>
        /// Gets or sets a digit.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Digit more than 9 or less than 0.</exception>
        public int Digit { get; set; }

        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            string stringValue = number.ToString(CultureInfo.InvariantCulture);
#pragma warning disable CA1307
            return stringValue.Contains(this.Digit.ToString(CultureInfo.InvariantCulture));
#pragma warning restore CA1307
        }
    }
}
