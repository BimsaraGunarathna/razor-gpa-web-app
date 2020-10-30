using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class FakeSGPA
    {
        [Display(Name = "Registration No")]
        public string RegNum { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        //FGPA
        [Display(Name = "FGPA")]
        public double FGPAValue { get; set; }

        //YGPA
        [Display(Name = "YGPA 1")]
        public double YGPAValueForYearOne { get; set; }

        [Display(Name = "YGPA 2")]
        public double YGPAValueForYearTwo { get; set; }

        [Display(Name = "YGPA 3")]
        public double YGPAValueForYearThree { get; set; }

        [Display(Name = "YGPA 4")]
        public double YGPAValueForYearFour { get; set; }

        [Display(Name = "YGPA 5")]
        public double YGPAValueForYearFive { get; set; }


        //
        [Display(Name = "SGPA 1")]
        public double SGPAValueForSemOne { get; set; }

        [Display(Name = "SGPA 2")]
        public double SGPAValueForSemTwo { get; set; }

        [Display(Name = "SGPA 3")]
        public double SGPAValueForSemThree { get; set; }

        [Display(Name = "SGPA 4")]
        public double SGPAValueForSemFour { get; set; }

        [Display(Name = "SGPA 5")]
        public double SGPAValueForSemFive { get; set; }

        [Display(Name = "SGPA 6")]
        public double SGPAValueForSemSix { get; set; }

        [Display(Name = "SGPA 7")]
        public double SGPAValueForSemSeven { get; set; }

        [Display(Name = "SGPA 8")]
        public double SGPAValueForSemEight { get; set; }

        [Display(Name = "SGPA 9")]
        public double SGPAValueForSemNine { get; set; }

        [Display(Name = "SGPA 10")]
        public double SGPAValueForSemTen { get; set; }
    }
}
