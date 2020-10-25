using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Data
{
    public class DbInitializer
    {

        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.AcademicYear.Any())
            {
                return;   // DB has been seeded
            }

            var academicYear = new AcademicYear[]
            {
                new AcademicYear{StartDate=DateTime.Parse("2020-09-01")},
                new AcademicYear{StartDate=DateTime.Parse("2019-09-01")},
                new AcademicYear{StartDate=DateTime.Parse("2018-09-01")},
                new AcademicYear{StartDate=DateTime.Parse("2017-09-01")},
                new AcademicYear{StartDate=DateTime.Parse("2016-09-01")},
            };

            context.AcademicYear.AddRange(academicYear);
            context.SaveChanges();

            var grade = new Grade[]
            {
                new Grade{GradeName="A+",CreditValue=4.20,FinalMarks="85 –100"},
                new Grade{GradeName="A",CreditValue=4.00,FinalMarks="75 –84"},
                new Grade{GradeName="A-",CreditValue=3.70,FinalMarks="70 –74"},

                new Grade{GradeName="B+",CreditValue=3.30,FinalMarks="65 –69"},
                new Grade{GradeName="B",CreditValue=3.00,FinalMarks="60 –64"},
                new Grade{GradeName="B-",CreditValue=2.70,FinalMarks="55 –59"},

                new Grade{GradeName="C+",CreditValue=2.30,FinalMarks="50 –54"},
                new Grade{GradeName="C",CreditValue=2.70,FinalMarks="45 –49"},
                new Grade{GradeName="C-",CreditValue=1.70,FinalMarks="40 –44"},

                new Grade{GradeName="D+",CreditValue=1.30,FinalMarks="35 –39"},

                new Grade{GradeName="Ie",CreditValue=0.00,FinalMarks="ES <35"},

                new Grade{GradeName="Ia",CreditValue=0.00,FinalMarks="CA < 35"},
                new Grade{GradeName="Ia",CreditValue=0.00,FinalMarks="PBCA <35%"},

                new Grade{GradeName="Ib",CreditValue=0.00,FinalMarks="Both ES & CA < 35"},

                new Grade{GradeName="Ne",CreditValue=0.00,FinalMarks="Not eligible"},
                new Grade{GradeName="Ab",CreditValue=0.00,FinalMarks="Absent"},
                new Grade{GradeName="Ex",CreditValue=0.00,FinalMarks="Excused"},
            };

            context.Grade.AddRange(grade);
            
        }

    }
}
