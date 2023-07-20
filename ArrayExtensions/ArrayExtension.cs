using System;
using System.Globalization;

namespace ArrayExtensions
{
    /// <summary>
    /// Class of the additional operations with array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain expected digit from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="digit">Expected digit.</param>
        /// <returns>Array of elements that contain expected digit.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit value is out of range (0..9).</exception>
        /// <example>
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7.
        /// </example>
        public static int[] FilterByDigit(this int[]? source, int digit)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Array cannot be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.", nameof(source));
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Digit must be between 0 and 9.");
            }

            List<int> filteredElements = new List<int>();

            foreach (int number in source)
            {
                if (ContainsDigit(number, digit))
                {
                    filteredElements.Add(number);
                }
            }

            return filteredElements.ToArray();
        }

        private static bool ContainsDigit(int number, int digit)
        {
            number = Math.Abs(number);
            if (number == 0 && digit == 0)
            {
                return true;
            }

            while (number != 0)
            {
                int currentDigit = number % 10;
                if (currentDigit == digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }

        /// <summary>
        /// Returns new array that contains only palindromic numbers from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of elements that are palindromic numbers.</returns>
        /// <exception cref="ArgumentNullException">Throw when array is null.</exception>
        /// <exception cref="ArgumentException">Throw when array is empty.</exception>
        /// <example>
        /// {12345, 1111111112, 987654, 56, 1111111, -1111, 1, 1233321, 70, 15, 123454321}  => { 1111111, 123321, 123454321 }
        /// {56, -1111111112, 987654, 56, 890, -1111, 543, 1233}  => {  }.
        /// </example>
#pragma warning disable SA1202
        public static int[] FilterByPalindromic(this int[]? source)
#pragma warning restore SA1202
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array is empty.", nameof(source));
            }

            List<int> filteredArray = new List<int>();
            foreach (int num in source)
            {
                if (IsMatch(num))
                {
                    filteredArray.Add(num);
                }
            }

            return filteredArray.ToArray();

            static bool IsMatch(int value)
            {
                string strNum = value.ToString(CultureInfo.InvariantCulture);
                int left = 0;
                int right = strNum.Length - 1;
                while (left < right)
                {
                    if (strNum[left] != strNum[right])
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
}
