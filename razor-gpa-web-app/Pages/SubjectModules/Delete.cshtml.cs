using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.SubjectModules
{
    public class DeleteModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.AppDBContext _context;

        public DeleteModel(razor_gpa_web_app.Data.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubjectModule SubjectModule { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubjectModule = await _context.SubjectModule
                .Include(s => s.Degree).FirstOrDefaultAsync(m => m.SubjectModuleID == id);

            if (SubjectModule == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubjectModule = await _context.SubjectModule.FindAsync(id);

            if (SubjectModule != null)
            {
                _context.SubjectModule.Remove(SubjectModule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
