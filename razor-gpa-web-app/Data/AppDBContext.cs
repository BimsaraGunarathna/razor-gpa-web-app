using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<razor_gpa_web_app.Models.Year> Year { get; set; }

        public DbSet<razor_gpa_web_app.Models.Degree> Degree { get; set; }

        public DbSet<razor_gpa_web_app.Models.Department> Department { get; set; }

        public DbSet<razor_gpa_web_app.Models.GPA> GPA { get; set; }

        public DbSet<razor_gpa_web_app.Models.Grade> Grade { get; set; }

        public DbSet<razor_gpa_web_app.Models.Semester> Semester { get; set; }

        public DbSet<razor_gpa_web_app.Models.SGPA> SGPA { get; set; }

        public DbSet<razor_gpa_web_app.Models.SubjectModule> SubjectModule { get; set; }

        public DbSet<razor_gpa_web_app.Models.YGPA> YGPA { get; set; }
    }
}
