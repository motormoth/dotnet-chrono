using System;
using System.Globalization;

namespace Motormoth.Chrono
{
    partial struct Time
    {
        /// <summary>
        /// Converts the string representation of a time to its <see
        /// cref="Time"/> equivalent.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>
        /// An object that is equivalent to the time contained in <paramref name="value"/>.
        /// </returns>
        public static Time Parse(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Length != 6)
            {
                throw new FormatException();
            }

            var h = int.Parse(value.Substring(0, 2), CultureInfo.CurrentCulture);
            var m = int.Parse(value.Substring(2, 2), CultureInfo.CurrentCulture);
            var s = int.Parse(value.Substring(4, 2), CultureInfo.CurrentCulture);

            return new Time(h, m, s);
        }

        /// <summary>
        /// Converts the value of the specified <see cref="DateTime"/> object to
        /// its <see cref="Time"/> equivalent.
        /// </summary>
        /// <returns>
        /// A <see cref="Time"/> equivalent of the value of the specified <see
        /// cref="DateTime"/> object.
        /// </returns>
        public static Time FromDateTime(DateTime dateTime)
        {
            return new Time(dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        /// <summary>
        /// Converts the value of the current <see cref="Time"/> object to its
        /// <see cref="DateTime"/> equivalent.
        /// </summary>
        /// <returns>
        /// A <see cref="DateTime"/> equivalent of the value of the current <see
        /// cref="Time"/> object.
        /// </returns>
        public DateTime ToDateTime()
        {
            return new DateTime(1, 1, 1, Hour, Minute, Second);
        }

        /// <summary>
        /// Converts the value of the current <see cref="Time"/> object to its
        /// <see cref="TimeSpan"/> equivalent.
        /// </summary>
        /// <returns>
        /// A <see cref="TimeSpan"/> equivalent of the value of the current <see
        /// cref="Time"/> object.
        /// </returns>
        public TimeSpan ToTimeSpan()
        {
            return new TimeSpan(Hour, Minute, Second);
        }

        /// <summary>
        /// Converts the value of the current <see cref="Time"/> object to its
        /// equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the value of the current <see
        /// cref="Time"/> object.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0:D2}:{1:D2}:{2:D2}", Hour, Minute, Second);
        }
    }
}