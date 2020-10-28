using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using razor_gpa_web_app.Areas.Identity.Data;

namespace razor_gpa_web_app.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            ILogger<IndexModel> logger, 
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager
            )
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public int UserRole { get; set; }

        public async void OnGet()
        {
            //get the user id
            //UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //Get the user
            //var AppUser = await _userManager.GetUserAsync(User);
            //UserRole = AppUser.UserRole;
        }
    }
}
