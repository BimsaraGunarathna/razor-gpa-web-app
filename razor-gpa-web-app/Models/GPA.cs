using gpa_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class GPA
    {
        public string GPAID { get; set; }

        [Display(Name = "GPA value")]
        [DataType(DataType.Text)]
        public Double GPAValue { get; set; }

        //
        public string StudentID { get; set; }

        public string SemesterID { get; set; }

        public string SubjectModuleID { get; set; }

        public string YearID { get; set; }

        public Year Year { get; set; }

        public Semester Semester { get; set; }

        public SubjectModule SubjectModule { get; set; }

        public ICollection<Grade> Grades { get; set; }

    }
}
