﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace razor_gpa_web_app.Migrations
{
    public partial class mig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicYear",
                columns: table => new
                {
                    AcademicYearID = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYear", x => x.AcademicYearID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FacultyID = table.Column<string>(nullable: false),
                    FacultyName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyID);
                });

            migrationBuilder.CreateTable(
                name: "Intake",
                columns: table => new
                {
                    IntakeID = table.Column<string>(nullable: false),
                    IntakeNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intake", x => x.IntakeID);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    SemesterID = table.Column<string>(nullable: false),
                    SemesterNumber = table.Column<int>(nullable: false),
                    SemesterName = table.Column<string>(nullable: false),
                    AcademicYearID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.SemesterID);
                    table.ForeignKey(
                        name: "FK_Semester_AcademicYear_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<string>(nullable: false),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: false),
                    FacultyID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    DegreeID = table.Column<string>(nullable: false),
                    DegreeName = table.Column<string>(maxLength: 50, nullable: false),
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
                name: "SubjectModule",
                columns: table => new
                {
                    SubjectModuleID = table.Column<string>(nullable: false),
                    SubjectModuleName = table.Column<string>(maxLength: 60, nullable: false),
                    SubjectModuleCode = table.Column<string>(maxLength: 60, nullable: false),
                    SubjectModuleCreditUnit = table.Column<int>(nullable: false),
                    DegreeID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModule", x => x.SubjectModuleID);
                    table.ForeignKey(
                        name: "FK_SubjectModule_Degree_DegreeID",
                        column: x => x.DegreeID,
                        principalTable: "Degree",
                        principalColumn: "DegreeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    RegNum = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserRole = table.Column<int>(nullable: false),
                    IntakeID = table.Column<string>(nullable: true),
                    DegreeID = table.Column<string>(nullable: true),
                    DepartmentID = table.Column<string>(nullable: true),
                    FacultyID = table.Column<string>(nullable: true),
                    SubjectModuleID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Degree_DegreeID",
                        column: x => x.DegreeID,
                        principalTable: "Degree",
                        principalColumn: "DegreeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Intake_IntakeID",
                        column: x => x.IntakeID,
                        principalTable: "Intake",
                        principalColumn: "IntakeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_SubjectModule_SubjectModuleID",
                        column: x => x.SubjectModuleID,
                        principalTable: "SubjectModule",
                        principalColumn: "SubjectModuleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeID = table.Column<string>(nullable: false),
                    GradeName = table.Column<string>(maxLength: 10, nullable: false),
                    FinalMarks = table.Column<string>(maxLength: 25, nullable: false),
                    CreditValue = table.Column<double>(maxLength: 10, nullable: false),
                    SemesterID = table.Column<string>(nullable: true),
                    SubjectModuleID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeID);
                    table.ForeignKey(
                        name: "FK_Grade_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grade_SubjectModule_SubjectModuleID",
                        column: x => x.SubjectModuleID,
                        principalTable: "SubjectModule",
                        principalColumn: "SubjectModuleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPA",
                columns: table => new
                {
                    GPAID = table.Column<string>(nullable: false),
                    GPAValue = table.Column<double>(maxLength: 50, nullable: false),
                    StudentID = table.Column<string>(nullable: true),
                    SemesterID = table.Column<string>(nullable: true),
                    SubjectModuleID = table.Column<string>(nullable: true),
                    AcademicYearID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPA", x => x.GPAID);
                    table.ForeignKey(
                        name: "FK_GPA_AcademicYear_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GPA_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GPA_AspNetUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GPA_SubjectModule_SubjectModuleID",
                        column: x => x.SubjectModuleID,
                        principalTable: "SubjectModule",
                        principalColumn: "SubjectModuleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SGPA",
                columns: table => new
                {
                    SGPAID = table.Column<string>(nullable: false),
                    SGPAValue = table.Column<double>(nullable: true),
                    AcademicYearID = table.Column<string>(nullable: true),
                    StudentID = table.Column<string>(nullable: true),
                    SemesterID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SGPA", x => x.SGPAID);
                    table.ForeignKey(
                        name: "FK_SGPA_AcademicYear_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SGPA_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SGPA_AspNetUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YGPA",
                columns: table => new
                {
                    YGPAID = table.Column<string>(nullable: false),
                    YGPAValue = table.Column<string>(nullable: false),
                    StudentID = table.Column<string>(nullable: true),
                    AcademicYearID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YGPA", x => x.YGPAID);
                    table.ForeignKey(
                        name: "FK_YGPA_AcademicYear_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YGPA_AspNetUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paper",
                columns: table => new
                {
                    PaperID = table.Column<string>(nullable: false),
                    SemesterID = table.Column<string>(nullable: true),
                    AcademicYearID = table.Column<string>(nullable: true),
                    GPAID = table.Column<string>(nullable: true),
                    DegreeID = table.Column<string>(nullable: true),
                    StudentID = table.Column<string>(nullable: true),
                    SubjectModuleID = table.Column<string>(nullable: true),
                    GradeID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paper", x => x.PaperID);
                    table.ForeignKey(
                        name: "FK_Paper_AcademicYear_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paper_Degree_DegreeID",
                        column: x => x.DegreeID,
                        principalTable: "Degree",
                        principalColumn: "DegreeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paper_GPA_GPAID",
                        column: x => x.GPAID,
                        principalTable: "GPA",
                        principalColumn: "GPAID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paper_Grade_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grade",
                        principalColumn: "GradeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paper_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paper_AspNetUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paper_SubjectModule_SubjectModuleID",
                        column: x => x.SubjectModuleID,
                        principalTable: "SubjectModule",
                        principalColumn: "SubjectModuleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AcademicYear",
                columns: new[] { "AcademicYearID", "StartDate" },
                values: new object[,]
                {
                    { "3fevwefw34fe33", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3d3vevecdf", new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3fee33fe33", new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3dvevfve3ecdf", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "myud", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "myrfwfud", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "eveefweveum", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3d3emucdf", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ecj235332", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3rcd535c", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ec3fej232", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "veve353vv", new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3ffv35efe33", new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ee123472-f3ea-44a6-809f-1ca4fed6c16e", "49723812-b59e-4389-8a0a-a0c34d1f9c98", "Admin", null },
                    { "a24781ff-029a-4e92-8cc4-c8e6dd9f01c9", "165d61bb-eaae-455a-b73e-12328f40e26b", "HOD", null },
                    { "ac4c06af-716e-4cd1-a39c-49672105ff7c", "a4a9e6e0-d4b6-4b67-add6-9ff220d97cd7", "Staff", null },
                    { "7ab7df3c-21fc-4881-b136-6672746bb456", "6c6bf673-79b5-43d8-a0c1-7c1336b78f9a", "Student", null }
                });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "FacultyID", "FacultyName" },
                values: new object[,]
                {
                    { "42f4f34", "Built Environment and Spatial Sciences " },
                    { "kddef43f3di3322", "Research and Development" },
                    { "34f", "Medicine" },
                    { "23df2", "Computing" },
                    { "432rf2", "Engineerings" },
                    { "343d3rdf", "Graduate Studies" },
                    { "2d3d", "Defence Studies and Strategic Studies" },
                    { "423f2", "Law " }
                });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "GradeID", "CreditValue", "FinalMarks", "GradeName", "SemesterID", "SubjectModuleID" },
                values: new object[,]
                {
                    { "afg4t54", 0.0, "ES <35", "Ie", null, null },
                    { "432txgfge", 0.0, "Excused", "Ex", null, null },
                    { "232fgfd", 0.0, "Absent", "Ab", null, null },
                    { "43gfsdfgt", 0.0, "Not eligible", "Ne", null, null },
                    { "43frg", 0.0, "Both ES & CA < 35", "Ib", null, null },
                    { "43f3d", 0.0, "PBCA <35%", "Ia", null, null },
                    { "67j6j", 0.0, "CA < 35", "Ia", null, null },
                    { "54gfge", 1.3, "35 –39", "D+", null, null },
                    { "3r3f", 4.0, "75 –84", "A", null, null },
                    { "56h56hbyg", 2.7000000000000002, "45 –49", "C", null, null },
                    { "6h6h5b", 2.2999999999999998, "50 –54", "C+", null, null },
                    { "re43", 2.7000000000000002, "55 –59", "B-", null, null },
                    { "3ff3f", 3.0, "60 –64", "B", null, null },
                    { "3f3f3", 3.2999999999999998, "65 –69", "B+", null, null },
                    { "wff33f", 3.7000000000000002, "70 –74", "A-", null, null },
                    { "iiu2983", 4.2000000000000002, "85 –100", "A+", null, null },
                    { "dfg5445gtf", 1.7, "40 –44", "C-", null, null }
                });

            migrationBuilder.InsertData(
                table: "Intake",
                columns: new[] { "IntakeID", "IntakeNumber" },
                values: new object[,]
                {
                    { "fvghwt", 31 },
                    { "oi765", 32 },
                    { "4u23v", 33 },
                    { "432vuv", 34 },
                    { "43t65il", 35 },
                    { "hjv32b", 39 },
                    { "53hb53", 37 },
                    { "jbk43l", 38 },
                    { "wde3", 40 },
                    { "g423hfvy", 30 },
                    { "k5j34b3i", 36 },
                    { "2jg3vrf", 29 }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentID", "DepartmentName", "FacultyID" },
                values: new object[,]
                {
                    { "3vr3q", "Computational Mathematics", "23df2" },
                    { "gerger", "Civil Engineering", "432rf2" },
                    { "rtebt", "Electronic & Telecommunication Engineering", "432rf2" },
                    { "3jkfqa", "Mathematics", "432rf2" },
                    { "dwdw3", "Aeronautical Engineering", "432rf2" },
                    { "312ju3dfn", "Marine engineering", "432rf2" },
                    { "3dfde3", "Information Technology", "23df2" },
                    { "qdw", "Computer Science", "23df2" },
                    { "dw22d", "Mechanical Engineering", "432rf2" },
                    { "32rfrv", "Computer Engineering", "23df2" }
                });

            migrationBuilder.InsertData(
                table: "Semester",
                columns: new[] { "SemesterID", "AcademicYearID", "SemesterName", "SemesterNumber" },
                values: new object[,]
                {
                    { "j4kb52", "3dvevfve3ecdf", "Semester 01", 1 },
                    { "54y54gh", "3fevwefw34fe33", "Semester 02", 2 },
                    { "h2b45j", "3fevwefw34fe33", "Semester 01", 1 },
                    { "54yh6ht", "3d3vevecdf", "Semester 02", 2 },
                    { "hb4325kb", "3d3vevecdf", "Semester 01", 1 },
                    { "54hfrth", "3fee33fe33", "Semester 02", 2 },
                    { "2b34jkbh", "3fee33fe33", "Semester 01", 1 },
                    { "tre5554", "3dvevfve3ecdf", "Semester 02", 2 },
                    { "drz5", "3ffv35efe33", "Semester 02", 2 },
                    { "h2bg5e45j", "veve353vv", "Semester 02", 2 },
                    { "34fr4", "myud", "Semester 02", 2 },
                    { "d33", "myrfwfud", "Semester 01", 1 },
                    { "h2b4f4f4fw5j", "myrfwfud", "Semester 02", 2 },
                    { "f3f3rfr", "eveefweveum", "Semester 01", 1 },
                    { "43ff34cr", "eveefweveum", "Semester 02", 2 },
                    { "j4n343", "3d3emucdf", "Semester 01", 1 },
                    { "5bhi23", "3ffv35efe33", "Semester 01", 1 },
                    { "fw43", "3d3emucdf", "Semester 02", 2 },
                    { "h2bcf34f45j", "ecj235332", "Semester 02", 2 },
                    { "b32briu45", "3rcd535c", "Semester 01", 1 },
                    { "h2b54gb45j", "3rcd535c", "Semester 02", 2 },
                    { "b3i24iu42", "ec3fej232", "Semester 01", 1 },
                    { "5egz", "ec3fej232", "Semester 02", 2 },
                    { "54b64", "veve353vv", "Semester 01", 1 },
                    { "hjh4334432", "ecj235332", "Semester 01", 1 },
                    { "kjei3322", "myud", "Semester 01", 1 }
                });

            migrationBuilder.InsertData(
                table: "Degree",
                columns: new[] { "DegreeID", "DegreeCode", "DegreeName", "DepartmentID", "NumOfYears" },
                values: new object[,]
                {
                    { "ddwd232", "IT", "BSc Information Technology", "3dfde3", 4 },
                    { "nu654", "IS", "BSc Information System", "3dfde3", 4 },
                    { "64nhf", "CS", "BSc Computer Science", "qdw", 4 },
                    { "ol433", "SE", "BSc Software Engineering", "qdw", 4 },
                    { "234fsg", "CE", "BSc Computer Engineering", "32rfrv", 4 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DegreeID", "DepartmentID", "Email", "EmailConfirmed", "FacultyID", "FirstName", "IntakeID", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegNum", "SecurityStamp", "SubjectModuleID", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[,]
                {
                    { "00d001c2-1cc5-4c5a-a7a7-c1b08ba1dbfd", 0, "7a4e3c9a-406a-424c-ab38-d081219c83d1", "ddwd232", "3dfde3", "admin@gmail.com", false, "23df2", "Bimsara", "43t65il", "Gunarathna", true, null, "ADMIN@GMAIL.COM", "admin@gmail.com", "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", null, false, "D/IT/18/0067", "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", null, false, "admin@gmail.com", 1 },
                    { "db21789e-676b-4951-bd14-81c2aa2d1d07", 0, "7a4e3c9a-406a-424c-ab38-d081219c83d1", "ddwd232", "3dfde3", "student@gmail.com", false, "23df2", "Bimsara", "43t65il", "Gunarathna", true, null, "STUDENT@GMAIL.COM", "student@gmail.com", "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", null, false, "D/IT/18/0067", "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", null, false, "student@gmail.com", 4 },
                    { "c02e3dc9-bab3-4ebe-8b86-50611f6baca0", 0, "7a4e3c9a-406a-424c-ab38-d081219c83d1", "ol433", "qdw", "staff@gmail.com", false, "23df2", "Harry", "k5j34b3i", "Potter", true, null, "STAFF@GMAIL.COM", "staff@gmail.com", "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", null, false, "D/IS/18/0015", "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", null, false, "staff@gmail.com", 2 },
                    { "e83efdea-d974-413f-a2d7-410c371cdb7c", 0, "7a4e3c9a-406a-424c-ab38-d081219c83d1", "ol433", "qdw", "hod@gmail.com", false, "23df2", "Elon", "k5j34b3i", "Musk", true, null, "HOD@GMAIL.COM", "hod@gmail.com", "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", null, false, "D/SE/18/0067", "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", null, false, "hod@gmail.com", 3 }
                });

            migrationBuilder.InsertData(
                table: "SubjectModule",
                columns: new[] { "SubjectModuleID", "DegreeID", "SubjectModuleCode", "SubjectModuleCreditUnit", "SubjectModuleName" },
                values: new object[,]
                {
                    { "fwf", "ddwd232", "MF1023", 2, "Principles of Management" },
                    { "efwfw", "ddwd232", "IT1043", 3, "Fundamentals of Computer System " },
                    { "3dfkujt6de3", "ddwd232", "IT1022", 2, "Information Technology Concepts " },
                    { "4h4geg", "ddwd232", "IT1033", 3, "Fundamentals of Computer Programming" },
                    { "bfdg5443y", "ddwd232", "IT1062", 2, "Fundamentals of Visual Computing" },
                    { "vfg5", "ddwd232", "CM1043", 3, "Mathematics for IT - 1" },
                    { "54h545", "ddwd232", "IT2013", 3, "Computer Systems Architecture" },
                    { "r4rfgre", "ddwd232", "IT2033", 3, "Object Oriented Programming " },
                    { "4gervf", "ddwd232", "IT2043", 3, "System Analysis & Designing" },
                    { "23ftgw4t5", "ddwd232", "IT2053", 3, "Fundamentals of DBMS" },
                    { "657j5j", "ddwd232", "IT2072", 2, "Visual Computing Project (Group)" },
                    { "th45hr", "ddwd232", "CM2052", 2, "Probability and Statistics" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "00d001c2-1cc5-4c5a-a7a7-c1b08ba1dbfd", "ee123472-f3ea-44a6-809f-1ca4fed6c16e" },
                    { "db21789e-676b-4951-bd14-81c2aa2d1d07", "7ab7df3c-21fc-4881-b136-6672746bb456" },
                    { "c02e3dc9-bab3-4ebe-8b86-50611f6baca0", "ac4c06af-716e-4cd1-a39c-49672105ff7c" },
                    { "e83efdea-d974-413f-a2d7-410c371cdb7c", "a24781ff-029a-4e92-8cc4-c8e6dd9f01c9" }
                });

            migrationBuilder.InsertData(
                table: "Paper",
                columns: new[] { "PaperID", "AcademicYearID", "DegreeID", "GPAID", "GradeID", "SemesterID", "StudentID", "SubjectModuleID" },
                values: new object[,]
                {
                    { "hjwbu232332", "myud", "ddwd232", null, "wff33f", "kjei3322", "db21789e-676b-4951-bd14-81c2aa2d1d07", "23ftgw4t5" },
                    { "jbwfwi3t3223", "myud", "ddwd232", null, "3r3f", "kjei3322", "db21789e-676b-4951-bd14-81c2aa2d1d07", "657j5j" },
                    { "ej32i1123", "myud", "ddwd232", null, "iiu2983", "kjei3322", "db21789e-676b-4951-bd14-81c2aa2d1d07", "th45hr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DegreeID",
                table: "AspNetUsers",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentID",
                table: "AspNetUsers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FacultyID",
                table: "AspNetUsers",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IntakeID",
                table: "AspNetUsers",
                column: "IntakeID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SubjectModuleID",
                table: "AspNetUsers",
                column: "SubjectModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Degree_DepartmentID",
                table: "Degree",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyID",
                table: "Department",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_GPA_AcademicYearID",
                table: "GPA",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_GPA_SemesterID",
                table: "GPA",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_GPA_StudentID",
                table: "GPA",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_GPA_SubjectModuleID",
                table: "GPA",
                column: "SubjectModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SemesterID",
                table: "Grade",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SubjectModuleID",
                table: "Grade",
                column: "SubjectModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Paper_AcademicYearID",
                table: "Paper",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Paper_DegreeID",
                table: "Paper",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_Paper_GPAID",
                table: "Paper",
                column: "GPAID");

            migrationBuilder.CreateIndex(
                name: "IX_Paper_GradeID",
                table: "Paper",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_Paper_SemesterID",
                table: "Paper",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_Paper_StudentID",
                table: "Paper",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Paper_SubjectModuleID",
                table: "Paper",
                column: "SubjectModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_AcademicYearID",
                table: "Semester",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_SGPA_AcademicYearID",
                table: "SGPA",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_SGPA_SemesterID",
                table: "SGPA",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_SGPA_StudentID",
                table: "SGPA",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectModule_DegreeID",
                table: "SubjectModule",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_YGPA_AcademicYearID",
                table: "YGPA",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_YGPA_StudentID",
                table: "YGPA",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Paper");

            migrationBuilder.DropTable(
                name: "SGPA");

            migrationBuilder.DropTable(
                name: "YGPA");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "GPA");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Intake");

            migrationBuilder.DropTable(
                name: "SubjectModule");

            migrationBuilder.DropTable(
                name: "AcademicYear");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}