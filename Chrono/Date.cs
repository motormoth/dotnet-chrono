using System;

namespace Motormoth.Chrono
{
    /// <summary>
    /// Represents a standart calendar date.
    /// </summary>
    public partial struct Date
    {
        /// <summary>
        /// Represents minimum possible value of <see cref="Date"/>. This field
        /// is read-only.
        /// </summary>
        public static readonly Date MinValue = new(MinDayIndex);

        /// <summary>
        /// Represents maximum possible value of <see cref="Date"/>. This field
        /// is read-only.
        /// </summary>
        public static readonly Date MaxValue = new(MaxDayIndex);

        /// <summary>
        /// Minimum possible day index.
        /// </summary>
        private const int MinDayIndex = 0;

        /// <summary>
        /// Maximum possible day index.
        /// </summary>
        private const int MaxDayIndex = 3652058;

        /// <summary>
        /// The number of days in 1 common year.
        /// </summary>
        private const int DaysPer1Year = 365;

        /// <summary>
        /// The number of days in 4 years.
        /// </summary>
        /// <remarks>
        /// Last year is a leap year, because it is divisible by 4.
        /// </remarks>
        private const int DaysPer4Years = DaysPer1Year * 4 + 1; // 1461

        /// <summary>
        /// The number of days in 100 years.
        /// </summary>
        /// <remarks>
        /// Last year is a common year, because it is divisible by 100.
        /// </remarks>
        private const int DaysPer1Century = DaysPer4Years * 25 - 1; // 36524

        /// <summary>
        /// The number of days in 400 years.
        /// </summary>
        /// <remarks>
        /// Last year is a leap year, because it is divisible by 400.
        /// </remarks>
        private const int DaysPer4Centuries = DaysPer1Century * 4 + 1; // 146097

        private static readonly int[] DaysToMonth365 = new int[13]
        {
            0,
            31,
            59,
            90,
            120,
            151,
            181,
            212,
            243,
            273,
            304,
            334,
            365
        };

        private static readonly int[] DaysToMonth366 = new int[13]
        {
            0,
            31,
            60, // leap day, 29 feb
            91,
            121,
            152,
            182,
            213,
            244,
            274,
            305,
            335,
            366
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Date"/> structure to
        /// the specified year, month and day.
        /// </summary>
        /// <param name="year">The year number from 1 to 9999.</param>
        /// <param name="month">
        /// The month number from 1 to the number of months in <paramref name="year"/>.
        /// </param>
        /// <param name="monthDay">
        /// The day number from 1 to the number of days in <paramref name="month"/>.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="year"/> is out of range.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="month"/> is out of range.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="monthDay"/> is out of range.
        /// </exception>
        public Date(int year, int month, int monthDay)
        {
            CheckYear(year);
            CheckMonth(month);
            var daysToMonth = IsLeapYear(year) ? DaysToMonth366 : DaysToMonth365;
            var monthLength = GetMonthLength(month, daysToMonth);
            if (monthDay < 1 || monthDay > monthLength)
            {
                throw new ArgumentOutOfRangeException(nameof(monthDay));
            }

            // subtract 1 to get the index
            var yi = year - 1;
            var mi = month - 1;
            var mdi = monthDay - 1;
            DayIndex = yi * 365 + yi / 4 - yi / 100 + yi / 400 + daysToMonth[mi] + mdi;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Date"/> structure to
        /// the specified day index.
        /// </summary>
        /// <param name="dayIndex">The day index from 0 to 3652058.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="dayIndex"/> is out of range.
        /// </exception>
        public Date(int dayIndex)
        {
            if (dayIndex < MinDayIndex || dayIndex > MaxDayIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(dayIndex));
            }

            DayIndex = dayIndex;
        }

        private enum DatePart
        {
            Year = 0,
            YearDay,
            Month,
            MonthDay,
        }

        /// <summary>
        /// Gets the day index.
        /// </summary>
        public int DayIndex { get; }

        /// <summary>
        /// Get the day of the week.
        /// </summary>
        public int WeekDay => DayIndex % 7;

        /// <summary>
        /// Gets the year number.
        /// </summary>
        public int Year => GetPart(DatePart.Year);

        /// <summary>
        /// Gets the day of the year.
        /// </summary>
        public int YearDay => GetPart(DatePart.YearDay);

        /// <summary>
        /// Gets the month number.
        /// </summary>
        public int Month => GetPart(DatePart.Month);

        /// <summary>
        /// Gets the day of the month.
        /// </summary>
        public int MonthDay => GetPart(DatePart.MonthDay);

        /// <summary>
        /// Returns a value indicating whether the specified year is a leap year.
        /// </summary>
        /// <param name="year">The year number. Can be negative or zero.</param>
        /// <returns>
        /// <see cref="bool"/> indicating whether the specified year is a leap
        /// year or not.
        /// </returns>
        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        /// <summary>
        /// Returns number of days in specified month of the specified year.
        /// </summary>
        /// <param name="year">The year number. Can be negative or zero.</param>
        /// <param name="month">The month number from 1 to 12.</param>
        /// <remarks>
        /// For February, the return value is 28 or 29 depending upon whether
        /// <paramref name="year"/> is a leap year.
        /// </remarks>
        /// <returns>
        /// The number of days in <paramref name="month"/> of <paramref name="year"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="month"/> is out of range&gt;.
        /// </exception>
        public static int GetMonthLength(int year, int month)
        {
            CheckMonth(month);
            return GetMonthLength(month, IsLeapYear(year) ? DaysToMonth366 : DaysToMonth365);
        }

        /// <summary>
        /// Returns a new <see cref="Date"/> that adds the specified number of
        /// days to the value of this instance.
        /// </summary>
        /// <param name="days">The number of days.</param>
        /// <returns>
        /// An object that is equal to the date represented by this instance
        /// plus the number of days represented by <paramref name="days"/>.
        /// </returns>
        public Date AddDays(int days)
        {
            return new Date(DayIndex + days);
        }

        /// <summary>
        /// Returns a new <see cref="Date"/> that adds the specified number of
        /// months to the value of this instance.
        /// </summary>
        /// <param name="months">The number of months.</param>
        /// <returns>
        /// An object that is equal to the date represented by this instance
        /// plus the number of months represented by <paramref name="months"/>.
        /// </returns>
        public Date AddMonths(int months)
        {
            var year = GetPart(DatePart.Year);
            var month = GetPart(DatePart.Month);
            var monthDay = GetPart(DatePart.MonthDay);

            var resultMonthIndex = month - 1 + months;
            if (resultMonthIndex >= 0)
            {
                month = resultMonthIndex % 12 + 1;
                year += resultMonthIndex / 12;
            }
            else
            {
                month = 12 + (resultMonthIndex + 1) % 12;
                year += (resultMonthIndex - 11) / 12;
            }

            var daysInMonth = GetMonthLength(month, year);
            if (daysInMonth < monthDay)
            {
                monthDay = daysInMonth;
            }

            return new Date(year, month, monthDay);
        }

        /// <summary>
        /// Returns a new <see cref="Date"/> that adds the specified number of
        /// years to the value of this instance.
        /// </summary>
        /// <param name="years">The number of years.</param>
        /// <returns>
        /// An object that is equal to the date represented by this instance
        /// plus the number of years represented by <paramref name="years"/>.
        /// </returns>
        public Date AddYears(int years)
        {
            return AddMonths(years * 12);
        }

        private static int GetMonthLength(int month, int[] daysToMonth)
        {
            return daysToMonth[month] - daysToMonth[month - 1];
        }

        private static void CheckYear(int year)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException(nameof(year));
            }
        }

        private static void CheckMonth(int month)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month));
            }
        }

        private int GetPart(DatePart datePart)
        {
            var relativeDayIndex = DayIndex;

            // number of 400-year segments until day represented by this instance
            var n400y = relativeDayIndex / DaysPer4Centuries;

            relativeDayIndex -= n400y * DaysPer4Centuries;

            // number of 100-year segments within 400-year segment until day
            // represented by this instance
            var n100y = relativeDayIndex / DaysPer1Century;
            if (n100y == 4)
            {
                // fix number for last day of 400-year segment
                n100y = 3;
            }

            relativeDayIndex -= n100y * DaysPer1Century;

            // number of 4-year segments within 100-year segment until day
            // represented by this instance
            var n4y = relativeDayIndex / DaysPer4Years;

            relativeDayIndex -= n4y * DaysPer4Years;

            // number of years within 4-year segment until day represented by
            // this instance
            var n1y = relativeDayIndex / DaysPer1Year;
            if (n1y == 4)
            {
                // fix number for last day of 4-year segment
                n1y = 3;
            }

            if (datePart == DatePart.Year)
            {
                return n400y * 400 + n100y * 100 + n4y * 4 + n1y + 1;
            }

            relativeDayIndex -= n1y * DaysPer1Year;

            if (datePart == DatePart.YearDay)
            {
                return relativeDayIndex + 1;
            }

            var month = (relativeDayIndex + 1 >> 5) + 1;
            var leapYear = n1y == 3 && (n4y != 24 || n100y == 3);
            var daysToMonth = leapYear ? DaysToMonth366 : DaysToMonth365;
            while (relativeDayIndex > daysToMonth[month])
            {
                month++;
            }

            if (datePart == DatePart.Month)
            {
                return month;
            }

            relativeDayIndex -= daysToMonth[month - 1];

            if (datePart == DatePart.MonthDay)
            {
                return relativeDayIndex + 1;
            }

            throw new NotSupportedException();
        }
    }
}