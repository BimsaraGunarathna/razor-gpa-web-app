using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.UserModels
{
    public class DeleteModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<DeleteModel> _logger;
        //private ApplicationUser _userX;

        public DeleteModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<DeleteModel> logger
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            public string id { get; set;  }
        }
        
        public bool RequirePassword { get; set; }

        [BindProperty]
        public string AppUserId { get; set; }
        //public ApplicationUser ApplicationUser1 { get; set; }
        
        public async Task<IActionResult> OnGet(string id)
        {
            
            //var user = await _userManager.GetUserAsync(User);
            var user = await _userManager.Users.FirstOrDefaultAsync(m => m.Id == id);
            //var user = await _userManager.GetUserAsync(User);
            //userX = user; 
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            AppUserId = user.Id;

            //var userId = await _userManager.GetUserIdAsync(user);


            RequirePassword = await _userManager.HasPasswordAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //var user = await _userManager.GetUserAsync(AppUser);
            var user = await _userManager.Users.FirstOrDefaultAsync(m => m.Id == AppUserId);
            //var user = await _userManager.FindByIdAsync(userid);
            //var user = await _userManager.Users.FirstOrDefaultAsync(m => m.Id == userid);
            //user = userX;

            //var user = await _userManager.FindByIdAsync(_userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID in OnPost '{_userManager.GetUserId(User)}'.");
                
            }

            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{userId}'.");
            }

            //await _signInManager.SignOutAsync();

            _logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

            return Redirect("~/UserModels");
        }
    }
}
