

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using razor_gpa_web_app.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace razor_gpa_web_app.Pages.GPAs
{
    public class SemesterNamePageModel : PageModel
    {
        public SelectList SemesterNameSL { get; set; }

        public void PopulateSemesterDropDownList(DBContext _context,
            object selectedSemester = null)
        {
            var semesterQuery = from d in _context.Semester
                                   orderby d.SemesterNumber // Sort by name.
                                   select d;

            SemesterNameSL = new SelectList(semesterQuery.AsNoTracking(),
                        "SemesterID", "SemesterNumber", selectedSemester);
        }
    }
}