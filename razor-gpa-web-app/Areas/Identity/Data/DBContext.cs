using razor_gpa_web_app.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Models;
using Microsoft.AspNetCore.Identity;
using razor_gpa_web_app.Utility;

namespace razor_gpa_web_app.Data
{
    public class DBContext: IdentityDbContext<ApplicationUser>
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Academic Year
            builder.Entity<AcademicYear>().HasData(
                
                new AcademicYear { AcademicYearID = "myud", StartDate = DateTime.Parse("2024-01-01") },
                new AcademicYear { AcademicYearID = "myrfwfud", StartDate = DateTime.Parse("2023-01-01") },
                new AcademicYear { AcademicYearID = "eveefweveum", StartDate = DateTime.Parse("2022-01-01") },
                new AcademicYear { AcademicYearID = "3d3emucdf", StartDate = DateTime.Parse("2021-01-01") },
                new AcademicYear { AcademicYearID = "ecj235332", StartDate = DateTime.Parse("2020-01-01") },
                new AcademicYear { AcademicYearID = "3rcd535c", StartDate = DateTime.Parse("2019-01-01") },
                new AcademicYear { AcademicYearID = "ec3fej232", StartDate = DateTime.Parse("2018-01-01") },
                new AcademicYear { AcademicYearID = "veve353vv", StartDate = DateTime.Parse("2017-01-01") },
                new AcademicYear { AcademicYearID = "3ffv35efe33", StartDate = DateTime.Parse("2016-01-01") },
                new AcademicYear { AcademicYearID = "3dvevfve3ecdf", StartDate = DateTime.Parse("2015-01-01") },
                new AcademicYear { AcademicYearID = "3fee33fe33", StartDate = DateTime.Parse("2014-01-01") },
                new AcademicYear { AcademicYearID = "3d3vevecdf", StartDate = DateTime.Parse("2013-01-01") },
                new AcademicYear { AcademicYearID = "3fevwefw34fe33", StartDate = DateTime.Parse("2012-01-01") }

            );

            //Semester
            var sem01 = new Semester { SemesterID = "kjei3322", AcademicYearID = "myud", SemesterNumber = 1, SemesterName = "Semester 01" };
            var sem02 = new Semester { SemesterID = "d33", AcademicYearID = "myrfwfud", SemesterNumber = 1, SemesterName = "Semester 01" }          ;
            var sem03 = new Semester { SemesterID = "f3f3rfr", AcademicYearID = "eveefweveum", SemesterNumber = 1, SemesterName = "Semester 01" }   ;
            var sem04 = new Semester { SemesterID = "j4n343", AcademicYearID = "3d3emucdf", SemesterNumber = 1, SemesterName = "Semester 01" }      ;
            var sem05 = new Semester { SemesterID = "hjh4334432", AcademicYearID = "ecj235332", SemesterNumber = 1, SemesterName = "Semester 01" }  ;
            var sem06 = new Semester { SemesterID = "b32briu45", AcademicYearID = "3rcd535c", SemesterNumber = 1, SemesterName = "Semester 01" }  ;
            var sem07 = new Semester { SemesterID = "b3i24iu42", AcademicYearID = "ec3fej232", SemesterNumber = 1, SemesterName = "Semester 01" } ;
            var sem08 = new Semester { SemesterID = "54b64", AcademicYearID = "veve353vv", SemesterNumber = 1, SemesterName = "Semester 01" }       ;
            var sem09 = new Semester { SemesterID = "5bhi23", AcademicYearID = "3ffv35efe33", SemesterNumber = 1, SemesterName = "Semester 01" }    ;
            var sem10 = new Semester { SemesterID = "j4kb52", AcademicYearID = "3dvevfve3ecdf", SemesterNumber = 1, SemesterName = "Semester 01" }  ;
            var sem11 = new Semester { SemesterID = "2b34jkbh", AcademicYearID = "3fee33fe33", SemesterNumber = 1, SemesterName = "Semester 01" }   ;
            var sem12 = new Semester { SemesterID = "hb4325kb", AcademicYearID = "3d3vevecdf", SemesterNumber = 1, SemesterName = "Semester 01" }   ;
            var sem13 = new Semester { SemesterID = "h2b45j", AcademicYearID = "3fevwefw34fe33", SemesterNumber = 1, SemesterName = "Semester 01" } ;
                                                                                                                                         
            var sem14 = new Semester { SemesterID = "34fr4", AcademicYearID = "myud", SemesterNumber = 2, SemesterName = "Semester 02" }            ;
            var sem15 = new Semester { SemesterID = "h2b4f4f4fw5j", AcademicYearID = "myrfwfud", SemesterNumber = 2, SemesterName = "Semester 02" } ;
            var sem16 = new Semester { SemesterID = "43ff34cr", AcademicYearID = "eveefweveum", SemesterNumber = 2, SemesterName = "Semester 02" }  ;
            var sem17 = new Semester { SemesterID = "fw43", AcademicYearID = "3d3emucdf", SemesterNumber = 2, SemesterName = "Semester 02" }      ;
            var sem18 = new Semester { SemesterID = "h2bcf34f45j", AcademicYearID = "ecj235332", SemesterNumber = 2, SemesterName = "Semester 02" } ;
            var sem19 = new Semester { SemesterID = "h2b54gb45j", AcademicYearID = "3rcd535c", SemesterNumber = 2, SemesterName = "Semester 02" }   ;
            var sem20 = new Semester { SemesterID = "5egz", AcademicYearID = "ec3fej232", SemesterNumber = 2, SemesterName = "Semester 02" }        ;
            var sem21 = new Semester { SemesterID = "h2bg5e45j", AcademicYearID = "veve353vv", SemesterNumber = 2, SemesterName = "Semester 02" }   ;
            var sem22 = new Semester { SemesterID = "drz5", AcademicYearID = "3ffv35efe33", SemesterNumber = 2, SemesterName = "Semester 02" }      ;
            var sem23 = new Semester { SemesterID = "tre5554", AcademicYearID = "3dvevfve3ecdf", SemesterNumber = 2, SemesterName = "Semester 02" } ;
            var sem24 = new Semester { SemesterID = "54hfrth", AcademicYearID = "3fee33fe33", SemesterNumber = 2, SemesterName = "Semester 02" }    ;
            var sem25 = new Semester { SemesterID = "54yh6ht", AcademicYearID = "3d3vevecdf", SemesterNumber = 2, SemesterName = "Semester 02" }    ;
            var sem026 = new Semester { SemesterID = "54y54gh", AcademicYearID = "3fevwefw34fe33", SemesterNumber = 2, SemesterName = "Semester 02" };

            builder.Entity<Semester>().HasData(
                sem01 , sem02 ,sem03 ,sem04 ,sem05 ,sem06 ,sem07 ,sem08 ,sem09 ,sem10 ,sem11 ,sem12 , sem13 ,sem14 ,sem15 , sem16 ,sem17 ,sem18 ,sem19 ,sem20 ,sem21 ,sem22 ,sem23 ,sem24 ,sem25 ,sem026
            );

            //Faculty
            builder.Entity<Faculty>().HasData(
                new Faculty { FacultyID = "2d3d", FacultyName = "Defence Studies and Strategic Studies" },
                new Faculty { FacultyID = "343d3rdf", FacultyName = "Graduate Studies" },
                new Faculty { FacultyID = "432rf2", FacultyName = "Engineerings" },
                new Faculty { FacultyID = "423f2", FacultyName = "Law " },
                new Faculty { FacultyID = "34f", FacultyName = "Medicine" },
                new Faculty { FacultyID = "kddef43f3di3322", FacultyName = "Research and Development" },
                new Faculty { FacultyID = "23df2", FacultyName = "Computing" },
                new Faculty { FacultyID = "42f4f34", FacultyName = "Built Environment and Spatial Sciences " }

            );

            //Intake
            var intake1 = new Intake { IntakeID = "wde3", IntakeNumber = 40 };
            var intake2 = new Intake { IntakeID = "hjv32b", IntakeNumber = 39 };
            var intake3 = new Intake { IntakeID = "jbk43l", IntakeNumber = 38 };
            var intake4 = new Intake { IntakeID = "53hb53", IntakeNumber = 37 };
            var intake5 = new Intake { IntakeID = "k5j34b3i", IntakeNumber = 36 };
            var intake6 = new Intake { IntakeID = "43t65il", IntakeNumber = 35 };
            var intake7 = new Intake { IntakeID = "432vuv", IntakeNumber = 34 };
            var intake8 = new Intake { IntakeID = "4u23v", IntakeNumber = 33 };
            var intake9 = new Intake { IntakeID = "oi765", IntakeNumber = 32 };
            var intake10 = new Intake { IntakeID = "fvghwt", IntakeNumber = 31 };
            var intake11 = new Intake { IntakeID = "g423hfvy", IntakeNumber = 30 };
            var intake12 = new Intake { IntakeID = "2jg3vrf", IntakeNumber = 29 };
            
            builder.Entity<Intake>().HasData(
                intake1, intake2, intake3, intake4, intake5, intake6, intake7, intake8, intake9, intake10, intake11, intake12
            );

            //Grade
            var grade01 = new Grade { GradeID = "iiu2983", GradeName = "A+", CreditValue = 4.20, FinalMarks = "85 –100" }       ;
            var grade02 = new Grade { GradeID = "3r3f", GradeName = "A", CreditValue = 4.00, FinalMarks = "75 –84" }          ;
            var grade03 = new Grade { GradeID = "wff33f", GradeName = "A-", CreditValue = 3.70, FinalMarks = "70 –74" }      ;
                                                                                                                                  ;
            var grade04 = new Grade { GradeID = "3f3f3", GradeName = "B+", CreditValue = 3.30, FinalMarks = "65 –69" }          ;
            var grade05 = new Grade { GradeID = "3ff3f", GradeName = "B", CreditValue = 3.00, FinalMarks = "60 –64" }          ;
            var grade06 = new Grade { GradeID = "re43", GradeName = "B-", CreditValue = 2.70, FinalMarks = "55 –59" }        ;
                                                                                                                                 ;
            var grade07 = new Grade { GradeID = "6h6h5b", GradeName = "C+", CreditValue = 2.30, FinalMarks = "50 –54" }          ;
            var grade08 = new Grade { GradeID = "56h56hbyg", GradeName = "C", CreditValue = 2.70, FinalMarks = "45 –49" }       ;
            var grade09 = new Grade { GradeID = "dfg5445gtf", GradeName = "C-", CreditValue = 1.70, FinalMarks = "40 –44" }      ;
                                                                                                                                  ;
            var grade10 = new Grade { GradeID = "54gfge", GradeName = "D+", CreditValue = 1.30, FinalMarks = "35 –39" }        ;
                                                                                                                                  ;
            var grade11 = new Grade { GradeID = "afg4t54", GradeName = "Ie", CreditValue = 0.00, FinalMarks = "ES <35" }        ;
                                                                                                                                  ;
            var grade12 = new Grade { GradeID = "67j6j", GradeName = "Ia", CreditValue = 0.00, FinalMarks = "CA < 35" }       ;
            var grade13 = new Grade { GradeID = "43f3d", GradeName = "Ia", CreditValue = 0.00, FinalMarks = "PBCA <35%" }       ;
                                                                                                                                  ;
            var grade14 = new Grade { GradeID = "43frg", GradeName = "Ib", CreditValue = 0.00, FinalMarks = "Both ES & CA < 35" };
                                                                                                                                  ;
            var grade15 = new Grade { GradeID = "43gfsdfgt", GradeName = "Ne", CreditValue = 0.00, FinalMarks = "Not eligible" } ;
            var grade16 = new Grade { GradeID = "232fgfd", GradeName = "Ab", CreditValue = 0.00, FinalMarks = "Absent" }         ;
            var grade17 = new Grade { GradeID = "432txgfge", GradeName = "Ex", CreditValue = 0.00, FinalMarks = "Excused" }       ;
            
            builder.Entity<Grade>().HasData(
                grade01, grade02, grade03, grade04,  grade05, grade06, grade07, grade08, grade09, grade10, grade11,  grade12, grade13, grade14, grade15, grade16, grade17
            );

            //Department
            builder.Entity<Department>().HasData(
                //Computing
                new Department { DepartmentID = "3dfde3", FacultyID = "23df2", DepartmentName = "Information Technology" },
                new Department { DepartmentID = "qdw", FacultyID = "23df2", DepartmentName = "Computer Science" },
                new Department { DepartmentID = "32rfrv", FacultyID = "23df2", DepartmentName = "Computer Engineering" },
                new Department { DepartmentID = "3vr3q", FacultyID = "23df2", DepartmentName = "Computational Mathematics" },

                //Engineering
                new Department { DepartmentID = "dwdw3", FacultyID = "432rf2", DepartmentName = "Aeronautical Engineering" },
                new Department { DepartmentID = "gerger", FacultyID = "432rf2", DepartmentName = "Civil Engineering" },
                new Department { DepartmentID = "rtebt", FacultyID = "432rf2", DepartmentName = "Electronic & Telecommunication Engineering" },
                new Department { DepartmentID = "3jkfqa", FacultyID = "432rf2", DepartmentName = "Mathematics" },
                new Department { DepartmentID = "dw22d", FacultyID = "432rf2", DepartmentName = "Mechanical Engineering" },
                new Department { DepartmentID = "312ju3dfn", FacultyID = "432rf2", DepartmentName = "Marine engineering" }
            );

            //Degree
            //Information Technology
            var deg01 = new Degree { DegreeID = "ddwd232", DepartmentID = "3dfde3", DegreeName = "BSc Information Technology", DegreeCode = "IT", NumOfYears = 4 };
            var deg02 = new Degree { DegreeID = "nu654", DepartmentID = "3dfde3", DegreeName = "BSc Information System", DegreeCode = "IS", NumOfYears = 4 }   ;
                                                                                                                                                                   ;
            //Computer Science                                                                                                                                     ;
            var deg03 = new Degree { DegreeID = "64nhf", DepartmentID = "qdw", DegreeName = "BSc Computer Science", DegreeCode = "CS", NumOfYears = 4 }       ;
            var deg04 = new Degree { DegreeID = "ol433", DepartmentID = "qdw", DegreeName = "BSc Software Engineering", DegreeCode = "SE", NumOfYears = 4 }      ;
                                                                                                                                                                   ;
            //Computer Engineering                                                                                                                                 ;
            var deg05 = new Degree { DegreeID = "234fsg", DepartmentID = "32rfrv", DegreeName = "BSc Computer Engineering", DegreeCode = "CE", NumOfYears = 4 };

            builder.Entity<Degree>().HasData(
                deg01, deg02, deg03, deg04, deg05
            );

            //SubjectModule
            //BSc Information Technology
            //BSc IT sem01
            var submod01 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "fwf", SubjectModuleName = "Principles of Management", SubjectModuleCode = "MF1023", SubjectModuleCreditUnit = 2 }                 ;
            var submod02 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "efwfw", SubjectModuleName = "Fundamentals of Computer System ", SubjectModuleCode = "IT1043", SubjectModuleCreditUnit = 3 }       ;
            var submod03 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "3dfkujt6de3", SubjectModuleName = "Information Technology Concepts ", SubjectModuleCode = "IT1022", SubjectModuleCreditUnit = 2 } ;
            var submod04 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "4h4geg", SubjectModuleName = "Fundamentals of Computer Programming", SubjectModuleCode = "IT1033", SubjectModuleCreditUnit = 3 }  ;
            var submod05 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "bfdg5443y", SubjectModuleName = "Fundamentals of Visual Computing", SubjectModuleCode = "IT1062", SubjectModuleCreditUnit = 2 }   ;
            var submod06 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "vfg5", SubjectModuleName = "Mathematics for IT - 1", SubjectModuleCode = "CM1043", SubjectModuleCreditUnit = 3 }                  ;
            //BSc IT sem02                                                                                                                                                                                                ;
            var submod07 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "54h545", SubjectModuleName = "Computer Systems Architecture", SubjectModuleCode = "IT2013", SubjectModuleCreditUnit = 3 }         ;
            var submod08 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "r4rfgre", SubjectModuleName = "Object Oriented Programming ", SubjectModuleCode = "IT2033", SubjectModuleCreditUnit = 3 }         ;
            var submod09 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "4gervf", SubjectModuleName = "System Analysis & Designing", SubjectModuleCode = "IT2043", SubjectModuleCreditUnit = 3 }           ;
            var submod10 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "23ftgw4t5", SubjectModuleName = "Fundamentals of DBMS", SubjectModuleCode = "IT2053", SubjectModuleCreditUnit = 3 }               ;
            var submod11 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "657j5j", SubjectModuleName = "Visual Computing Project (Group)", SubjectModuleCode = "IT2072", SubjectModuleCreditUnit = 2 }      ;
            var submod12 = new SubjectModule { DegreeID = "ddwd232", SubjectModuleID = "th45hr", SubjectModuleName = "Probability and Statistics", SubjectModuleCode = "CM2052", SubjectModuleCreditUnit = 2 };

            builder.Entity<SubjectModule>().HasData(
                submod01, submod02, submod03, submod04, submod05, submod06, submod07, submod08, submod09, submod10, submod11, submod12
            );


            //Roles
            //1
            var adminRole = new IdentityRole(SD.AdminEndUser);
            //2
            var staffRole = new IdentityRole(SD.StaffEndUser);
            //3
            var hODRole = new IdentityRole(SD.HODEndUser);
            //4
            var studentRole = new IdentityRole(SD.StudentEndUser);

            builder.Entity<IdentityRole>().HasData(
                adminRole,
                staffRole,
                hODRole,
                studentRole
            );

            //ApplicationUser
            var adminUser = new ApplicationUser { LockoutEnabled = true, ConcurrencyStamp = "7a4e3c9a-406a-424c-ab38-d081219c83d1", SecurityStamp = "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", NormalizedUserName = "admin@gmail.com", NormalizedEmail = "ADMIN@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", UserName = "admin@gmail.com", Email = "admin@gmail.com", RegNum = "D/IT/18/0067", FirstName = "Bimsara", LastName = "Gunarathna", UserRole = 1, IntakeID = "43t65il", DegreeID = "ddwd232", DepartmentID = "3dfde3", FacultyID = "23df2" };
            var studentUser = new ApplicationUser { LockoutEnabled = true, ConcurrencyStamp = "7a4e3c9a-406a-424c-ab38-d081219c83d1", SecurityStamp = "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", NormalizedUserName = "student@gmail.com", NormalizedEmail = "STUDENT@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", UserName = "student@gmail.com", Email = "student@gmail.com", RegNum = "D/IT/18/0067", FirstName = "Bimsara", LastName = "Gunarathna", UserRole = 4, IntakeID = "43t65il", DegreeID = "ddwd232", DepartmentID = "3dfde3", FacultyID = "23df2" };
            var staffUser = new ApplicationUser { LockoutEnabled = true, ConcurrencyStamp = "7a4e3c9a-406a-424c-ab38-d081219c83d1", SecurityStamp = "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", NormalizedUserName = "staff@gmail.com", NormalizedEmail = "STAFF@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", UserName = "staff@gmail.com", Email = "staff@gmail.com", RegNum = "D/IS/18/0015", FirstName = "Harry", LastName = "Potter", UserRole = 2, IntakeID = "k5j34b3i", DegreeID = "ol433", DepartmentID = "qdw", FacultyID = "23df2" };
            var hODUser = new ApplicationUser { LockoutEnabled = true, ConcurrencyStamp = "7a4e3c9a-406a-424c-ab38-d081219c83d1", SecurityStamp = "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", NormalizedUserName = "hod@gmail.com", NormalizedEmail = "HOD@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", UserName = "hod@gmail.com", Email = "hod@gmail.com", RegNum = "D/SE/18/0067", FirstName = "Elon", LastName = "Musk", UserRole = 3, IntakeID = "k5j34b3i", DegreeID = "ol433", DepartmentID = "qdw", FacultyID = "23df2" };

            builder.Entity<ApplicationUser>().HasData(
                adminUser,
                studentUser,
                staffUser,
                hODUser
            );

            //UserRoles
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRole.Id, UserId = adminUser.Id },
                new IdentityUserRole<string> { RoleId = studentRole.Id, UserId = studentUser.Id },
                new IdentityUserRole<string> { RoleId = staffRole.Id, UserId = staffUser.Id },
                new IdentityUserRole<string> { RoleId = hODRole.Id, UserId = hODUser.Id }
            );


            //Papers
            builder.Entity<Paper>().HasData(
                new Paper { PaperID = Guid.NewGuid().ToString(), SemesterID = sem01.SemesterID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod12.SubjectModuleID, GradeID = grade01.GradeID },
                new Paper { PaperID = Guid.NewGuid().ToString(), SemesterID = sem01.SemesterID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod11.SubjectModuleID, GradeID = grade02.GradeID },
                new Paper { PaperID = Guid.NewGuid().ToString(), SemesterID = sem01.SemesterID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod10.SubjectModuleID, GradeID = grade03.GradeID }
            );
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Intake> Intake { get; set; }

        public DbSet<Faculty> Faculty { get; set; }

        public DbSet<AcademicYear> AcademicYear { get; set; }

        public DbSet<Degree> Degree { get; set; }

        public DbSet<Semester> Semester { get; set; }

        public DbSet<Grade> Grade { get; set; }

        public DbSet<Paper> Paper { get; set; }

        public DbSet<SGPA> SGPA { get; set; }

        public DbSet<YGPA> YGPA { get; set; }

        public DbSet<SubjectModule> SubjectModule { get; set; }

        public DbSet<GPA> GPA { get; set; }

    }
}
