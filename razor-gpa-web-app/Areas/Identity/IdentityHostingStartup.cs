using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;

[assembly: HostingStartup(typeof(razor_gpa_web_app.Areas.Identity.IdentityHostingStartup))]
namespace razor_gpa_web_app.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                
                services.AddDbContext<DBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DBContextConnection")));
                
                //known Issue: Application user is replaced with Identity User. ApplicationUser is a derived by extending IdentityUser 
                //services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<DBContext>();
                //.AddDefaultTokenProviders() is removed.
                services
                    .AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<DBContext>()
                    //Known issue: Added to fix error in register page.
                    .AddDefaultTokenProviders()
                    //Known issue: fixed by adding AddDefualtUI()
                    .AddDefaultUI();
                //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DBContext>();
            });
        }
    }
}