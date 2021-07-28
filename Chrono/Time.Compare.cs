using System;

namespace Motormoth.Chrono
{
    partial struct Time : IComparable, IComparable<Time>
    {
        /// <summary>
        /// Determines whether one specified <see cref="Time"/> represents a
        /// time that is earlier than another specified <see cref="Time"/>.
        /// </summary>
        /// <param name="t1">The first object to compare.</param>
        /// <param name="t2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="t1"/> is earlier than
        /// <paramref name="t2"/>.
        /// </returns>
        public static bool operator <(Time t1, Time t2)
        {
            return t1.SecondIndex < t2.SecondIndex;
        }

        /// <summary>
        /// Determines whether one specified <see cref="Time"/> represents a
        /// time that is the same as or earlier than another specified <see cref="Time"/>.
        /// </summary>
        /// <param name="t1">The first object to compare.</param>
        /// <param name="t2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="t1"/> is the same as or
        /// earlier than <paramref name="t2"/>.
        /// </returns>
        public static bool operator <=(Time t1, Time t2)
        {
            return t1.SecondIndex <= t2.SecondIndex;
        }

        /// <summary>
        /// Determines whether one specified <see cref="Time"/> represents a
        /// time that is later than another specified <see cref="Time"/>.
        /// </summary>
        /// <param name="t1">The first object to compare.</param>
        /// <param name="t2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="t1"/> is later than
        /// <paramref name="t2"/>.
        /// </returns>
        public static bool operator >(Time t1, Time t2)
        {
            return t1.SecondIndex > t2.SecondIndex;
        }

        /// <summary>
        /// Determines whether one specified <see cref="Time"/> represents a
        /// time that is the same as or later than another specified <see cref="Time"/>.
        /// </summary>
        /// <param name="t1">The first object to compare.</param>
        /// <param name="t2">The second object to compare.</param>
        /// <returns>
        /// A value indicating whether <paramref name="t1"/> is the same as or
        /// later than <paramref name="t2"/>.
        /// </returns>
        public static bool operator >=(Time t1, Time t2)
        {
            return t1.SecondIndex >= t2.SecondIndex;
        }

        /// <inheritdoc/>
        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                return 1;
            }

            return CompareTo((Time)obj);
        }

        /// <inheritdoc/>
        public int CompareTo(Time other)
        {
            return SecondIndex.CompareTo(other.SecondIndex);
        }
    }
}