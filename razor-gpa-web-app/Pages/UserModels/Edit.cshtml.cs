using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

using Microsoft.AspNetCore.Authorization;


namespace razor_gpa_web_app.Pages.UserModels
{
    public class EditModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public EditModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id.Trim().Length == 0)
            {
                return NotFound();
            }

            ApplicationUser = await _context.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var userInDb = await _context.ApplicationUser.SingleOrDefaultAsync(u => u.Id == ApplicationUser.Id);
                if (userInDb == null)
                {
                    return NotFound();
                }
                else
                {
                    userInDb.Email = ApplicationUser.Email;
                    userInDb.FirstName = ApplicationUser.FirstName;
                    userInDb.LastName = ApplicationUser.LastName;
                    //userInDb.IntakeNumber = ApplicationUser.IntakeNumber;
                    userInDb.DegreeID = ApplicationUser.DegreeID;
                    userInDb.DepartmentID = ApplicationUser.DepartmentID;

                    await _context.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
            }
        }
    }
}
