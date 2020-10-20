using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Degree
    {
        public int DegreeID { get; set; }
        public int DepartmentID { get; set; }

        [Required]
        [Display(Name = "Degree Name")]
        [DataType(DataType.Text)]
        public string DegreeName { get; set; }

        [Required]
        [Display(Name = "Degree Code")]
        [DataType(DataType.Text)]
        public string DegreeCode { get; set; }

        [Required]
        [Display(Name = "Duration of the Degree program")]
        public int NumOfYears { get; set; }
    }
}
