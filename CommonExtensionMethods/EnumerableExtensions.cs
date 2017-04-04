using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonExtensionMethods
{
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Counts the number of times each element appears in a collection, and returns a
        ///     <see cref="IDictionary{TKey,TValue}">dictionary</see> where each key is an element and its
        ///     value is the number of times that element appeared in the source collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The extended IEnumerable</param>
        /// <returns>A dictionary of elements mapped to the number of times they appeared in <paramref name="input" />.</returns>
        public static IDictionary<T, int> CountInstances<T>(this IEnumerable<T> input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input), "CountInstances called on a null IEnumerable<T>.");

            var result = new Dictionary<T, int>();

            foreach (T element in input.Where(item => item != null))
            {
                if (result.ContainsKey(element)) ++result[element];
                else result[element] = 1;
            }

            return result;
        }

        /// <summary>
        ///     Returns a List of Items that is distincted by a particular element
        /// </summary>
        /// <typeparam name="T">The object that the enumerable contains</typeparam>
        /// <typeparam name="TKey">The value you want to be distincted by</typeparam>
        /// <param name="input">The extended IEnumerable</param>
        /// <param name="keySelector">The lambda of the distinction</param>
        /// <returns>New list of elements that are distincted by the specific key</returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> input, Func<T, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();

            foreach (T element in input)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        ///     Shuffles all elements within the Enumeration.
        ///     This will return a new List of shuffled values.
        /// </summary>
        /// <typeparam name="T">Type of elements that are contained within the Enumeration</typeparam>
        /// <param name="input">The enumeration that will be shuffled.</param>
        /// <returns cref="List{T}">Shuffled list of values</returns>
        public static IEnumerable<T> ShuffleElements<T>(this IEnumerable<T> input)
        {
            if (input == null) return null;
            var r = new Random((int)DateTime.Now.Ticks);
            var shuffledList = input.Select(x => new { Number = r.Next(), Item = x }).OrderBy(x => x.Number).Select(x => x.Item);
            return shuffledList.ToList();
        }

        /// <summary>
        ///     Continues processing items in a collection until the end condition is true.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to iterate.</param>
        /// <param name="endCondition">The condition that returns true if iteration should stop.</param>
        /// <returns>Iterator of sub-list.</returns>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> collection, Predicate<T> endCondition)
        {
            return collection.TakeWhile(item => !endCondition(item));
        }
    }
}
