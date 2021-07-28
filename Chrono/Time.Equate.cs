using System;

namespace Motormoth.Chrono
{
    partial struct Time : IEquatable<Time>
    {
        /// <summary>
        /// Returns a value indicating whether two <see cref="Time"/> instances
        /// are equal.
        /// </summary>
        /// <param name="t1">The first object to compare.</param>
        /// <param name="t2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="t1"/> and <paramref
        /// name="t2"/> are equal.
        /// </returns>
        public static bool Equals(Time t1, Time t2)
        {
            return t1.SecondIndex == t2.SecondIndex;
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="Time"/> are equal.
        /// </summary>
        /// <param name="t1">The first object to compare.</param>
        /// <param name="t2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="t1"/> and <paramref
        /// name="t2"/> are equal.
        /// </returns>
        public static bool operator ==(Time t1, Time t2)
        {
            return t1.SecondIndex == t2.SecondIndex;
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="Time"/> are
        /// not equal.
        /// </summary>
        /// <param name="t1">The first object to compare.</param>
        /// <param name="t2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="t1"/> and <paramref
        /// name="t2"/> are not equal.
        /// </returns>
        public static bool operator !=(Time t1, Time t2)
        {
            return t1.SecondIndex != t2.SecondIndex;
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
            return obj is Time time && Equals(time);
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
        public bool Equals(Time other)
        {
            return SecondIndex == other.SecondIndex;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return 1854779173 + SecondIndex.GetHashCode();
        }
    }
}