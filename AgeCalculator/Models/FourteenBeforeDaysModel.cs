using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeCalculator.Models
{
    public class FourteenBeforeDaysModel
    {
        public string Month { get; set; }

        public int Date { get; set; }

        public string Day { get; set; }
    }

    public class Days
    {
        public Days()
        {
            Mon = new List<FourteenBeforeDaysModel>();
            Tue = new List<FourteenBeforeDaysModel>();
            Wed = new List<FourteenBeforeDaysModel>();
            Thurs = new List<FourteenBeforeDaysModel>();
            Fri = new List<FourteenBeforeDaysModel>();
            Sat = new List<FourteenBeforeDaysModel>();
            Sun = new List<FourteenBeforeDaysModel>();
        }

        public List<FourteenBeforeDaysModel> Mon { get; set; }

        public List<FourteenBeforeDaysModel> Tue { get; set; }

        public List<FourteenBeforeDaysModel> Wed { get; set; }

        public List<FourteenBeforeDaysModel> Thurs { get; set; }

        public List<FourteenBeforeDaysModel> Fri { get; set; }
        public List<FourteenBeforeDaysModel> Sat { get; set; }
        public List<FourteenBeforeDaysModel> Sun { get; set; }

    }

}