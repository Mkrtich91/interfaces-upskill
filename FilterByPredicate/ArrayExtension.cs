using System;
using System.Collections.Generic;

namespace FilterByPredicate
{
    /// <summary>
    /// Contains sz-array extension method.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain elements that correspond given predicate only.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="predicate">Predicate.</param>
        /// <returns>Array of elements that correspond given predicate only.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when predicate is null.</exception>
        public static int[] Select(this int[]? source, IPredicate? predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Array cannot be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.", nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");
            }

            List<int> filteredArray = new List<int>();
#pragma warning disable S3267
            foreach (int num in source)
            {
                if (predicate.IsMatch(num))
                {
                    filteredArray.Add(num);
                }
            }
#pragma warning restore S3267
            return filteredArray.ToArray();
        }
    }
}
