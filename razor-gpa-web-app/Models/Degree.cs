using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Degree
    {
        //Columns
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DegreeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Degree name")]
        [DataType(DataType.Text)]
        public string DegreeName { get; set; }

        [Required]
        [Display(Name = "Degree code")]
        [DataType(DataType.Text)]
        [StringLength(10)]
        public string DegreeCode { get; set; }

        [Required]
        [Display(Name = "Duration of the degree(in years)")]
        //[RegularExpression("([0-7]+)")]
        [Range(0, 7)]
        public int NumOfYears { get; set; }


        //Navigation Properties
        public string DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        public ICollection<Paper> Papers { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public ICollection<SubjectModule> SubjectModules { get; set; }
    }
}
