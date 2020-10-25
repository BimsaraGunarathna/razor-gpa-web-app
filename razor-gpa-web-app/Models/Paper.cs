﻿using razor_gpa_web_app.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class Paper
    {
        //Column
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PaperID { get; set; }

        //Navigation
        public string SemesterID { get; set; }

        [AllowNull]
        public string GPAID { get; set; }

        public string DegreeID { get; set; }

        public string StudentID { get; set; }

        public string SubjectModuleID { get; set; }

        public string GradeID { get; set; }

        [ForeignKey("GradeID")]
        public Grade Grade { get; set; }

        [ForeignKey("SubjectModuleID")]
        public SubjectModule SubjectModule { get; set; }

        [ForeignKey("GPAID")]
        public GPA GPA { get; set; }

        [ForeignKey("StudentID")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("SemesterID")]
        public Semester Semester { get; set; }

        [ForeignKey("DegreeID")]
        public Degree Degree { get; set; }
    }
}
