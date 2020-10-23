using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class GPA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string GPAID { get; set; }

        [Required]
        [Display(Name = "GPA value")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public Double GPAValue { get; set; }

        //
        
        public string StudentID { get; set; }

        public string SemesterID { get; set; }

        public string SubjectModuleID { get; set; }

        public string YearID { get; set; }

        [ForeignKey("YearID")]
        public Year Year { get; set; }

        [ForeignKey("SemesterID")]
        public Semester Semester { get; set; }

        [ForeignKey("SubjectModuleID")]
        public SubjectModule SubjectModule { get; set; }

        //[ForeignKey("StudentID")]
        //public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("StudentID")]
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Grade> Grades { get; set; }


    }
}
