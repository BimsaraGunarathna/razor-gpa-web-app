

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using razor_gpa_web_app.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace razor_gpa_web_app.Pages.Degrees
{
    public class DepartmentNamePageModel : PageModel
    {
        public SelectList DepartmentNameSL { get; set; }

        public void PopulateDepartmentsDropDownList(DBContext _context,
            object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Department
                                   orderby d.DepartmentName // Sort by name.
                                   select d;

            DepartmentNameSL = new SelectList(departmentsQuery.AsNoTracking(),
                        "DepartmentID", "DepartmentName", selectedDepartment);
        }
    }
}