using razor_gpa_web_app.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace razor_gpa_web_app.Data
{
    public class DBContext: IdentityDbContext<ApplicationUser>
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<gpa_system.Models.Department> Department { get; set; }

        public DbSet<razor_gpa_web_app.Models.Year> Year { get; set; }

        public DbSet<razor_gpa_web_app.Models.Degree> Degree { get; set; }

        public DbSet<razor_gpa_web_app.Models.Semester> Semester { get; set; }

        public DbSet<razor_gpa_web_app.Models.Grade> Grade { get; set; }

        public DbSet<gpa_system.Models.SGPA> SGPA { get; set; }

        public DbSet<gpa_system.Models.SubjectModule> SubjectModule { get; set; }

        public DbSet<razor_gpa_web_app.Models.GPA> GPA { get; set; }

    }
}
