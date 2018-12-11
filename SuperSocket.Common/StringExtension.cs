using System;

namespace SuperSocket.Common
{
    /// <summary>
    /// String extension class
    /// </summary>
    public static partial class StringExtension
    {
        /// <summary>
        /// Try parse delegate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private delegate bool TryParseDelegate<T>(string s, out T result);

        /// <summary>
        /// String to T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="parse"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static T To<T>(string value, TryParseDelegate<T> parse, T defaultValue)
            => string.IsNullOrEmpty(value) ? defaultValue : parse(value, out T result) ? result : defaultValue;
        
        /// <summary>
        /// Convert string to int32.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static int ToInt32(this string source)
            => To(source, int.TryParse, default(int));

        /// <summary>
        /// Convert string to int32.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static int ToInt32(this string source, int defaultValue)
            => To(source, int.TryParse, defaultValue);

        /// <summary>
        /// Convert string to long.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static long ToLong(this string source)
            => To(source, long.TryParse, default(long));

        /// <summary>
        /// Convert string to long.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static long ToLong(this string source, long defaultValue)
            => To(source, long.TryParse, defaultValue);

        /// <summary>
        /// Convert string to short.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static short ToShort(this string source)
            => To(source, short.TryParse, default(short));

        /// <summary>
        /// Convert string to short.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static short ToShort(this string source, short defaultValue)
            => To(source, short.TryParse, defaultValue);

        /// <summary>
        /// Convert string to decimal.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string source)
            => To(source, decimal.TryParse, default(decimal));

        /// <summary>
        /// Convert string to decimal.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string source, decimal defaultValue)
            => To(source, decimal.TryParse, defaultValue);

        /// <summary>
        /// Convert string to date time.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string source)
            => To(source, DateTime.TryParse, DateTime.MinValue);

        /// <summary>
        /// Convert string to date time.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string source, DateTime defaultValue)
            => To(source, DateTime.TryParse, defaultValue);

        /// <summary>
        /// Convert string to boolean.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static bool ToBoolean(this string source)
            => To(source, bool.TryParse, default(bool));

        /// <summary>
        /// Convert string tp boolean.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns></returns>
        public static bool ToBoolean(this string source, bool defaultValue)
            => To(source, bool.TryParse, defaultValue);

        /// <summary>
        /// Tries parse string to enum.
        /// </summary>
        /// <typeparam name="T">the enum type</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <param name="enumValue">The enum value.</param>
        /// <returns></returns>
        public static bool TryParseEnum<T>(this string value, bool ignoreCase, out T enumValue) where T : struct
            => Enum.TryParse(value, ignoreCase, out enumValue);
    }
}
