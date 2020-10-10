using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

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
        public int Intake { get; set; }

        [PersonalData]
        public string Faculty { get; set; }

        [PersonalData]
        public string Department { get; set; }



    }
}
