using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using razor_gpa_web_app.Areas.Identity.Data;

namespace razor_gpa_web_app.Models
{
    
    public class Grade
    {
        //Column
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string GradeID { get; set; }

        [Required]
        [Display(Name = "Grade title")]
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string GradeName { get; set; }

        [Required]
        [Display(Name = "Grade marks")]
        [StringLength(25)]
        [DataType(DataType.Text)]
        public string FinalMarks { get; set; }

        [Required]
        [Display(Name = "Credit value")]
        [StringLength(10)]
        [DataType(DataType.Text)]
        public Double CreditValue { get; set; }

        public ICollection<Paper> Papers { get; set; }
    }
}
