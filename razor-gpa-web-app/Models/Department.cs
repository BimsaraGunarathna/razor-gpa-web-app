using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gpa_system.Models
{
    public class Department
    {
        public string DepartmentID { get; set; }

        [Display(Name = "Department Name")]
        [DataType(DataType.Text)]
        public string DepartmentName { get; set; }

        [Display(Name = "Faculty name")]
        [DataType(DataType.Text)]
        public string FacultyName { get; set; }

        //
        public ICollection<Degree> Degrees { get; set; }

    }
}
