using System;
using System.Globalization;

namespace Motormoth.Chrono
{
    partial struct Date
    {
        /// <summary>
        /// Converts the string representation of a date to its <see
        /// cref="Date"/> equivalent.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>
        /// An object that is equivalent to the date contained in <paramref name="value"/>.
        /// </returns>
        public static Date Parse(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Length != 8)
            {
                throw new FormatException();
            }

            var y = int.Parse(value.Substring(0, 4), CultureInfo.CurrentCulture);
            var m = int.Parse(value.Substring(4, 2), CultureInfo.CurrentCulture);
            var d = int.Parse(value.Substring(6, 2), CultureInfo.CurrentCulture);

            return new Date(y, m, d);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="DateTime"/> object to
        /// its <see cref="Date"/> equivalent.
        /// </summary>
        /// <returns>
        /// A <see cref="Date"/> equivalent of the value of the specified <see
        /// cref="DateTime"/> object.
        /// </returns>
        public static Date FromDateTime(DateTime value)
        {
            return new Date(value.Year, value.Month, value.Day);
        }

        /// <summary>
        /// Converts the value of the current <see cref="Date"/> object to its
        /// <see cref="DateTime"/> equivalent.
        /// </summary>
        /// <returns>
        /// A <see cref="DateTime"/> equivalent of the value of the current <see
        /// cref="Date"/> object.
        /// </returns>
        public DateTime ToDateTime()
        {
            return new DateTime(Year, Month, MonthDay);
        }

        /// <summary>
        /// Converts the value of the current <see cref="Date"/> object to its
        /// equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the value of the current <see
        /// cref="Date"/> object.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0:D4}-{1:D2}-{2:D2}", Year, Month, MonthDay);
        }
    }
}