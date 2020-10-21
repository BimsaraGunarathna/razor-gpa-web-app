using gpa_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Semester
    {
        public string SemesterID { get; set; }

        [Display(Name = "Semester number")]
        [DataType(DataType.Text)]
        public int SemesterNumber { get; set; }

        //
        public int YearID { get; set; }

        public Year Year { get; set; }

        public ICollection<GPA> GPAs { get; set; }

        public ICollection<SGPA> SGPAs { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
