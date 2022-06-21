﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementData.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentInitials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<int>(type: "int", nullable: true),
                    Genotype = table.Column<int>(type: "int", nullable: true),
                    DepartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_DoctorId1",
                        column: x => x.DoctorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27fb1887-cf6f-45d8-83d1-c501d6054fd3", "7a2ef114-ec3e-4491-94e4-14020a57cdd3", "Staff", "STAFF" },
                    { "5af1f3a1-f7f9-4ad0-b757-cda796199def", "6a934e68-742b-42b8-ab71-d847a960ab75", "Administrator", "ADMINISTRATOR" },
                    { "67228962-a44c-49a6-b89b-395dd92cf75a", "3bf2cf5e-bc62-4a5f-a4a9-873ceb42eb92", "SuperAdmin", "SUPERADMIN" },
                    { "a1ff4611-dc37-4a8e-af8e-73e764fc8676", "3bcc2a4c-7572-42c1-b3aa-6297572b8870", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "DepartmentInitials", "DepartmentNumber", "Description", "ModifiedOn", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("7da11ee0-2519-493f-816a-ba6f46aacb74"), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(5635), "OTP", "OTP-1122334455", "This section of the hospital caters for patients that require medical attention but are notrequired to be admitted are treated", new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(5644), "Outpatient Department", 1 },
                    { new Guid("7cd042ca-c443-4067-91c1-6d1df0fad8d5"), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6859), "INP", "INP-1122334466", "This section of the hospital caters for patients that are required to be admitted for at least one night", new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6861), "Inpatient Department", 1 },
                    { new Guid("368faff2-f91f-4de3-a9b9-ac6e659ced57"), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6871), "PHY", "PHY-1122334477", "This section of the hospital contains all the doctors in the hospital", new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6871), "Physicians Department", 1 },
                    { new Guid("a0a2e6c6-3fee-46dc-a87e-dcb215029e93"), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6874), "NUR", "NUR-1122334488", "This section of the hospital contains all the nurses in the hospital", new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6875), "Nursing Department", 1 },
                    { new Guid("12757ffa-ab81-4a23-b3a1-4f3fc169ec53"), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6877), "PHM", "PHM-1122334499", "This section of the hospital contains all the pharmacists in the hospital", new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6878), "Pharmarcy Department", 1 },
                    { new Guid("501c0200-3c6d-48c7-8b6e-964a87f0c290"), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6880), "MLA", "MLA-1122335511", "This section of the hospital contains all the laboratory scientists and radiologists in the hospital", new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6881), "Medical Laboratory Department", 1 },
                    { new Guid("295d3a0c-992c-4dfb-bcc2-e26fb6f9b4b8"), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6883), "ACC", "ACC-1122335522", "This section of the hospital contains all the accountants in the hospital", new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6883), "Accounts Department", 1 },
                    { new Guid("91c4ebd1-33ae-4ef2-aeee-1d12e01d3dfb"), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6885), "RCD", "RCD-1122335533", "This section of the hospital is tasked with managing all the records in the hospital", new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6886), "Records Department", 1 },
                    { new Guid("55ccc95d-caac-44fe-b3ee-8830184ee9b5"), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6888), "JNT", "JNT-1122335544", "This section of the hospital contains all the maintenance and cleaning staff in the hospital", new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6889), "Janitorial Department", 1 },
                    { new Guid("2b212064-c708-44fd-a49a-6d138cdded37"), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6891), "SEC", "SEC-1122335566", "This section of the hospital contains all the security officers in the hospital", new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6891), "Security Department", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DepartmentId", "DepartmentNumber", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IdentificationNumber", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisterationDate", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { "300ddf19-95e6-4744-83e6-2aa5e1d444c0", 0, "Hospital Management Location", "9fb57541-76ac-4a1f-a758-9acb409709e2", new Guid("2b212064-c708-44fd-a49a-6d138cdded37"), "SEC-1122335566", "Staff", "admin@hospitalManagement.com", true, "Hospital", "ST-1001123355", true, "Admin", false, null, "Default", new DateTime(2022, 6, 16, 12, 59, 59, 597, DateTimeKind.Utc).AddTicks(3313), "ADMIN@HOSPITALMANAGEMENT.COM", "ADMIN@HOSPITALMANAGEMENT.COM", "AQAAAAEAACcQAAAAEMjImwvbuNNTT6hvmjAsjWMdvTLnnRYwiH0fi0LkWbvle57C5EG/uMAJ4M03Qg18pQ==", "+2348064879196", true, new DateTime(2022, 6, 16, 12, 59, 59, 597, DateTimeKind.Utc).AddTicks(3309), "56affcef-44ea-472e-ab64-1ee478e0497f", 0, false, "admin@hospitalManagement.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "67228962-a44c-49a6-b89b-395dd92cf75a", "300ddf19-95e6-4744-83e6-2aa5e1d444c0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "27fb1887-cf6f-45d8-83d1-c501d6054fd3", "300ddf19-95e6-4744-83e6-2aa5e1d444c0" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId1",
                table: "Appointments",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId1",
                table: "Appointments",
                column: "PatientId1");

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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

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
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}