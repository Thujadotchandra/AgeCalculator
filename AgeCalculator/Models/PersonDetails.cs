using AgeCalculator.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AgeCalculator.Models
{
    public class PersonDetails
    {
        private readonly Person _person;
        public PersonDetails()
        {

        }
        public PersonDetails(Person person)
        {
            _person = person;
            FourteenDaysDataTable = new DataTable("DaysTable");
        }
        public string Age { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int RemainingDays { get; private set; }
        public int NoOfVowels { get; private set; }
        public DataTable FourteenDaysDataTable { get; private set; }
        public void GetPersonDetails()
        {
            FirstName = _person.FirstName;
            NoOfVowels = (_person.FirstName + " " + _person.LastName).CountVowels();
            Age = _person.DateOfBirth.ToAgeString();
            RemainingDays = _person.DateOfBirth.ToDaysBeforeNextBirthday();
            LastName = _person.LastName;
            Get14DaysBeforeNextBirthday(_person.DateOfBirth);
        }
        private void Get14DaysBeforeNextBirthday(DateTime dateOfBirth)
        {
            FourteenDaysDataTable.Columns.Add(new DataColumn("Monday", typeof(string)));
            FourteenDaysDataTable.Columns.Add(new DataColumn("Tuesday", typeof(string)));
            FourteenDaysDataTable.Columns.Add(new DataColumn("Wednesday", typeof(string)));
            FourteenDaysDataTable.Columns.Add(new DataColumn("Thursday", typeof(string)));
            FourteenDaysDataTable.Columns.Add(new DataColumn("Friday", typeof(string)));
            FourteenDaysDataTable.Columns.Add(new DataColumn("Saturday", typeof(string)));
            FourteenDaysDataTable.Columns.Add(new DataColumn("Sunday", typeof(string)));

            DateTime today = DateTime.Today;
            DateTime next = new DateTime(today.Year, dateOfBirth.Month, dateOfBirth.Day);

            if (next < today)
                next = next.AddYears(1);

            int numDays = (next - today).Days ;

            var row = FourteenDaysDataTable.NewRow();

            var row1 = FourteenDaysDataTable.NewRow();

            var row2 = FourteenDaysDataTable.NewRow();

            int j = 0;

            /*
            Weeks starts from Monday - 0 1st row and 7 for 2nd row. This logic is followed for subsequent days. 
             */


            for (int i = 13; i >=0; i--)
            {
                var startDate = DateTime.Today.AddDays(numDays - i);

                switch (startDate.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        {
                            j = SetRowValues(row, row1, row2, j, startDate, DayOfWeek.Monday, 0, 7);
                            break;
                        }
                    case DayOfWeek.Tuesday:
                        {
                            j = SetRowValues(row, row1, row2, j, startDate, DayOfWeek.Tuesday, 1, 8);

                            break;
                        }
                    case DayOfWeek.Wednesday:
                        {
                            j = SetRowValues(row, row1, row2, j, startDate, DayOfWeek.Wednesday, 2, 9);
                            break;
                        }
                    case DayOfWeek.Thursday:
                        {
                            j = SetRowValues(row, row1, row2, j, startDate, DayOfWeek.Thursday, 3, 10);
                            break;
                        }
                    case DayOfWeek.Friday:
                        {
                            j = SetRowValues(row, row1, row2, j, startDate, DayOfWeek.Friday, 4, 11);
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            j = SetRowValues(row, row1, row2, j, startDate, DayOfWeek.Saturday, 5, 12);
                            break;
                        }
                    case DayOfWeek.Sunday:
                        {
                            j = SetRowValues(row, row1, row2, j, startDate, DayOfWeek.Sunday, 6, 13);
                            break;
                        }

                }
            }
            FourteenDaysDataTable.Rows.Add(row);
            FourteenDaysDataTable.Rows.Add(row1);
            if (IsValidRow(row2))
                FourteenDaysDataTable.Rows.Add(row2);
        }
        private static int SetRowValues(DataRow row, DataRow row1, DataRow row2, int j, DateTime x, DayOfWeek day, int firstrow, int secondrow)
        {
            if ((j == firstrow || j == 0))
            {
                row[day.ToString()] = GetRowValue(x);
                j = firstrow + 1;
            }
            else if (j == secondrow)
            {
                row1[day.ToString()] = GetRowValue(x);
                j = secondrow + 1; ;
            }
            else
                row2[day.ToString()] = GetRowValue(x);
            return j;
        }
        private static bool IsValidRow(DataRow row)
        {
            if (row.ItemArray.All(a => string.IsNullOrEmpty(Convert.ToString(a))))
                return false;

            return true;
        }
        private static string GetRowValue(DateTime x)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Month) + "-" + x.Day;
        }
    }
}