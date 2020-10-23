using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using razor_gpa_web_app.Areas.Identity.Data;

namespace razor_gpa_web_app.Models
{

    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string GradeID { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayFormat(NullDisplayText = "No grade")]
        public int GradeChar { get; set; }


        //
        public string SemesterID { get; set; }

        public string GPAID { get; set; }

        public string DegreeID { get; set; }

        public string StudentID { get; set; }

        public string SubjectModuleID { get; set; }

        [ForeignKey("SubjectModuleID")]
        public SubjectModule SubjectModule { get; set; }

        [ForeignKey("GPAID")]
        public GPA GPA { get; set; }

        [ForeignKey("StudentID")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("SemesterID")]
        public Semester Semester { get; set; }

        [ForeignKey("DegreeID")]
        public Degree Degree { get; set; }
    }
}
