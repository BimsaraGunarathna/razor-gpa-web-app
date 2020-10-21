using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace razor_gpa_web_app.Migrations
{
    public partial class Mig03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<string>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true),
                    FacultyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    YearID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearNumber = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.YearID);
                });

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    DegreeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeName = table.Column<string>(maxLength: 50, nullable: false),
                    facultyName = table.Column<string>(maxLength: 50, nullable: false),
                    DegreeCode = table.Column<string>(maxLength: 10, nullable: false),
                    NumOfYears = table.Column<int>(nullable: false),
                    DepartmentID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.DegreeID);
                    table.ForeignKey(
                        name: "FK_Degree_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    SemesterID = table.Column<string>(nullable: false),
                    SemesterNumber = table.Column<int>(nullable: false),
                    YearID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.SemesterID);
                    table.ForeignKey(
                        name: "FK_Semester_Year_YearID",
                        column: x => x.YearID,
                        principalTable: "Year",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModule",
                columns: table => new
                {
                    SubjectModuleID = table.Column<string>(nullable: false),
                    SubjectModuleName = table.Column<string>(nullable: true),
                    DegreeID = table.Column<string>(nullable: true),
                    DegreeID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModule", x => x.SubjectModuleID);
                    table.ForeignKey(
                        name: "FK_SubjectModule_Degree_DegreeID1",
                        column: x => x.DegreeID1,
                        principalTable: "Degree",
                        principalColumn: "DegreeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SGPA",
                columns: table => new
                {
                    SGPAID = table.Column<string>(nullable: false),
                    SGPAValue = table.Column<string>(nullable: true),
                    YearID = table.Column<string>(nullable: true),
                    StudentID = table.Column<string>(nullable: true),
                    SemesterID = table.Column<string>(nullable: true),
                    YearID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SGPA", x => x.SGPAID);
                    table.ForeignKey(
                        name: "FK_SGPA_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SGPA_Year_YearID1",
                        column: x => x.YearID1,
                        principalTable: "Year",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GPA",
                columns: table => new
                {
                    GPAID = table.Column<string>(nullable: false),
                    GPAValue = table.Column<double>(nullable: false),
                    StudentID = table.Column<string>(nullable: true),
                    SemesterID = table.Column<string>(nullable: true),
                    SubjectModuleID = table.Column<string>(nullable: true),
                    YearID = table.Column<string>(nullable: true),
                    YearID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPA", x => x.GPAID);
                    table.ForeignKey(
                        name: "FK_GPA_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GPA_SubjectModule_SubjectModuleID",
                        column: x => x.SubjectModuleID,
                        principalTable: "SubjectModule",
                        principalColumn: "SubjectModuleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GPA_Year_YearID1",
                        column: x => x.YearID1,
                        principalTable: "Year",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeID = table.Column<string>(nullable: false),
                    GradeChar = table.Column<int>(nullable: true),
                    SemesterID = table.Column<string>(nullable: true),
                    GPAID = table.Column<string>(nullable: true),
                    DegreeID = table.Column<string>(nullable: true),
                    StudentID = table.Column<string>(nullable: true),
                    DegreeID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeID);
                    table.ForeignKey(
                        name: "FK_Grade_Degree_DegreeID1",
                        column: x => x.DegreeID1,
                        principalTable: "Degree",
                        principalColumn: "DegreeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grade_GPA_GPAID",
                        column: x => x.GPAID,
                        principalTable: "GPA",
                        principalColumn: "GPAID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grade_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Degree_DepartmentID",
                table: "Degree",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_GPA_SemesterID",
                table: "GPA",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_GPA_SubjectModuleID",
                table: "GPA",
                column: "SubjectModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_GPA_YearID1",
                table: "GPA",
                column: "YearID1");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_DegreeID1",
                table: "Grade",
                column: "DegreeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_GPAID",
                table: "Grade",
                column: "GPAID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SemesterID",
                table: "Grade",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_YearID",
                table: "Semester",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_SGPA_SemesterID",
                table: "SGPA",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_SGPA_YearID1",
                table: "SGPA",
                column: "YearID1");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectModule_DegreeID1",
                table: "SubjectModule",
                column: "DegreeID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "SGPA");

            migrationBuilder.DropTable(
                name: "GPA");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "SubjectModule");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
