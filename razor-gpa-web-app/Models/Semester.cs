using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Semester
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SemesterID { get; set; }

        [Required]
        [Display(Name = "Semester number")]
        public int SemesterNumber { get; set; }

        [Required]
        [Display(Name = "Semester name")]
        [DataType(DataType.Text)]
        public string SemesterName { get; set; }

        //

        public ICollection<Paper> Papers { get; set; }

        public ICollection<SGPA> SGPAs { get; set; }

        public ICollection<Grade> Grades { get; set; }

        //public ICollection<SubjectModule> SubjectModules { get; set; }
    }
}
