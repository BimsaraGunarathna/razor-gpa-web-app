using System;
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
                    SemesterName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.SemesterID);
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
                    GPAValue = table.Column<double>(nullable: false),
                    SemesterID = table.Column<string>(nullable: true),
                    AcademicYearID = table.Column<string>(nullable: true),
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
                    { "026496c1-5a69-4b91-81e8-40b127004017", "4a959ebe-f7a9-4b53-aa44-9124284aed14", "Admin", null },
                    { "7a738faa-0e16-49a0-b977-614bbba4bb98", "27d3f305-c260-4061-b753-4fc504b5ac21", "HOD", null },
                    { "74d4b42e-eafa-448e-a760-eaa9f781e710", "a4d266c0-f9b9-4cda-8998-16f66c563c68", "Staff", null },
                    { "e5df59c9-caaa-4848-a36f-0916292535fe", "1fbd986b-ccb2-4997-8c06-6021b8203ab9", "Student", null }
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
                    { "6h6h5b", 2.2999999999999998, "50 –54", "C+", null, null },
                    { "56h56hbyg", 2.7000000000000002, "45 –49", "C", null, null },
                    { "re43", 2.7000000000000002, "55 –59", "B-", null, null },
                    { "3ff3f", 3.0, "60 –64", "B", null, null },
                    { "3f3f3", 3.2999999999999998, "65 –69", "B+", null, null },
                    { "wff33f", 3.7000000000000002, "70 –74", "A-", null, null },
                    { "3r3f", 4.0, "75 –84", "A", null, null },
                    { "iiu2983", 4.2000000000000002, "85 –100", "A+", null, null },
                    { "dfg5445gtf", 1.7, "40 –44", "C-", null, null }
                });

            migrationBuilder.InsertData(
                table: "Intake",
                columns: new[] { "IntakeID", "IntakeNumber" },
                values: new object[,]
                {
                    { "2jg3vrf", 29 },
                    { "g423hfvy", 30 },
                    { "fvghwt", 31 },
                    { "oi765", 32 },
                    { "4u23v", 33 },
                    { "432vuv", 34 },
                    { "k5j34b3i", 36 },
                    { "53hb53", 37 },
                    { "jbk43l", 38 },
                    { "hjv32b", 39 },
                    { "wde3", 40 },
                    { "43t65il", 35 }
                });

            migrationBuilder.InsertData(
                table: "Semester",
                columns: new[] { "SemesterID", "SemesterName", "SemesterNumber" },
                values: new object[,]
                {
                    { "9", "Semester 9", 9 },
                    { "1", "Semester 1", 1 },
                    { "2", "Semester 2", 2 },
                    { "3", "Semester 3", 3 },
                    { "4", "Semester 4", 4 },
                    { "5", "Semester 5", 5 },
                    { "6", "Semester 6", 6 },
                    { "7", "Semester 7", 7 },
                    { "8", "Semester 8", 8 },
                    { "10", "Semester 10", 10 }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentID", "DepartmentName", "FacultyID" },
                values: new object[,]
                {
                    { "dwdw3", "Aeronautical Engineering", "432rf2" },
                    { "gerger", "Civil Engineering", "432rf2" },
                    { "rtebt", "Electronic & Telecommunication Engineering", "432rf2" },
                    { "3jkfqa", "Mathematics", "432rf2" },
                    { "dw22d", "Mechanical Engineering", "432rf2" },
                    { "312ju3dfn", "Marine engineering", "432rf2" },
                    { "3dfde3", "Information Technology", "23df2" },
                    { "qdw", "Computer Science", "23df2" },
                    { "32rfrv", "Computer Engineering", "23df2" },
                    { "3vr3q", "Computational Mathematics", "23df2" }
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
                    { "888a1fba-8f3a-4c0e-87d4-a8bb8ef5d1f9", 0, "7a4e3c9a-406a-424c-ab38-d081219c83d1", "ddwd232", "3dfde3", "admin@gmail.com", false, "23df2", "Bimsara", "43t65il", "Gunarathna", true, null, "ADMIN@GMAIL.COM", "admin@gmail.com", "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", null, false, "admin", "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", null, false, "admin@gmail.com", 1 },
                    { "b19f212c-a171-499f-ad5f-3f1480c3e742", 0, "7a4e3c9a-406a-424c-ab38-d081219c83d1", "ddwd232", "3dfde3", "student@gmail.com", false, "23df2", "Bimsara", "43t65il", "Gunarathna", true, null, "STUDENT@GMAIL.COM", "student@gmail.com", "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", null, false, "student", "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", null, false, "student@gmail.com", 4 },
                    { "c87a9ef6-5632-4215-8568-659a5014b6ef", 0, "7a4e3c9a-406a-424c-ab38-d081219c83d1", "ol433", "3dfde3", "staff@gmail.com", false, "23df2", "Harry", "k5j34b3i", "Potter", true, null, "STAFF@GMAIL.COM", "staff@gmail.com", "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", null, false, "staff", "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", null, false, "staff@gmail.com", 2 },
                    { "75ec5121-3575-4ac7-b037-2ad087bdbf3e", 0, "7a4e3c9a-406a-424c-ab38-d081219c83d1", "ol433", "3dfde3", "hod@gmail.com", false, "23df2", "Elon", "k5j34b3i", "Musk", true, null, "HOD@GMAIL.COM", "hod@gmail.com", "AQAAAAEAACcQAAAAEEN4Kep2mGX6mwUcQoNQgR18i6dXRQ1cLQ1k8bSIvikpEa3+b7sJidXa2tYEPREn2Q==", null, false, "hod", "WTYLCK3GBRNTTRTQIBHNKLMNLSRSBJJU", null, false, "hod@gmail.com", 3 }
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
                    { "888a1fba-8f3a-4c0e-87d4-a8bb8ef5d1f9", "026496c1-5a69-4b91-81e8-40b127004017" },
                    { "b19f212c-a171-499f-ad5f-3f1480c3e742", "e5df59c9-caaa-4848-a36f-0916292535fe" },
                    { "c87a9ef6-5632-4215-8568-659a5014b6ef", "74d4b42e-eafa-448e-a760-eaa9f781e710" },
                    { "75ec5121-3575-4ac7-b037-2ad087bdbf3e", "7a738faa-0e16-49a0-b977-614bbba4bb98" }
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
                name: "Grade");

            migrationBuilder.DropTable(
                name: "AcademicYear");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Intake");

            migrationBuilder.DropTable(
                name: "SubjectModule");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
