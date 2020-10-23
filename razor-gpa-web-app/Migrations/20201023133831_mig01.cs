using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace razor_gpa_web_app.Migrations
{
    public partial class mig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<string>(nullable: false),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: false),
                    FacultyName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    YearID = table.Column<string>(nullable: false),
                    YearNumber = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.YearID);
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
                name: "Degree",
                columns: table => new
                {
                    DegreeID = table.Column<string>(nullable: false),
                    DegreeName = table.Column<string>(maxLength: 50, nullable: false),
                    FacultyName = table.Column<string>(maxLength: 50, nullable: false),
                    DegreeCode = table.Column<string>(maxLength: 10, nullable: false),
                    NumOfYears = table.Column<int>(nullable: false),
                    DepartmentID = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true)
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
                    YearID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.SemesterID);
                    table.ForeignKey(
                        name: "FK_Semester_Year_YearID",
                        column: x => x.YearID,
                        principalTable: "Year",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModule",
                columns: table => new
                {
                    SubjectModuleID = table.Column<string>(nullable: false),
                    SubjectModuleName = table.Column<string>(maxLength: 60, nullable: false),
                    SubjectModuleCode = table.Column<string>(maxLength: 60, nullable: false),
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
                    DegreeName = table.Column<string>(nullable: true),
                    IntakeNumber = table.Column<int>(nullable: false),
                    FacultyName = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    UserRole = table.Column<int>(nullable: false),
                    DegreeID = table.Column<string>(nullable: true),
                    DepartmentID = table.Column<string>(nullable: true),
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
                        name: "FK_AspNetUsers_SubjectModule_SubjectModuleID",
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
                    YearID = table.Column<string>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_GPA_Year_YearID",
                        column: x => x.YearID,
                        principalTable: "Year",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SGPA",
                columns: table => new
                {
                    SGPAID = table.Column<string>(nullable: false),
                    SGPAValue = table.Column<double>(nullable: false),
                    YearID = table.Column<string>(nullable: true),
                    StudentID = table.Column<string>(nullable: true),
                    SemesterID = table.Column<string>(nullable: true)
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
                        name: "FK_SGPA_AspNetUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SGPA_Year_YearID",
                        column: x => x.YearID,
                        principalTable: "Year",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeID = table.Column<string>(nullable: false),
                    GradeChar = table.Column<int>(maxLength: 10, nullable: false),
                    SemesterID = table.Column<string>(nullable: true),
                    GPAID = table.Column<string>(nullable: true),
                    DegreeID = table.Column<string>(nullable: true),
                    StudentID = table.Column<string>(nullable: true),
                    SubjectModuleID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeID);
                    table.ForeignKey(
                        name: "FK_Grade_Degree_DegreeID",
                        column: x => x.DegreeID,
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
                    table.ForeignKey(
                        name: "FK_Grade_AspNetUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grade_SubjectModule_SubjectModuleID",
                        column: x => x.SubjectModuleID,
                        principalTable: "SubjectModule",
                        principalColumn: "SubjectModuleID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_GPA_YearID",
                table: "GPA",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_DegreeID",
                table: "Grade",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_GPAID",
                table: "Grade",
                column: "GPAID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SemesterID",
                table: "Grade",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentID",
                table: "Grade",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SubjectModuleID",
                table: "Grade",
                column: "SubjectModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_YearID",
                table: "Semester",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_SGPA_SemesterID",
                table: "SGPA",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_SGPA_StudentID",
                table: "SGPA",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_SGPA_YearID",
                table: "SGPA",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectModule_DegreeID",
                table: "SubjectModule",
                column: "DegreeID");
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
                name: "Grade");

            migrationBuilder.DropTable(
                name: "SGPA");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "GPA");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "SubjectModule");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
