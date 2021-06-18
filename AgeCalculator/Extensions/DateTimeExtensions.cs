using AgeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AgeCalculator.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToAgeString(this DateTime dateOfBirth)
        {
            DateTime Now = DateTime.Now;
            int years = new DateTime(Now.Subtract(dateOfBirth).Ticks).Year - 1;
            DateTime PastYearDate = dateOfBirth.AddYears(years);

            int months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    months = i - 1;
                    break;
                }
            }
            return $"{ years } years and { months } months";
        }


        public static int ToDaysBeforeNextBirthday(this DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            DateTime next = new DateTime(today.Year, dateOfBirth.Month, dateOfBirth.Day);

            if (next < today)
                next = next.AddYears(1);

            int numDays = (next - today).Days;
            //var t = DateTime.Today.AddDays(numDays - 14);


            return numDays;

        }

    }
}