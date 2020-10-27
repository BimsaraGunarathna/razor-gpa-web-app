using razor_gpa_web_app.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Paper
    {
        //Column
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PaperID { get; set; }

        [AllowNull]
        public Double GPAValue { get; set; }

        //Navigation
        public string SemesterID { get; set; }

        public string AcademicYearID { get; set; }

        public string DegreeID { get; set; }

        public string StudentID { get; set; }

        public string SubjectModuleID { get; set; }

        public string GradeID { get; set; }

        [ForeignKey("AcademicYearID")]
        public virtual AcademicYear AcademicYear { get; set; }

        [ForeignKey("GradeID")]
        public virtual Grade Grade { get; set; }

        [ForeignKey("SubjectModuleID")]
        public virtual SubjectModule SubjectModule { get; set; }

        [ForeignKey("StudentID")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("SemesterID")]
        public virtual Semester Semester { get; set; }

        [ForeignKey("DegreeID")]
        public virtual Degree Degree { get; set; }
    }
}
