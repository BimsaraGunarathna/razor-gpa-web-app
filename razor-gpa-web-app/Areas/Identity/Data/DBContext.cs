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

        //public DbSet<GPA> GPA { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Academic Year
            var acayaer01 = new AcademicYear { AcademicYearID = "myud", StartDate = DateTime.Parse("2024-01-01") };
            var acayaer02 = new AcademicYear { AcademicYearID = "myrfwfud", StartDate = DateTime.Parse("2023-01-01")};
            var acayaer03 = new AcademicYear { AcademicYearID = "eveefweveum", StartDate = DateTime.Parse("2022-01-01")};
            var acayaer04 = new AcademicYear { AcademicYearID = "3d3emucdf", StartDate = DateTime.Parse("2021-01-01")};
            var acayaer05 = new AcademicYear { AcademicYearID = "ecj235332", StartDate = DateTime.Parse("2020-01-01")};
            var acayaer06 = new AcademicYear { AcademicYearID = "3rcd535c", StartDate = DateTime.Parse("2019-01-01")};
            var acayaer07 = new AcademicYear { AcademicYearID = "ec3fej232", StartDate = DateTime.Parse("2018-01-01")};
            var acayaer08 = new AcademicYear { AcademicYearID = "veve353vv", StartDate = DateTime.Parse("2017-01-01")};
            var acayaer09 = new AcademicYear { AcademicYearID = "3ffv35efe33", StartDate = DateTime.Parse("2016-01-01")};
            var acayaer10 = new AcademicYear { AcademicYearID = "3dvevfve3ecdf", StartDate = DateTime.Parse("2015-01-01")};
            var acayaer11 = new AcademicYear { AcademicYearID = "3fee33fe33", StartDate = DateTime.Parse("2014-01-01")};
            var acayaer12 = new AcademicYear { AcademicYearID = "3d3vevecdf", StartDate = DateTime.Parse("2013-01-01")};
            var acayaer13 = new AcademicYear { AcademicYearID = "3fevwefw34fe33", StartDate = DateTime.Parse("2012-01-01")};
            builder.Entity<AcademicYear>().HasData(
                acayaer01, acayaer02, acayaer03, acayaer04, acayaer05, acayaer06, acayaer07, acayaer08, acayaer09, acayaer10, acayaer11, acayaer12, acayaer13
            );
            /*
            //Semester
            //01
            var sem01 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer01.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" };
            var sem02 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer02.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" }          ;
            var sem03 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer03.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" }   ;
            var sem04 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer04.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" }      ;
            var sem05 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer05.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" }  ;
            var sem06 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer06.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" }  ;
            var sem07 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer07.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" } ;
            var sem08 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer08.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" }       ;
            var sem09 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer09.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" }    ;
            var sem10 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer10.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" }  ;
            var sem11 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer11.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" }   ;
            var sem12 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer12.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" }   ;
            var sem13 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer13.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 01" } ;

            //02
            var sem14 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer01.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem15 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer02.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem16 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer03.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem17 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer04.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem18 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer05.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem19 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer06.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem20 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer07.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem21 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer08.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem22 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer09.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem23 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer10.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem24 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer11.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem25 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer12.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };
            var sem26 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer13.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 02" };

            //03
            var sem27 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer01.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem28 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer02.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem29 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer03.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem30 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer04.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem31 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer05.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem32 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer06.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem33 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer07.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem34 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer08.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem35 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer09.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem36 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer10.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem37 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer11.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem38 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer12.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };
            var sem39 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer13.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 03" };

            //04
            var sem40 = new Semester { SemesterID = "hj56jh5", AcademicYearID = acayaer01.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem41 = new Semester { SemesterID = "45h4dhh", AcademicYearID = acayaer02.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem42 = new Semester { SemesterID = "54h5erhgh", AcademicYearID = acayaer03.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem43 = new Semester { SemesterID = "y4ugty34t34", AcademicYearID = acayaer04.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem44 = new Semester { SemesterID = "98987houaw", AcademicYearID = acayaer05.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem45 = new Semester { SemesterID = "487u3gfua84", AcademicYearID = acayaer06.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem46 = new Semester { SemesterID = "4uyert3t34tgf3", AcademicYearID = acayaer07.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem47 = new Semester { SemesterID = "yu453yugbf", AcademicYearID = acayaer08.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem48 = new Semester { SemesterID = "34uyu3gf3t3tgf", AcademicYearID = acayaer09.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem49 = new Semester { SemesterID = "iy4nliuy4uiy", AcademicYearID = acayaer10.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem50 = new Semester { SemesterID = "wy5ukbiu4w5luyi4", AcademicYearID = acayaer11.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem51 = new Semester { SemesterID = "iuywb545y54y54", AcademicYearID = acayaer12.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };
            var sem52 = new Semester { SemesterID = "y34t3u4ybjhr4", AcademicYearID = acayaer13.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 04" };

            //05
            var sem53 = new Semester { SemesterID = "bt43uyitb3", AcademicYearID = acayaer01.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem54 = new Semester { SemesterID = "4at34t34t", AcademicYearID = acayaer02.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem55 = new Semester { SemesterID = "f3g5rthy57j67f3rfr", AcademicYearID = acayaer03.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem56 = new Semester { SemesterID = "56h5hs4hw", AcademicYearID = acayaer04.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem57 = new Semester { SemesterID = "3w5gr45eag", AcademicYearID = acayaer05.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem58 = new Semester { SemesterID = "54gh54hg547yuj", AcademicYearID = acayaer06.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem59 = new Semester { SemesterID = "eggegeg", AcademicYearID = acayaer07.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem60 = new Semester { SemesterID = "uyrgy775urte", AcademicYearID = acayaer08.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem61 = new Semester { SemesterID = "u67ju5yjh", AcademicYearID = acayaer09.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem62 = new Semester { SemesterID = "56ej5u6e", AcademicYearID = acayaer10.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem63 = new Semester { SemesterID = "eu6u65eu5", AcademicYearID = acayaer11.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem64 = new Semester { SemesterID = "65ehjertyh", AcademicYearID = acayaer12.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };
            var sem65 = new Semester { SemesterID = "45h456h645", AcademicYearID = acayaer13.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 05" };

            //06
            var sem66 = new Semester { SemesterID = "yurgebiuybg3", AcademicYearID = acayaer01.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem67 = new Semester { SemesterID = "yuibguyeb", AcademicYearID = acayaer02.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem68 = new Semester { SemesterID = "aifiugf4443", AcademicYearID = acayaer03.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem69 = new Semester { SemesterID = "yu43tuytv4u3kyq", AcademicYearID = acayaer04.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem70 = new Semester { SemesterID = "yu4yu3uy2242", AcademicYearID = acayaer05.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem71 = new Semester { SemesterID = "4uhjvuyv2rr", AcademicYearID = acayaer06.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem72 = new Semester { SemesterID = "uyawvguy443", AcademicYearID = acayaer07.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem73 = new Semester { SemesterID = "uish7f483f74", AcademicYearID = acayaer08.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem74 = new Semester { SemesterID = "434vuyuwe", AcademicYearID = acayaer09.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem75 = new Semester { SemesterID = "32yrvyku2q", AcademicYearID = acayaer10.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem76 = new Semester { SemesterID = "yu43tuyb34y", AcademicYearID = acayaer11.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem77 = new Semester { SemesterID = "yu43vbyut34", AcademicYearID = acayaer12.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };
            var sem78 = new Semester { SemesterID = "u4y3vbuy433w4t", AcademicYearID = acayaer13.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 06" };

            //07
            var sem79 = new Semester { SemesterID = "uy43tbuy34bt3", AcademicYearID = acayaer01.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem80 = new Semester { SemesterID = "ybu4i3ktbuk3", AcademicYearID = acayaer02.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem81 = new Semester { SemesterID = "4yutyu34", AcademicYearID = acayaer03.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem82 = new Semester { SemesterID = "yu43tbuyt34twa", AcademicYearID = acayaer04.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem83 = new Semester { SemesterID = "hyu3j4byut", AcademicYearID = acayaer05.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem84 = new Semester { SemesterID = "yh4bvtuy34btw3", AcademicYearID = acayaer06.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem85 = new Semester { SemesterID = "bh3tu4bu34yb", AcademicYearID = acayaer07.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem86 = new Semester { SemesterID = "4u3bvtu34ybt43", AcademicYearID = acayaer08.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem87 = new Semester { SemesterID = "iughnsgui3t3t34", AcademicYearID = acayaer09.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem88 = new Semester { SemesterID = "yu43bvyu43bfggf", AcademicYearID = acayaer10.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem89 = new Semester { SemesterID = "yu43bvtuyb4sdf", AcademicYearID = acayaer11.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem90 = new Semester { SemesterID = "4uy3gby43ub", AcademicYearID = acayaer12.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };
            var sem91 = new Semester { SemesterID = "uyh43byffg34", AcademicYearID = acayaer13.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 07" };

            //08
            var sem92 = new Semester { SemesterID = "reg43g", AcademicYearID = acayaer01.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem93 = new Semester { SemesterID = "43ggferg", AcademicYearID = acayaer02.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem94 = new Semester { SemesterID = "43t34gfg", AcademicYearID = acayaer03.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem95 = new Semester { SemesterID = "43gf34gf", AcademicYearID = acayaer04.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem96 = new Semester { SemesterID = "43ggfh6", AcademicYearID = acayaer05.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem97 = new Semester { SemesterID = "y54h5y6jh7", AcademicYearID = acayaer06.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem98 = new Semester { SemesterID = "arar4tg45h5", AcademicYearID = acayaer07.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem99 = new Semester { SemesterID = "345g54g54hg", AcademicYearID = acayaer08.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem100 = new Semester { SemesterID = "ty3f4vytb", AcademicYearID = acayaer09.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem101 = new Semester { SemesterID = "yuhbfwuy", AcademicYearID = acayaer10.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem102 = new Semester { SemesterID = "jirbagu", AcademicYearID = acayaer11.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem103 = new Semester { SemesterID = "43btuy34", AcademicYearID = acayaer12.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };
            var sem104 = new Semester { SemesterID = "uy435bgub", AcademicYearID = acayaer13.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 08" };

            builder.Entity<Semester>().HasData(
                sem01 , sem02 ,sem03 ,sem04 ,sem05 ,sem06 ,sem07 ,sem08 ,sem09 ,sem10 ,sem11 ,sem12 , sem13,
                sem14 ,sem15 , sem16 ,sem17 ,sem18 ,sem19 ,sem20 ,sem21 ,sem22 ,sem23 ,sem24 ,sem25 ,sem26,
                sem27, sem28, sem29, sem30, sem31, sem32, sem33, sem34, sem35, sem36, sem37, sem38, sem39,
                sem40, sem41, sem42, sem43, sem44, sem45, sem46, sem47, sem48, sem49, sem50, sem51, sem52,
                sem53, sem54, sem55, sem56, sem57, sem58, sem59, sem60, sem61, sem62, sem63, sem64, sem65,
                sem66, sem67, sem68, sem69, sem70, sem71, sem72, sem73, sem74, sem75, sem76, sem77, sem78,
                sem79, sem80, sem81, sem82, sem83, sem84, sem85, sem86, sem87, sem88, sem89, sem90, sem91,
                sem92, sem93, sem94, sem95, sem96, sem97, sem98, sem99, sem100, sem101, sem102, sem103, sem104
            );
            */
            //Semester
            var sem01 = new Semester { SemesterID = "1", SemesterNumber = 1, SemesterName = "Semester 1" };
            var sem02 = new Semester { SemesterID = "2", SemesterNumber = 2, SemesterName = "Semester 2" };
            var sem03 = new Semester { SemesterID = "3", SemesterNumber = 3, SemesterName = "Semester 3" };
            var sem04 = new Semester { SemesterID = "4", SemesterNumber = 4, SemesterName = "Semester 4" };
            var sem05 = new Semester { SemesterID = "5", SemesterNumber = 5, SemesterName = "Semester 5" };
            var sem06= new Semester { SemesterID = "6", SemesterNumber = 6, SemesterName = "Semester 6" };
            var sem07 = new Semester { SemesterID = "7", SemesterNumber = 7, SemesterName = "Semester 7" };
            var sem08 = new Semester { SemesterID = "8", SemesterNumber = 8, SemesterName = "Semester 8" };
            var sem09 = new Semester { SemesterID = "9", SemesterNumber = 9, SemesterName = "Semester 9" };
            var sem10 = new Semester { SemesterID = "10", SemesterNumber = 10, SemesterName = "Semester 10" };
            builder.Entity<Semester>().HasData(
                sem01, sem02, sem03, sem04, sem05, sem06, sem07, sem08, sem09, sem10
            );
            /*
            var sem01 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer01.AcademicYearID, SemesterNumber = 1, SemesterName = "Semester 1" };
            var sem02 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer02.AcademicYearID, SemesterNumber = 2, SemesterName = "Semester 2" };
            var sem03 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer03.AcademicYearID, SemesterNumber = 3, SemesterName = "Semester 3" };
            var sem04 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer04.AcademicYearID, SemesterNumber = 4, SemesterName = "Semester 4" };
            var sem05 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer05.AcademicYearID, SemesterNumber = 5, SemesterName = "Semester 5" };
            var sem06 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer06.AcademicYearID, SemesterNumber = 6, SemesterName = "Semester 6" };
            var sem07 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer07.AcademicYearID, SemesterNumber = 7, SemesterName = "Semester 7" };
            var sem08 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer08.AcademicYearID, SemesterNumber = 8, SemesterName = "Semester 8" };
            var sem09 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer07.AcademicYearID, SemesterNumber = 9, SemesterName = "Semester 9" };
            var sem10 = new Semester { SemesterID = Guid.NewGuid().ToString(), AcademicYearID = acayaer08.AcademicYearID, SemesterNumber = 10, SemesterName = "Semester 10" };
            */

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
            var grade01 = new Grade { GradeID = "A+", GradeName = "A+", CreditValue = 4.20, FinalMarks = "85 –100" }       ;
            var grade02 = new Grade { GradeID = "A", GradeName = "A", CreditValue = 4.00, FinalMarks = "75 –84" }          ;
            var grade03 = new Grade { GradeID = "A-", GradeName = "A-", CreditValue = 3.70, FinalMarks = "70 –74" }      ;
                                                                                                                                  ;
            var grade04 = new Grade { GradeID = "B+", GradeName = "B+", CreditValue = 3.30, FinalMarks = "65 –69" }          ;
            var grade05 = new Grade { GradeID = "B", GradeName = "B", CreditValue = 3.00, FinalMarks = "60 –64" }          ;
            var grade06 = new Grade { GradeID = "B-", GradeName = "B-", CreditValue = 2.70, FinalMarks = "55 –59" }        ;
                                                                                                                                 ;
            var grade07 = new Grade { GradeID = "C+", GradeName = "C+", CreditValue = 2.30, FinalMarks = "50 –54" }          ;
            var grade08 = new Grade { GradeID = "C", GradeName = "C", CreditValue = 2.70, FinalMarks = "45 –49" }       ;
            var grade09 = new Grade { GradeID = "C-", GradeName = "C-", CreditValue = 1.70, FinalMarks = "40 –44" }      ;
                                                                                                                                  ;
            var grade10 = new Grade { GradeID = "D+", GradeName = "D+", CreditValue = 1.30, FinalMarks = "35 –39" }        ;
                                                                                                                                  ;
            var grade11 = new Grade { GradeID = "Ie", GradeName = "Ie", CreditValue = 0.00, FinalMarks = "ES <35" }        ;
                                                                                                                                  ;
            var grade12 = new Grade { GradeID = "Ia", GradeName = "Ia", CreditValue = 0.00, FinalMarks = "CA < 35" }       ;
            var grade13 = new Grade { GradeID = "Ia%", GradeName = "Ia", CreditValue = 0.00, FinalMarks = "PBCA <35%" }       ;
                                                                                                                                  ;
            var grade14 = new Grade { GradeID = "Ib", GradeName = "Ib", CreditValue = 0.00, FinalMarks = "Both ES & CA < 35" };
                                                                                                                                  ;
            var grade15 = new Grade { GradeID = "Ne", GradeName = "Ne", CreditValue = 0.00, FinalMarks = "Not eligible" } ;
            var grade16 = new Grade { GradeID = "Ab", GradeName = "Ab", CreditValue = 0.00, FinalMarks = "Absent" }         ;
            var grade17 = new Grade { GradeID = "Ex", GradeName = "Ex", CreditValue = 0.00, FinalMarks = "Excused" }       ;
            
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
            //BSc IT sem02                                                                                                                                                                                                
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
            var adminUser = new ApplicationUser { LockoutEnabled = true, ConcurrencyStamp = "7a4e3c9a-406a-424c-ab38-d081219c83d1", SecurityStamp = "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", NormalizedUserName = "admin@gmail.com", NormalizedEmail = "ADMIN@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", UserName = "admin@gmail.com", Email = "admin@gmail.com", RegNum = "admin", FirstName = "Bimsara", LastName = "Gunarathna", UserRole = 1, IntakeID = "43t65il", DegreeID = "ddwd232", DepartmentID = "3dfde3", FacultyID = "23df2" };
            var studentUser = new ApplicationUser { LockoutEnabled = true, ConcurrencyStamp = "7a4e3c9a-406a-424c-ab38-d081219c83d1", SecurityStamp = "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", NormalizedUserName = "student@gmail.com", NormalizedEmail = "STUDENT@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", UserName = "student@gmail.com", Email = "student@gmail.com", RegNum = "student", FirstName = "Bimsara", LastName = "Gunarathna", UserRole = 4, IntakeID = "43t65il", DegreeID = "ddwd232", DepartmentID = "3dfde3", FacultyID = "23df2" };
            var staffUser = new ApplicationUser { LockoutEnabled = true, ConcurrencyStamp = "7a4e3c9a-406a-424c-ab38-d081219c83d1", SecurityStamp = "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", NormalizedUserName = "staff@gmail.com", NormalizedEmail = "STAFF@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", UserName = "staff@gmail.com", Email = "staff@gmail.com", RegNum = "staff", FirstName = "Harry", LastName = "Potter", UserRole = 2, IntakeID = "k5j34b3i", DegreeID = "ol433", DepartmentID = "3dfde3", FacultyID = "23df2" };
            var hODUser = new ApplicationUser { LockoutEnabled = true, ConcurrencyStamp = "7a4e3c9a-406a-424c-ab38-d081219c83d1", SecurityStamp = "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", NormalizedUserName = "hod@gmail.com", NormalizedEmail = "HOD@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", UserName = "hod@gmail.com", Email = "hod@gmail.com", RegNum = "hod", FirstName = "Elon", LastName = "Musk", UserRole = 3, IntakeID = "k5j34b3i", DegreeID = "ol433", DepartmentID = "3dfde3", FacultyID = "23df2" };

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

            /*
            //Papers
            builder.Entity<Paper>().HasData(
                //Guid.NewGuid().ToString()
                //Semester 01
                new Paper { PaperID = "ej32i1123", SemesterID = sem01.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod01.SubjectModuleID, GradeID = grade01.GradeID },
                new Paper { PaperID = "jbwfwi3t3223", SemesterID = sem01.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod02.SubjectModuleID, GradeID = grade02.GradeID },
                new Paper { PaperID = "hjwbu232332", SemesterID = sem01.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod03.SubjectModuleID, GradeID = grade03.GradeID },

                //Semester 02
                new Paper { PaperID = "egeg", SemesterID = sem02.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod04.SubjectModuleID, GradeID = grade01.GradeID },
                new Paper { PaperID = "gegehtuj767", SemesterID = sem02.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod05.SubjectModuleID, GradeID = grade02.GradeID },
                new Paper { PaperID = "65ufghd", SemesterID = sem02.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod06.SubjectModuleID, GradeID = grade03.GradeID },

                //Semester 03
                new Paper { PaperID = "y54y54hgf", SemesterID = sem03.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod07.SubjectModuleID, GradeID = grade01.GradeID },
                new Paper { PaperID = "54y45shg", SemesterID = sem03.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod08.SubjectModuleID, GradeID = grade02.GradeID },
                new Paper { PaperID = "54hgt54jhn", SemesterID = sem03.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod09.SubjectModuleID, GradeID = grade03.GradeID },

                //Semester 04
                new Paper { PaperID = "hjgrebg", SemesterID = sem04.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod10.SubjectModuleID, GradeID = grade01.GradeID },
                new Paper { PaperID = "43jhgvbtu43", SemesterID = sem04.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod11.SubjectModuleID, GradeID = grade02.GradeID },
                new Paper { PaperID = "3uhj4vbuyh", SemesterID = sem04.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod12.SubjectModuleID, GradeID = grade03.GradeID }

            );
            */
            /*
            //GPA
            builder.Entity<GPA>().HasData(
                //Guid.NewGuid().ToString()
                //Semester 01
                new GPA { GPAID = "vfverv345hy", SemesterID = sem01.SemesterID, AcademicYearID = acayaer01.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod01.SubjectModuleID },
                new GPA { GPAID = "eve434v", SemesterID = sem01.SemesterID, AcademicYearID = acayaer01.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod02.SubjectModuleID },
                new GPA { GPAID = "hjwbu2ev32332", SemesterID = sem01.SemesterID, AcademicYearID = acayaer01.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod03.SubjectModuleID },

                //Semester 02
                new GPA { GPAID = "egeveeg", SemesterID = sem02.SemesterID, AcademicYearID = acayaer01.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod04.SubjectModuleID },
                new GPA { GPAID = "gegevevhtuj767", SemesterID = sem02.SemesterID, AcademicYearID = acayaer01.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod05.SubjectModuleID },
                new GPA { GPAID = "th4htrht45", SemesterID = sem02.SemesterID, AcademicYearID = acayaer01.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod06.SubjectModuleID },

                //Semester 03
                new GPA { GPAID = "y453y45yghhgs", SemesterID = sem03.SemesterID, AcademicYearID = acayaer02.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod07.SubjectModuleID },
                new GPA { GPAID = "543y5ee5ghydhgyj", SemesterID = sem03.SemesterID, AcademicYearID = acayaer02.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod08.SubjectModuleID },
                new GPA { GPAID = "htrhtrhrh", SemesterID = sem03.SemesterID, AcademicYearID = acayaer02.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod09.SubjectModuleID },

                //Semester 04
                new GPA { GPAID = "jy6jdhh54h45", SemesterID = sem04.SemesterID, AcademicYearID = acayaer02.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod10.SubjectModuleID },
                new GPA { GPAID = "45h5htrfh", SemesterID = sem04.SemesterID, AcademicYearID = acayaer02.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod11.SubjectModuleID },
                new GPA { GPAID = "s5y4h65u7", SemesterID = sem04.SemesterID, AcademicYearID = acayaer02.AcademicYearID, StudentID = studentUser.Id, SubjectModuleID = submod12.SubjectModuleID }

            );
            */
            /*
            builder.Entity<Paper>().HasData(
                //Guid.NewGuid().ToString()
                //2024  Semester 01
                new Paper { PaperID = "ej32i1123", SemesterID = sem01.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod01.SubjectModuleID, GradeID = grade01.GradeID },
                new Paper { PaperID = "jbwfwi3t3223", SemesterID = sem01.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod02.SubjectModuleID, GradeID = grade02.GradeID },
                new Paper { PaperID = "hjwbu232332", SemesterID = sem01.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod03.SubjectModuleID, GradeID = grade03.GradeID },

                //2024  Semester 02
                new Paper { PaperID = "egeg", SemesterID = sem14.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod04.SubjectModuleID, GradeID = grade01.GradeID },
                new Paper { PaperID = "gegehtuj767", SemesterID = sem14.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod05.SubjectModuleID, GradeID = grade02.GradeID },
                new Paper { PaperID = "65ufghd", SemesterID = sem14.SemesterID, AcademicYearID = acayaer01.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod06.SubjectModuleID, GradeID = grade03.GradeID },

                //2023  Semester 01
                new Paper { PaperID = "y54y54hgf", SemesterID = sem02.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod07.SubjectModuleID, GradeID = grade01.GradeID },
                new Paper { PaperID = "54y45shg", SemesterID = sem02.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod08.SubjectModuleID, GradeID = grade02.GradeID },
                new Paper { PaperID = "54hgt54jhn", SemesterID = sem02.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod09.SubjectModuleID, GradeID = grade03.GradeID },

                //2023  Semester 02
                new Paper { PaperID = "hjgrebg", SemesterID = sem15.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod10.SubjectModuleID, GradeID = grade01.GradeID },
                new Paper { PaperID = "43jhgvbtu43", SemesterID = sem15.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod11.SubjectModuleID, GradeID = grade02.GradeID },
                new Paper { PaperID = "3uhj4vbuyh", SemesterID = sem15.SemesterID, AcademicYearID = acayaer02.AcademicYearID, DegreeID = deg01.DegreeID, StudentID = studentUser.Id, SubjectModuleID = submod12.SubjectModuleID, GradeID = grade03.GradeID }

            );
            */
        }
    }
}
