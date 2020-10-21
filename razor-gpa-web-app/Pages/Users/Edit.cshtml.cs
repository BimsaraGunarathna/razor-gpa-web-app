using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;
using razor_gpa_web_app.Utility;

namespace SparkAuto.Pages.Users
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class EditModel : PageModel
    {
        private readonly DBContext _db;

        public EditModel(DBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id.Trim().Length == 0)
            {
                return NotFound();
            }

            ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);

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
                var userInDb = await _db.ApplicationUser.SingleOrDefaultAsync(u => u.Id == ApplicationUser.Id);
                if (userInDb == null)
                {
                    return NotFound();
                }
                else
                {
                    userInDb.FirstName = ApplicationUser.FirstName;
                    userInDb.PhoneNumber = ApplicationUser.PhoneNumber;
                    //userInDb.Address = ApplicationUser.Address;
                    //userInDb.City = ApplicationUser.City;
                    //userInDb.PostalCode = ApplicationUser.PostalCode;
                    userInDb.LastName = ApplicationUser.LastName;
                    userInDb.RegNum = ApplicationUser.RegNum;
                    userInDb.Email = ApplicationUser.Email;

                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
            }
        }


    }
}
