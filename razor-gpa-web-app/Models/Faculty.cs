using razor_gpa_web_app.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Faculty
    {
        //Column
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string FacultyID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Faculty")]
        public string FacultyName { get; set; }


        //Navigation
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
