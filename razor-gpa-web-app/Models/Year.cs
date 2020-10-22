using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Year
    {
        public string YearID { get; set; }

        [Required]
        [Display(Name = "Year")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime YearNumber { get; set; }

        //
        public ICollection<Semester> Semesters { get; set; }
        public ICollection<SGPA> SGPAs { get; set; }
        public ICollection<GPA> GPAs { get; set; }
    }
}
