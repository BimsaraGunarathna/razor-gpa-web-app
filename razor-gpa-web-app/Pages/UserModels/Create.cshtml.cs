using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;
using razor_gpa_web_app.Utility;

namespace razor_gpa_web_app.Pages.UserModels
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class CreateModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DBContext _db;

        public CreateModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            DBContext db
            )
        {
            //
            _db = db;
            _roleManager = roleManager;
            //
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            //Custom attribute definitions
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Registration number")]
            public string RegNum { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Degree name")]
            public string DegreeName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Intake")]
            public int Intake { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Faculty")]
            public string Faculty { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Department")]
            public string Department { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "User role")]
            public int UserRole { get; set; }
            //

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/UserModels");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //Adding custom attributes to the quene. 
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    RegNum = Input.RegNum,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    DegreeName = Input.DegreeName,
                    Intake = Input.Intake,
                    Faculty = Input.Faculty,
                    Department = Input.Department,
                    UserRole = Input.UserRole,
                };
                Console.WriteLine("Hi!");
                Console.WriteLine("Hi!");
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (user.UserRole == 1)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.StudentEndUser));
                        await _userManager.AddToRoleAsync(user, SD.StudentEndUser);
                    } 
                    else if (user.UserRole == 2) {
                        await _roleManager.CreateAsync(new IdentityRole(SD.HODEndUser));
                        await _userManager.AddToRoleAsync(user, SD.HODEndUser);
                    }
                    else if (user.UserRole == 3)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.StaffEndUser));
                        await _userManager.AddToRoleAsync(user, SD.StaffEndUser);
                    }
                    else if (user.UserRole == 4)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.AdminEndUser));
                        await _userManager.AddToRoleAsync(user, SD.AdminEndUser);
                    }

                        //create an Staff accounts as Admin.
                       // await _userManager.AddToRoleAsync(user, SD.StaffEndUser);

                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
