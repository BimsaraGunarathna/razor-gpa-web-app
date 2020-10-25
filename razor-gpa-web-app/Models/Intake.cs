using razor_gpa_web_app.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Intake
    {
        //Columns
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IntakeID { get; set; }

        [Required]
        [Display(Name = "Intake")]
        public int IntakeNumber { get; set; }

        //Navigation
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
