using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        ///     <see cref="string.IsNullOrEmpty" /> This just makes the code more readable for IsNullOrEmpty
        /// </summary>
        /// <param name="input">String to check is null or empty</param>
        /// <example>
        ///     var testString = "dfaad";
        ///     var result = testString.IsNullOrEmpty()
        ///     rather than
        ///     var result = string.IsNullOrEmpty(testString);
        /// </example>
        /// <returns>True - if the string is null or empty, False if the string has a value</returns>
        [DebuggerStepThrough]
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        /// <summary>
        ///     Implements the ToString Method, but incase the nullable object is equal to null it will return the passed in
        ///     default value.
        /// </summary>
        /// <typeparam name="T">type that is a struct</typeparam>
        /// <param name="nullable">the extended struct</param>
        /// <param name="defaultValue">default string in case the nullable is equal to null</param>
        /// <example>
        ///     int? test = null;
        ///     var result = test.ToStringOrDefault("N/A");
        /// </example>
        /// <returns cref="string">If Null, the default value passed in. If not null, the value it returned.</returns>
        public static string ToStringOrDefault<T>(this T? nullable, string defaultValue) where T : struct
        {
            return nullable?.ToString() ?? defaultValue;
        }

        /// <summary>
        ///     Implements the ToString Method, but incase the nullable object is equal to null it will return the passed in
        ///     default value.
        /// </summary>
        /// <typeparam name="T">type that is a struct</typeparam>
        /// <param name="nullable">the extended struct</param>
        /// <param name="defaultValue">default string in case the nullable is equal to null</param>
        /// <example>
        ///     DateTime? test = null;
        ///     var result = test.ToStringOrDefault("dd-MM-yyyy", "N/A");
        /// </example>
        /// <returns cref="string">value</returns>
        public static string ToStringOrDefault<T>(this T? nullable, string format, string defaultValue) where T : struct, IFormattable
        {
            return nullable?.ToString(format, CultureInfo.CurrentCulture) ?? defaultValue;
        }

        /// <summary>
        ///     Strips all XML and elements within XML out of the string.
        ///     Same method is used to strip XML, this is just inplace to make it more clear that it is HTML rather than XML.
        /// </summary>
        /// <param name="input">extended string that needs to be stripped</param>
        /// <returns cref="string">string of data that is stripped of all xml</returns>
        public static string StripXml(this string input)
        {
            return input.StripHtml();
        }

        /// <summary>
        ///     Strips all Html off an extended string.
        /// </summary>
        /// <param name="input">extended string that needs to be stripped</param>
        /// <returns cref="string">string of data that is stripped of all html</returns>
        public static string StripHtml(this string input)
        {
            return Regex.Replace(input, @"<(.|\n)*?>", string.Empty);
        }

        /// <summary>
        ///     Reduce string to shorter preview which is optionally ended by some string (...).
        /// </summary>
        /// <param name="input">string to reduce</param>
        /// <param name="numberOfCharactersToDisplay">Length of returned string including endingString.</param>
        /// <param name="endingString">optional edings of reduced text</param>
        /// <example>
        ///     string description = "This is very long description of something";
        ///     string preview = description.ReduceForDisplay(20,"...");
        ///     produce -> "This is very long..."
        /// </example>
        /// <returns>The reduced string with the ending appended.</returns>
        public static string ReduceForDisplay(this string input, int numberOfCharactersToDisplay, string endingString)
        {
            if (numberOfCharactersToDisplay < endingString.Length)
                throw new ArgumentException("Number of characters to Display needs to include endingString.Length characters as well.");
            int inputLength = input.Length;
            int length = inputLength;
            if (!string.IsNullOrWhiteSpace(endingString))
                length += endingString.Length;
            if (numberOfCharactersToDisplay > inputLength)
                return input; //it'input too short to reduce
            input = input.Substring(0, inputLength - length + numberOfCharactersToDisplay);
            if (!string.IsNullOrWhiteSpace(endingString))
                input += endingString;
            return input;
        }

        /// <summary>
        /// Useful to get only digits from a user inputed string. (i.e. Credit Card, SSN, Phone Number)
        /// </summary>
        /// <param name="input">The full input string.</param>
        /// <returns cref="string">A new string where the characters are only digits.</returns>
        public static string OnlyDigits(this string input)
        {
            return new string(input?.Where(char.IsDigit).ToArray());
        }
    }
}
