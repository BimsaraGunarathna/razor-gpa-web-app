using razor_gpa_web_app.Models;
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

        [Display(Name = "Subject module name")]
        [DataType(DataType.Text)]
        public string SubjectModuleName { get; set; }

        //
        public string DegreeID { get; set; }

        public Degree Degree { get; set; }

        public ICollection<GPA> GPAs { get; set; }
    }
}
