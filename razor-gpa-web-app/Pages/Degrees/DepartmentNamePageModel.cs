using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;

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
