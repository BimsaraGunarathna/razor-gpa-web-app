using razor_gpa_web_app.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Department
    {
        //Colmuns
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Department name")]
        [DataType(DataType.Text)]
        public string DepartmentName { get; set; }



        //Navigation
        public string FacultyID { get; set; }

        [ForeignKey("FacultyID")]
        public virtual Faculty Faculty { get; set; }

        public ICollection<Degree> Degrees { get; set; }
        
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
