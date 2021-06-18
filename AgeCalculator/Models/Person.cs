using AgeCalculator.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeCalculator.Models
{
    public class Person : CheckDateRangeAttribute
    {
        [DisplayName("First name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("First name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Date of birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        [DataType(DataType.Date)]
        [Required]
        [CheckDateRange]
        public DateTime DateOfBirth { get; set; }
    }
}