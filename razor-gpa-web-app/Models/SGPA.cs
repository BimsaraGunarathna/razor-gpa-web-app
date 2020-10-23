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
    public class SGPA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SGPAID { get; set; }

        [Display(Name = "SGPA value")]
        [DataType(DataType.Text)]
        public Double SGPAValue { get; set; }

        //
        public string YearID { get; set; }

        public string StudentID { get; set; }

        public string SemesterID { get; set; }

        [ForeignKey("StudentID")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("YearID")]
        public Year Year { get; set; }

        [ForeignKey("SemesterID")]
        public Semester Semester { get; set; }
    }
}
