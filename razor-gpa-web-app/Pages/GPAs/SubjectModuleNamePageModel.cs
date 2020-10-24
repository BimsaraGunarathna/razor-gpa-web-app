

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using razor_gpa_web_app.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace razor_gpa_web_app.Pages.GPAs
{
    public class SubjectModuleNamePageModel : PageModel
    {
        public SelectList SubjectModuleNameSL { get; set; }

        public void PopulateSubjectModuleDropDownList(DBContext _context,
            object selectedSubjectModule = null)
        {
            var subjectModuleQuery = from d in _context.SubjectModule
                                   orderby d.SubjectModuleName // Sort by name.
                                   select d;

            SubjectModuleNameSL = new SelectList(subjectModuleQuery.AsNoTracking(),
                        "SubjectModuleID", "SubjectModuleName", selectedSubjectModule);
        }
    }
}