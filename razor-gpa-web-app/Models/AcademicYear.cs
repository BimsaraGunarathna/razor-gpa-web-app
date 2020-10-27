using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class AcademicYear
    {
        //Colums
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AcademicYearID { get; set; }

        [Required]
        [Display(Name = "Academic start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        //StartDate.Year
        
        //Navigation
        public ICollection<SGPA> SGPAs { get; set; }
        public ICollection<YGPA> YGPAs { get; set; }
        public ICollection<Paper> Papers { get; set; }

    }
}
