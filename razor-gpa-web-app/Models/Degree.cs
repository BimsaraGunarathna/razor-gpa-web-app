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
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DegreeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Degree name")]
        [DataType(DataType.Text)]
        public string DegreeName { get; set; }

        [Required]
        [Display(Name = "Faculty name")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string FacultyName { get; set; }

        [Required]
        [Display(Name = "Degree code")]
        [DataType(DataType.Text)]
        [StringLength(10)]
        public string DegreeCode { get; set; }

        [Required]
        [Display(Name = "Duration of the degree(in years)")]
        //[RegularExpression("([0-7]+)")]
        [Range(0, 5)]
        public int NumOfYears { get; set; }

        //
        public string DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        public ICollection<Grade> Grades { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
