﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using razor_gpa_web_app.Data;

namespace razor_gpa_web_app.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20201022091734_Mig09")]
    partial class Mig09
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("gpa_system.Models.Department", b =>
                {
                    b.Property<string>("DepartmentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("gpa_system.Models.SGPA", b =>
                {
                    b.Property<string>("SGPAID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SGPAValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SemesterID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearID1")
                        .HasColumnType("int");

                    b.HasKey("SGPAID");

                    b.HasIndex("SemesterID");

                    b.HasIndex("YearID1");

                    b.ToTable("SGPA");
                });

            modelBuilder.Entity("gpa_system.Models.SubjectModule", b =>
                {
                    b.Property<string>("SubjectModuleID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DegreeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DegreeID1")
                        .HasColumnType("int");

                    b.Property<string>("SubjectModuleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectModuleID");

                    b.HasIndex("DegreeID1");

                    b.ToTable("SubjectModule");
                });

            modelBuilder.Entity("razor_gpa_web_app.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DegreeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Faculty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Intake")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RegNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("razor_gpa_web_app.Models.Degree", b =>
                {
                    b.Property<int>("DegreeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DegreeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("DegreeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DepartmentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumOfYears")
                        .HasColumnType("int");

                    b.Property<string>("facultyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("DegreeID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Degree");
                });

            modelBuilder.Entity("razor_gpa_web_app.Models.GPA", b =>
                {
                    b.Property<string>("GPAID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("GPAValue")
                        .HasColumnType("float");

                    b.Property<string>("SemesterID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectModuleID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("YearID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearID1")
                        .HasColumnType("int");

                    b.HasKey("GPAID");

                    b.HasIndex("SemesterID");

                    b.HasIndex("SubjectModuleID");

                    b.HasIndex("YearID1");

                    b.ToTable("GPA");
                });

            modelBuilder.Entity("razor_gpa_web_app.Models.Grade", b =>
                {
                    b.Property<string>("GradeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DegreeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DegreeID1")
                        .HasColumnType("int");

                    b.Property<string>("GPAID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("GradeChar")
                        .HasColumnType("int");

                    b.Property<string>("SemesterID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradeID");

                    b.HasIndex("DegreeID1");

                    b.HasIndex("GPAID");

                    b.HasIndex("SemesterID");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("razor_gpa_web_app.Models.Semester", b =>
                {
                    b.Property<string>("SemesterID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SemesterNumber")
                        .HasColumnType("int");

                    b.Property<int>("YearID")
                        .HasColumnType("int");

                    b.HasKey("SemesterID");

                    b.HasIndex("YearID");

                    b.ToTable("Semester");
                });

            modelBuilder.Entity("razor_gpa_web_app.Models.Year", b =>
                {
                    b.Property<int>("YearID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("YearNumber")
                        .HasColumnType("datetime2");

                    b.HasKey("YearID");

                    b.ToTable("Year");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("razor_gpa_web_app.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("razor_gpa_web_app.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("razor_gpa_web_app.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("razor_gpa_web_app.Areas.Identity.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("gpa_system.Models.SGPA", b =>
                {
                    b.HasOne("razor_gpa_web_app.Models.Semester", "Semester")
                        .WithMany("SGPAs")
                        .HasForeignKey("SemesterID");

                    b.HasOne("razor_gpa_web_app.Models.Year", "Year")
                        .WithMany("SGPAs")
                        .HasForeignKey("YearID1");
                });

            modelBuilder.Entity("gpa_system.Models.SubjectModule", b =>
                {
                    b.HasOne("razor_gpa_web_app.Models.Degree", "Degree")
                        .WithMany()
                        .HasForeignKey("DegreeID1");
                });

            modelBuilder.Entity("razor_gpa_web_app.Models.Degree", b =>
                {
                    b.HasOne("gpa_system.Models.Department", "Department")
                        .WithMany("Degrees")
                        .HasForeignKey("DepartmentID");
                });

            modelBuilder.Entity("razor_gpa_web_app.Models.GPA", b =>
                {
                    b.HasOne("razor_gpa_web_app.Models.Semester", "Semester")
                        .WithMany("GPAs")
                        .HasForeignKey("SemesterID");

                    b.HasOne("gpa_system.Models.SubjectModule", "SubjectModule")
                        .WithMany("GPAs")
                        .HasForeignKey("SubjectModuleID");

                    b.HasOne("razor_gpa_web_app.Models.Year", "Year")
                        .WithMany("GPAs")
                        .HasForeignKey("YearID1");
                });

            modelBuilder.Entity("razor_gpa_web_app.Models.Grade", b =>
                {
                    b.HasOne("razor_gpa_web_app.Models.Degree", "Degree")
                        .WithMany("Grades")
                        .HasForeignKey("DegreeID1");

                    b.HasOne("razor_gpa_web_app.Models.GPA", "GPA")
                        .WithMany("Grades")
                        .HasForeignKey("GPAID");

                    b.HasOne("razor_gpa_web_app.Models.Semester", "Semester")
                        .WithMany("Grades")
                        .HasForeignKey("SemesterID");
                });

            modelBuilder.Entity("razor_gpa_web_app.Models.Semester", b =>
                {
                    b.HasOne("razor_gpa_web_app.Models.Year", "Year")
                        .WithMany("Semesters")
                        .HasForeignKey("YearID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
