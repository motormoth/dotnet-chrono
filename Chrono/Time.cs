using System;

namespace Motormoth.Chrono
{
    /// <summary>
    /// Represents a standart time of day. Allows for the second precision.
    /// </summary>
    public partial struct Time
    {
        /// <summary>
        /// Represents the minimum value of <see cref="Time"/>. This field is read-only.
        /// </summary>
        public static readonly Time MinValue = new(0);

        /// <summary>
        /// Represents the maximum value of <see cref="Time"/>. This field is read-only.
        /// </summary>
        public static readonly Time MaxValue = new(SecondsPer1Minute * MinutesPer1Hour * HoursPer1Day - 1);

        private const int HoursPer1Day = 24;

        private const int MinutesPer1Hour = 60;

        private const int SecondsPer1Minute = 60;

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> structure to
        /// the specified hour, minute and second.
        /// </summary>
        /// <param name="hour">The hour number from 0 to 23.</param>
        /// <param name="minute">The minute number from 0 to 59.</param>
        /// <param name="second">The second number from 0 to 59.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The hour number is out of range.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The minute number is out of range.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The second number is out of range.
        /// </exception>
        public Time(int hour, int minute, int second)
        {
            if (hour < 0 || hour > HoursPer1Day - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(hour));
            }

            if (minute < 0 || minute > MinutesPer1Hour - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(minute));
            }

            if (second < 0 || second > SecondsPer1Minute - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(second));
            }

            SecondIndex = hour * MinutesPer1Hour * SecondsPer1Minute + minute * SecondsPer1Minute + second;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> structure to
        /// the specified second index.
        /// </summary>
        /// <param name="secondIndex">The number of seconds from midnight.</param>
        public Time(int secondIndex)
        {
            SecondIndex = secondIndex % (SecondsPer1Minute * MinutesPer1Hour * HoursPer1Day);
        }

        /// <summary>
        /// Gets the number of seconds from midnight.
        /// </summary>
        public int SecondIndex { get; }

        /// <summary>
        /// Gets the second number from 0 to 59.
        /// </summary>
        public int Second => SecondIndex % SecondsPer1Minute;

        /// <summary>
        /// Gets the minute number from 0 to 59.
        /// </summary>
        public int Minute => SecondIndex / SecondsPer1Minute % MinutesPer1Hour;

        /// <summary>
        /// Gets the hour number from 0 to 23.
        /// </summary>
        public int Hour => SecondIndex / (SecondsPer1Minute * MinutesPer1Hour) % HoursPer1Day;

        /// <summary>
        /// Adds the specified <see cref="TimeSpan"/> to a specified <see cref="Time"/>.
        /// </summary>
        /// <param name="time">The time to add to.</param>
        /// <param name="span">The time interval to add.</param>
        /// <returns>
        /// An object whose value is the value of <paramref name="time"/> plus
        /// the value of <paramref name="span"/>.
        /// </returns>
        public static Time operator +(Time time, TimeSpan span)
        {
            return time.Add(span);
        }

        /// <summary>
        /// Subtracts the specified <see cref="TimeSpan"/> from a specified <see cref="Time"/>.
        /// </summary>
        /// <param name="time">The time to subtract from.</param>
        /// <param name="span">The time interval to subtract.</param>
        /// <returns>
        /// An object whose value is the value of <paramref name="time"/> minus
        /// the value of <paramref name="span"/>.
        /// </returns>
        public static Time operator -(Time time, TimeSpan span)
        {
            return time.Substract(span);
        }

        /// <summary>
        /// Returns a new <see cref="Time"/> that adds the value of the
        /// specified <see cref="TimeSpan"/> to the value of this instance.
        /// </summary>
        /// <param name="span">The time interval to add.</param>
        /// <returns>
        /// An object that is equal to the time represented by this instance
        /// plus the time interval represented by <paramref name="span"/>.
        /// </returns>
        public Time Add(TimeSpan span)
        {
            var spanSeconds = (int)span.TotalSeconds;

            return new Time(SecondIndex + spanSeconds);
        }

        /// <summary>
        /// Returns a new <see cref="Time"/> that substracts the value of the
        /// specified <see cref="TimeSpan"/> from the value of this instance.
        /// </summary>
        /// <param name="span">The time interval to subtract.</param>
        /// <returns>
        /// An object that is equal to the time represented by this instance
        /// minus the time interval represented by <paramref name="span"/>.
        /// </returns>
        public Time Substract(TimeSpan span)
        {
            var spanSeconds = (int)span.TotalSeconds;

            return new Time(SecondIndex - spanSeconds);
        }

        /// <summary>
        /// Returns a new <see cref="Time"/> that adds the specified number of
        /// seconds to the value of this instance.
        /// </summary>
        /// <param name="seconds">The number of seconds.</param>
        /// <returns>
        /// An object that is equal to the time represented by this instance
        /// plus the number of seconds represented by <paramref name="seconds"/>.
        /// </returns>
        public Time AddSeconds(int seconds)
        {
            return new Time(SecondIndex + seconds);
        }

        /// <summary>
        /// Returns a new <see cref="Time"/> that adds the specified number of
        /// minutes to the value of this instance.
        /// </summary>
        /// <param name="minutes">The number of minutes.</param>
        /// <returns>
        /// An object that is equal to the time represented by this instance
        /// plus the number of minutes represented by <paramref name="minutes"/>.
        /// </returns>
        public Time AddMinutes(int minutes)
        {
            return AddSeconds(minutes * SecondsPer1Minute);
        }

        /// <summary>
        /// Returns a new <see cref="Time"/> that adds the specified number of
        /// hours to the value of this instance.
        /// </summary>
        /// <param name="hours">The number of hours.</param>
        /// <returns>
        /// An object that is equal to the time represented by this instance
        /// plus the number of hours represented by <paramref name="hours"/>.
        /// </returns>
        public Time AddHours(int hours)
        {
            return AddSeconds(hours * MinutesPer1Hour * SecondsPer1Minute);
        }
    }
}