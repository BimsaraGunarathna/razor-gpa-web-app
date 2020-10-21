using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gpa_system.Models
{
    public class SGPA
    {
        public string SGPAID { get; set; }

        [Display(Name = "SGPA value")]
        [DataType(DataType.Text)]
        public string SGPAValue { get; set; }

        //
        public string YearID { get; set; }

        public string StudentID { get; set; }

        public string SemesterID { get; set; }

        public Year Year { get; set; }

        public Semester Semester { get; set; }
    }
}
