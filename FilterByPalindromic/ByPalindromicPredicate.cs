using System;
using System.Globalization;
using FilterByPredicate;

namespace FilterByPalindromic
{
    /// <summary>
    /// Palindrome predicate.
    /// </summary>
    public class ByPalindromicPredicate : IPredicate
    {
        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            string numberStr = number.ToString(CultureInfo.InvariantCulture);

            int left = 0;
            int right = numberStr.Length - 1;

            while (left < right)
            {
                if (numberStr[left] != numberStr[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }
    }
}
