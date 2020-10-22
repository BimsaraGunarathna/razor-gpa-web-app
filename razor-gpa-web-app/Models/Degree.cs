using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Degree
    {
        public string DegreeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Degree name")]
        [DataType(DataType.Text)]
        public string DegreeName { get; set; }

        [Required]
        [Display(Name = "Faculty name")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string FacultyName { get; set; }

        [Required]
        [Display(Name = "Degree code")]
        [DataType(DataType.Text)]
        [StringLength(10)]
        public string DegreeCode { get; set; }

        [Required]
        [Display(Name = "Duration of the degree")]
        public int NumOfYears { get; set; }

        //
        public string DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public Department Department { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
