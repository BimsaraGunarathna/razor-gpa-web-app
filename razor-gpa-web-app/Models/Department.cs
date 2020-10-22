using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Department
    {
        public string DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Department name")]
        [DataType(DataType.Text)]
        public string DepartmentName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Faculty name")]
        [DataType(DataType.Text)]
        public string FacultyName { get; set; }

        //
        public ICollection<Degree> Degrees { get; set; }
    }
}
