using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class YGPA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string YGPAID { get; set; }

        [Required]
        [Display(Name = "Year GPA value")]
        [DataType(DataType.Text)]
        public string YGPAValue { get; set; }

        //
        public string StudentID { get; set; }
        public string SubjectModuleID { get; set; }
        public Year Year { get; set; }

    }
}
