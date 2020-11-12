﻿using System;
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
    public class CreateModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        //later added.
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
            [Display(Name = "Degree")]
            public string DegreeID { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Intake")]
            public string IntakeID { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Faculty")]
            public string FacultyID { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Department")]
            public string DepartmentID { get; set; }

            public int UserRole { get; set; }

            //

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

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
            ViewData["DegreeID"] = new SelectList(_db.Set<Degree>(), "DegreeID", "DegreeName");
            ViewData["DepartmentID"] = new SelectList(_db.Set<Department>(), "DepartmentID", "DepartmentName");
            ViewData["IntakeID"] = new SelectList(_db.Set<Intake>(), "IntakeID", "IntakeNumber");
            ViewData["FacultyID"] = new SelectList(_db.Set<Faculty>(), "FacultyID", "FacultyName");
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
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
                    //UserRole = Input.UserRole,
                    IntakeID = Input.IntakeID,
                    FacultyID = Input.FacultyID,
                    DepartmentID = Input.DepartmentID,
                    DegreeID = Input.DegreeID,
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (Input.UserRole == 1)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.StudentEndUser));
                        await _userManager.AddToRoleAsync(user, SD.StudentEndUser);
                    }
                    else if (Input.UserRole == 2)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.HODEndUser));
                        await _userManager.AddToRoleAsync(user, SD.HODEndUser);
                    }
                    else if (Input.UserRole == 3)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.StaffEndUser));
                        await _userManager.AddToRoleAsync(user, SD.StaffEndUser);
                    }
                    else if (Input.UserRole == 4)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.AdminEndUser));
                        await _userManager.AddToRoleAsync(user, SD.AdminEndUser);
                    }

                    //create an Staff accounts as Admin.
                    // await _userManager.AddToRoleAsync(user, SD.StaffEndUser);
                    /*
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
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                    */
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Redirect("UserModels/Index");
        }
    }
}
