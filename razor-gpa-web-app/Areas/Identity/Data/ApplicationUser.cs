using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string RegNum { get; set; }

        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }
        
        [PersonalData]
        public string DegreeName { get; set; }

        [PersonalData]
        public int IntakeNumber { get; set; }

        [PersonalData]
        public string FacultyName { get; set; }

        [PersonalData]
        public string DepartmentName { get; set; }

        public int UserRole { get; set;  }

        //
        public  ICollection<Grade> Grades { get; set; }
        public  ICollection<GPA> GPAs { get; set; }
        public  ICollection<SGPA> SGPAs { get; set; }

        [PersonalData]
        [AllowNull]
        public string DegreeID { get; set; }

        [PersonalData]
        public string DepartmentID { get; set; }

        [ForeignKey("DegreeID")]
        public Degree Degree { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        //
    }
}
