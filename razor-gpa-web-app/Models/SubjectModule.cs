using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class SubjectModule
    {
        public string SubjectModuleID { get; set; }

        [Display(Name = "Subject module name")]
        [DataType(DataType.Text)]
        [Required]
        [StringLength(60)]
        public string SubjectModuleName { get; set; }

        //
        public string DegreeID { get; set; }

        public Degree Degree { get; set; }

        public ICollection<GPA> GPAs { get; set; }
    }
}
