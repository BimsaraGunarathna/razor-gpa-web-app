﻿using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Semester
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SemesterID { get; set; }

        [Required]
        [Display(Name = "Semester number")]
        [DataType(DataType.Text)]
        [RegularExpression("([0-9]+)")]
        public int SemesterNumber { get; set; }

        //
        public string YearID { get; set; }

        [ForeignKey("YearID")]
        public Year Year { get; set; }

        public ICollection<GPA> GPAs { get; set; }

        public ICollection<SGPA> SGPAs { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
