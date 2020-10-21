using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gpa_system.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public int FacultyID { get; set; }

        [DataType(DataType.Text)]
        public string HODID { get; set; }

        [Display(Name = "Department Name")]
        [DataType(DataType.Text)]
        public string DepartmentName { get; set; }
    }
}
