using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class FakeSGPA
    {
        public string RegNum { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //
        public double SGPAValueForYearOne { get; set; }
        public double SGPAValueForYearTwo { get; set; }
        public double SGPAValueForYearThree { get; set; }
        public double SGPAValueForYearFour { get; set; }
        public double SGPAValueForYearFive { get; set; }


        //
        public double SGPAValueForSemOne { get; set; }

        public double SGPAValueForSemTwo { get; set; }

        public double SGPAValueForSemThree { get; set; }

        public double SGPAValueForSemFour { get; set; }

        public double SGPAValueForSemFive { get; set; }

        public double SGPAValueForSemSix { get; set; }

        public double SGPAValueForSemSeven { get; set; }

        public double SGPAValueForSemEight { get; set; }

        public double SGPAValueForSemNine { get; set; }

        public double SGPAValueForSemTen { get; set; }
    }
}
