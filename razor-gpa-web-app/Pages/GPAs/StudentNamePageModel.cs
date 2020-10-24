

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using razor_gpa_web_app.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace razor_gpa_web_app.Pages.GPAs
{
    public class StudentNamePageModel : PageModel
    {
        public SelectList StudentNameSL { get; set; }

        public void PopulateStudentDropDownList(DBContext _context,
            object selectedStudent = null)
        {
            var studentsQuery = from d in _context.ApplicationUser
                                   orderby d.RegNum // Sort by name.
                                   select d;

            StudentNameSL = new SelectList(studentsQuery.AsNoTracking(),
                        "StudentID", "StudentName", selectedStudent);
        }
    }
}