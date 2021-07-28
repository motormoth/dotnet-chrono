using System;

namespace Motormoth.Chrono
{
    partial struct Date : IEquatable<Date>
    {
        /// <summary>
        /// Returns a value indicating whether two <see cref="Date"/> instances
        /// are equal.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="d1"/> and <paramref
        /// name="d2"/> are equal.
        /// </returns>
        public static bool Equals(Date d1, Date d2)
        {
            return d1.DayIndex == d2.DayIndex;
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="Date"/> are equal.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="d1"/> and <paramref
        /// name="d2"/> are equal.
        /// </returns>
        public static bool operator ==(Date d1, Date d2)
        {
            return d1.DayIndex == d2.DayIndex;
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="Date"/> are
        /// not equal.
        /// </summary>
        /// <param name="d1">The first object to compare.</param>
        /// <param name="d2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="d1"/> and <paramref
        /// name="d2"/> are not equal.
        /// </returns>
        public static bool operator !=(Date d1, Date d2)
        {
            return d1.DayIndex != d2.DayIndex;
        }

        /// <summary>
        /// Returns a value indicating whether the value of this instance is
        /// equal to the value of the specified object.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>
        /// A value indicating whether the value of this instance is equal to
        /// the value of other instance, represented by <paramref name="obj"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Date other && Equals(other);
        }

        /// <summary>
        /// Returns a value indicating whether the value of this instance is
        /// equal to the value of the specified <see cref="Time"/> instance.
        /// </summary>
        /// <param name="other">The object to compare to this instance.</param>
        /// <returns>
        /// A value indicating whether the value of this instance is equal to
        /// the value of other instance, represented by <paramref name="other"/>.
        /// </returns>
        public bool Equals(Date other)
        {
            return DayIndex == other.DayIndex;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return DayIndex ^ DayIndex >> 32;
        }
    }
}