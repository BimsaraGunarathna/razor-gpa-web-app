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

namespace razor_gpa_web_app.Pages.UserModels
{
    public class DetailsModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public DetailsModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        public ApplicationUser UserModel { get; set; }

        public async Task<IActionResult> OnGetAsync(String id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserModel = await _context.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);

            if (UserModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
