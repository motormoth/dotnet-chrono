using System;

namespace Motormoth.Chrono
{
    partial struct Date : IComparable, IComparable<Date>
    {
        /// <summary>
        /// Determines whether one specified <see cref="Date"/> represents a
        /// time that is earlier than another specified <see cref="Date"/>.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="d1"/> is earlier than
        /// <paramref name="d2"/>.
        /// </returns>
        public static bool operator <(Date d1, Date d2)
        {
            return d1.DayIndex < d2.DayIndex;
        }

        /// <summary>
        /// Determines whether one specified <see cref="Date"/> represents a
        /// time that is the same as or earlier than another specified <see cref="Date"/>.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="d1"/> is the same as or
        /// earlier than <paramref name="d2"/>.
        /// </returns>
        public static bool operator <=(Date d1, Date d2)
        {
            return d1.DayIndex <= d2.DayIndex;
        }

        /// <summary>
        /// Determines whether one specified <see cref="Date"/> represents a
        /// time that is later than another specified <see cref="Date"/>.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="d1"/> is later than
        /// <paramref name="d2"/>.
        /// </returns>
        public static bool operator >(Date d1, Date d2)
        {
            return d1.DayIndex > d2.DayIndex;
        }

        /// <summary>
        /// Determines whether one specified <see cref="Date"/> represents a
        /// time that is the same as or later than another specified <see cref="Date"/>.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="d1"/> is the same as or
        /// later than <paramref name="d2"/>.
        /// </returns>
        public static bool operator >=(Date d1, Date d2)
        {
            return d1.DayIndex >= d2.DayIndex;
        }

        /// <inheritdoc/>
        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                return 1;
            }

            return CompareTo((Date)obj);
        }

        /// <inheritdoc/>
        public int CompareTo(Date other)
        {
            return DayIndex.CompareTo(other.DayIndex);
        }
    }
}