using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gpa_system.Models
{
    public class SGPA
    {
        public int SGPAId { get; set; }

        public string StudentID { get; set; }

        public string SubjectModuleID { get; set; }

        [Display(Name = "Semester GPA value")]
        [DataType(DataType.Text)]
        public string SGPAValue { get; set; }

        [Display(Name = "Semester of the SGPA")]
        [DataType(DataType.Text)]
        public string SemesterNo { get; set; }
    }
}
