using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razor_gpa_web_app.Models
{
    public enum GradeChar
    {
        Aplus, A, Aminus, Bplus, B, Bminus, Cplus, C, Cminus, Dplus, Ie, Ia, Ib, Ne, Ab
    }

    public class Grade
    {
        public string GradeID { get; set; }

        [Required]
        [StringLength(2)]
        [DisplayFormat(NullDisplayText = "No grade")]
        public GradeChar? GradeChar { get; set; }


        //
        public string SemesterID { get; set; }

        public string GPAID { get; set; }

        public string DegreeID { get; set; }

        public string StudentID { get; set; }

        public GPA GPA { get; set; }

        public Semester Semester { get; set; }

        public Degree Degree { get; set; }
    }
}
