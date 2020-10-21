using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gpa_system.Models
{
    public class SubjectModule
    {
        public string SubjectModuleID { get; set; }
        public string DegreeID { get; set; }
        public string DepartmentID { get; set; }

        [Display(Name = "Name of the subject module")]
        [DataType(DataType.Text)]
        public string SubjectModuleName { get; set; }
    }
}
