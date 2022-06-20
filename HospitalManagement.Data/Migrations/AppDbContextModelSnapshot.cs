﻿// <auto-generated />
using System;
using HospitalManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalManagement.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HospitalManagement.Domain.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegisterationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppUser");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DoctorId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PatientId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId1");

                    b.HasIndex("PatientId1");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentInitials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7da11ee0-2519-493f-816a-ba6f46aacb74"),
                            CreatedAt = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(1005),
                            DepartmentInitials = "OTP",
                            DepartmentNumber = "OTP-1122334455",
                            Description = "This section of the hospital caters for patients that require medical attention but are notrequired to be admitted are treated",
                            ModifiedOn = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(1016),
                            Name = "Outpatient Department"
                        },
                        new
                        {
                            Id = new Guid("7cd042ca-c443-4067-91c1-6d1df0fad8d5"),
                            CreatedAt = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2471),
                            DepartmentInitials = "INP",
                            DepartmentNumber = "INP-1122334466",
                            Description = "This section of the hospital caters for patients that are required to be admitted for at least one night",
                            ModifiedOn = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2474),
                            Name = "Inpatient Department"
                        },
                        new
                        {
                            Id = new Guid("368faff2-f91f-4de3-a9b9-ac6e659ced57"),
                            CreatedAt = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2484),
                            DepartmentInitials = "PHY",
                            DepartmentNumber = "PHY-1122334477",
                            Description = "This section of the hospital contains all the doctors in the hospital",
                            ModifiedOn = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2485),
                            Name = "Physicians Department"
                        },
                        new
                        {
                            Id = new Guid("a0a2e6c6-3fee-46dc-a87e-dcb215029e93"),
                            CreatedAt = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2487),
                            DepartmentInitials = "NUR",
                            DepartmentNumber = "NUR-1122334488",
                            Description = "This section of the hospital contains all the nurses in the hospital",
                            ModifiedOn = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2488),
                            Name = "Nursing Department"
                        },
                        new
                        {
                            Id = new Guid("12757ffa-ab81-4a23-b3a1-4f3fc169ec53"),
                            CreatedAt = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2490),
                            DepartmentInitials = "PHM",
                            DepartmentNumber = "PHM-1122334499",
                            Description = "This section of the hospital contains all the pharmacists in the hospital",
                            ModifiedOn = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2491),
                            Name = "Pharmarcy Department"
                        },
                        new
                        {
                            Id = new Guid("501c0200-3c6d-48c7-8b6e-964a87f0c290"),
                            CreatedAt = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2494),
                            DepartmentInitials = "MLA",
                            DepartmentNumber = "MLA-1122335511",
                            Description = "This section of the hospital contains all the laboratory scientists and radiologists in the hospital",
                            ModifiedOn = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2495),
                            Name = "Medical Laboratory Department"
                        },
                        new
                        {
                            Id = new Guid("295d3a0c-992c-4dfb-bcc2-e26fb6f9b4b8"),
                            CreatedAt = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2497),
                            DepartmentInitials = "ACC",
                            DepartmentNumber = "ACC-1122335522",
                            Description = "This section of the hospital contains all the accountants in the hospital",
                            ModifiedOn = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2497),
                            Name = "Accounts Department"
                        },
                        new
                        {
                            Id = new Guid("91c4ebd1-33ae-4ef2-aeee-1d12e01d3dfb"),
                            CreatedAt = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2499),
                            DepartmentInitials = "RCD",
                            DepartmentNumber = "RCD-1122335533",
                            Description = "This section of the hospital is tasked with managing all the records in the hospital",
                            ModifiedOn = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2500),
                            Name = "Records Department"
                        },
                        new
                        {
                            Id = new Guid("55ccc95d-caac-44fe-b3ee-8830184ee9b5"),
                            CreatedAt = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2502),
                            DepartmentInitials = "JNT",
                            DepartmentNumber = "JNT-1122335544",
                            Description = "This section of the hospital contains all the maintenance and cleaning staff in the hospital",
                            ModifiedOn = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2503),
                            Name = "Janitorial Department"
                        },
                        new
                        {
                            Id = new Guid("2b212064-c708-44fd-a49a-6d138cdded37"),
                            CreatedAt = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2505),
                            DepartmentInitials = "SEC",
                            DepartmentNumber = "SEC-1122335566",
                            Description = "This section of the hospital contains all the security officers in the hospital",
                            ModifiedOn = new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2506),
                            Name = "Security Department"
                        });
                });

            modelBuilder.Entity("HospitalManagement.Domain.Models.Drug", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Models.DrugOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DrugId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StaffId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DrugId");

                    b.HasIndex("StaffId");

                    b.ToTable("DrugOrders");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Models.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "27fb1887-cf6f-45d8-83d1-c501d6054fd3",
                            ConcurrencyStamp = "662dc9fd-42f0-43e5-856e-11b33f781c52",
                            Name = "Staff",
                            NormalizedName = "STAFF"
                        },
                        new
                        {
                            Id = "5af1f3a1-f7f9-4ad0-b757-cda796199def",
                            ConcurrencyStamp = "a024a0f1-fb48-41cc-9990-cc9e7c26c988",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "67228962-a44c-49a6-b89b-395dd92cf75a",
                            ConcurrencyStamp = "953f8c38-d3d8-42b0-86d6-4f9ab88d046e",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = "a1ff4611-dc37-4a8e-af8e-73e764fc8676",
                            ConcurrencyStamp = "72c0279c-d2b7-4fc3-bf35-dddc0b149d03",
                            Name = "Patient",
                            NormalizedName = "PATIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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

                    b.HasData(
                        new
                        {
                            UserId = "300ddf19-95e6-4744-83e6-2aa5e1d444c0",
                            RoleId = "67228962-a44c-49a6-b89b-395dd92cf75a"
                        },
                        new
                        {
                            UserId = "300ddf19-95e6-4744-83e6-2aa5e1d444c0",
                            RoleId = "27fb1887-cf6f-45d8-83d1-c501d6054fd3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Models.Patient", b =>
                {
                    b.HasBaseType("HospitalManagement.Domain.Models.AppUser");

                    b.Property<int>("BloodGroup")
                        .HasColumnType("int");

                    b.Property<int>("Genotype")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Models.Staff", b =>
                {
                    b.HasBaseType("HospitalManagement.Domain.Models.AppUser");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DepartmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DepartmentId");

                    b.HasDiscriminator().HasValue("Staff");

                    b.HasData(
                        new
                        {
                            Id = "300ddf19-95e6-4744-83e6-2aa5e1d444c0",
                            AccessFailedCount = 0,
                            Address = "Hospital Management Location",
                            ConcurrencyStamp = "c943866f-c69b-4827-9c0a-dc2924631f72",
                            Email = "admin@hospitalManagement.com",
                            EmailConfirmed = true,
                            FirstName = "Hospital",
                            IdentificationNumber = "ST-1001123355",
                            IsActive = true,
                            LastName = "Admin",
                            LockoutEnabled = false,
                            MiddleName = "Default",
                            ModifiedOn = new DateTime(2022, 6, 20, 12, 22, 14, 742, DateTimeKind.Utc).AddTicks(7410),
                            NormalizedEmail = "ADMIN@HOSPITALMANAGEMENT.COM",
                            NormalizedUserName = "ADMIN@HOSPITALMANAGEMENT.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMs5mEnyNG8OVrzh81QA9l9NUZoPhHuUCtKj9t9Au+lR9VHRaXISzUgswvxy885XVw==",
                            PhoneNumber = "+2348064879196",
                            PhoneNumberConfirmed = true,
                            RegisterationDate = new DateTime(2022, 6, 20, 12, 22, 14, 742, DateTimeKind.Utc).AddTicks(7396),
                            SecurityStamp = "e72e4190-6131-4d1b-af37-04bde4c84f09",
                            Sex = 0,
                            TwoFactorEnabled = false,
                            UserName = "admin@hospitalManagement.com",
                            DepartmentId = new Guid("2b212064-c708-44fd-a49a-6d138cdded37"),
                            DepartmentNumber = "SEC-1122335566"
                        });
                });

            modelBuilder.Entity("HospitalManagement.Domain.Models.Doctor", b =>
                {
                    b.HasBaseType("HospitalManagement.Domain.Models.Staff");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Models.Appointment", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId1");

                    b.HasOne("HospitalManagement.Domain.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId1");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Models.DrugOrder", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Models.Drug", "Drug")
                        .WithMany()
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Domain.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId");

                    b.Navigation("Drug");

                    b.Navigation("Staff");
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
                    b.HasOne("HospitalManagement.Domain.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Models.AppUser", null)
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

                    b.HasOne("HospitalManagement.Domain.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalManagement.Domain.Models.Staff", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
