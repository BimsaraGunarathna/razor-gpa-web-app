﻿using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class SubjectModule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SubjectModuleID { get; set; }

        [Display(Name = "Subject module name")]
        [DataType(DataType.Text)]
        [Required]
        [StringLength(60)]
        public string SubjectModuleName { get; set; }

        [Display(Name = "Subject module code")]
        [DataType(DataType.Text)]
        [Required]
        [StringLength(60)]
        public string SubjectModuleCode { get; set; }

        //
        public string DegreeID { get; set; }

        [ForeignKey("DegreeID")]
        public Degree Degree { get; set; }

        public ICollection<GPA> GPAs { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
