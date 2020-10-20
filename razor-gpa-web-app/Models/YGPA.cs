using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class YGPA
    {
        public int YGPAID { get; set; }
        public string StudentID { get; set; }
        public string SubjectModuleID { get; set; }

        [Display(Name = "Year GPA value")]
        [DataType(DataType.Text)]
        public string YGPAValue { get; set; }

        [Display(Name = "Year of the GPA")]
        [DataType(DataType.Text)]
        public string YGPAYear { get; set; }
    }
}
