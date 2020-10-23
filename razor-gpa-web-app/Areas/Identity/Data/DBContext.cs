using razor_gpa_web_app.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Data
{
    public class DBContext: IdentityDbContext<ApplicationUser>
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many Grades.
                b.HasMany(e => e.Grades)
                    .WithOne()
                    .HasForeignKey(uc => uc.StudentID)
                    .IsRequired();

                // Each User can have many GPAs.
                b.HasMany(e => e.GPAs)
                    .WithOne()
                    .HasForeignKey(ul => ul.StudentID)
                    .IsRequired();

                // Each User can have many Students.
                b.HasMany(e => e.SGPAs)
                    .WithOne()
                    .HasForeignKey(ut => ut.StudentID)
                    .IsRequired();

            });
        }
        */
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Year> Year { get; set; }

        public DbSet<Degree> Degree { get; set; }

        public DbSet<Semester> Semester { get; set; }

        public DbSet<Grade> Grade { get; set; }

        public DbSet<SGPA> SGPA { get; set; }

        public DbSet<SubjectModule> SubjectModule { get; set; }

        public DbSet<GPA> GPA { get; set; }

    }
}
