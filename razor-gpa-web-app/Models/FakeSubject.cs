using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Models
{
    public class FakeSubject
    {
        [Display(Name = "Subject name")]
        public string SubjectName { get; set; }

        [Display(Name = "Subject grade")]
        public string SubjectGrade { get; set; }
    }
}
