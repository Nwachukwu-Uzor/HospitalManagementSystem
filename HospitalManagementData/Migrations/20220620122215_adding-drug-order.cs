using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementData.Migrations
{
    public partial class addingdrugorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Drugs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DrugOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugOrders_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrugOrders_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27fb1887-cf6f-45d8-83d1-c501d6054fd3",
                column: "ConcurrencyStamp",
                value: "662dc9fd-42f0-43e5-856e-11b33f781c52");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5af1f3a1-f7f9-4ad0-b757-cda796199def",
                column: "ConcurrencyStamp",
                value: "a024a0f1-fb48-41cc-9990-cc9e7c26c988");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67228962-a44c-49a6-b89b-395dd92cf75a",
                column: "ConcurrencyStamp",
                value: "953f8c38-d3d8-42b0-86d6-4f9ab88d046e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1ff4611-dc37-4a8e-af8e-73e764fc8676",
                column: "ConcurrencyStamp",
                value: "72c0279c-d2b7-4fc3-bf35-dddc0b149d03");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "300ddf19-95e6-4744-83e6-2aa5e1d444c0",
                columns: new[] { "ConcurrencyStamp", "ModifiedOn", "PasswordHash", "RegisterationDate", "SecurityStamp" },
                values: new object[] { "c943866f-c69b-4827-9c0a-dc2924631f72", new DateTime(2022, 6, 20, 12, 22, 14, 742, DateTimeKind.Utc).AddTicks(7410), "AQAAAAEAACcQAAAAEMs5mEnyNG8OVrzh81QA9l9NUZoPhHuUCtKj9t9Au+lR9VHRaXISzUgswvxy885XVw==", new DateTime(2022, 6, 20, 12, 22, 14, 742, DateTimeKind.Utc).AddTicks(7396), "e72e4190-6131-4d1b-af37-04bde4c84f09" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("12757ffa-ab81-4a23-b3a1-4f3fc169ec53"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2490), new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2491) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("295d3a0c-992c-4dfb-bcc2-e26fb6f9b4b8"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2497), new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2497) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2b212064-c708-44fd-a49a-6d138cdded37"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2505), new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("368faff2-f91f-4de3-a9b9-ac6e659ced57"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2484), new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("501c0200-3c6d-48c7-8b6e-964a87f0c290"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2494), new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2495) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("55ccc95d-caac-44fe-b3ee-8830184ee9b5"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2502), new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2503) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7cd042ca-c443-4067-91c1-6d1df0fad8d5"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2471), new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2474) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7da11ee0-2519-493f-816a-ba6f46aacb74"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(1005), new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(1016) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("91c4ebd1-33ae-4ef2-aeee-1d12e01d3dfb"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2499), new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2500) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("a0a2e6c6-3fee-46dc-a87e-dcb215029e93"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2487), new DateTime(2022, 6, 20, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(2488) });

            migrationBuilder.CreateIndex(
                name: "IX_DrugOrders_DrugId",
                table: "DrugOrders",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugOrders_StaffId",
                table: "DrugOrders",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugOrders");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Drugs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27fb1887-cf6f-45d8-83d1-c501d6054fd3",
                column: "ConcurrencyStamp",
                value: "7a2ef114-ec3e-4491-94e4-14020a57cdd3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5af1f3a1-f7f9-4ad0-b757-cda796199def",
                column: "ConcurrencyStamp",
                value: "6a934e68-742b-42b8-ab71-d847a960ab75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67228962-a44c-49a6-b89b-395dd92cf75a",
                column: "ConcurrencyStamp",
                value: "3bf2cf5e-bc62-4a5f-a4a9-873ceb42eb92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1ff4611-dc37-4a8e-af8e-73e764fc8676",
                column: "ConcurrencyStamp",
                value: "3bcc2a4c-7572-42c1-b3aa-6297572b8870");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "300ddf19-95e6-4744-83e6-2aa5e1d444c0",
                columns: new[] { "ConcurrencyStamp", "ModifiedOn", "PasswordHash", "RegisterationDate", "SecurityStamp" },
                values: new object[] { "9fb57541-76ac-4a1f-a758-9acb409709e2", new DateTime(2022, 6, 16, 12, 59, 59, 597, DateTimeKind.Utc).AddTicks(3313), "AQAAAAEAACcQAAAAEMjImwvbuNNTT6hvmjAsjWMdvTLnnRYwiH0fi0LkWbvle57C5EG/uMAJ4M03Qg18pQ==", new DateTime(2022, 6, 16, 12, 59, 59, 597, DateTimeKind.Utc).AddTicks(3309), "56affcef-44ea-472e-ab64-1ee478e0497f" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("12757ffa-ab81-4a23-b3a1-4f3fc169ec53"),
                columns: new[] { "CreatedAt", "ModifiedOn", "Status" },
                values: new object[] { new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6877), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6878), 1 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("295d3a0c-992c-4dfb-bcc2-e26fb6f9b4b8"),
                columns: new[] { "CreatedAt", "ModifiedOn", "Status" },
                values: new object[] { new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6883), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6883), 1 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2b212064-c708-44fd-a49a-6d138cdded37"),
                columns: new[] { "CreatedAt", "ModifiedOn", "Status" },
                values: new object[] { new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6891), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6891), 1 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("368faff2-f91f-4de3-a9b9-ac6e659ced57"),
                columns: new[] { "CreatedAt", "ModifiedOn", "Status" },
                values: new object[] { new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6871), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6871), 1 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("501c0200-3c6d-48c7-8b6e-964a87f0c290"),
                columns: new[] { "CreatedAt", "ModifiedOn", "Status" },
                values: new object[] { new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6880), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6881), 1 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("55ccc95d-caac-44fe-b3ee-8830184ee9b5"),
                columns: new[] { "CreatedAt", "ModifiedOn", "Status" },
                values: new object[] { new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6888), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6889), 1 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7cd042ca-c443-4067-91c1-6d1df0fad8d5"),
                columns: new[] { "CreatedAt", "ModifiedOn", "Status" },
                values: new object[] { new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6859), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6861), 1 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7da11ee0-2519-493f-816a-ba6f46aacb74"),
                columns: new[] { "CreatedAt", "ModifiedOn", "Status" },
                values: new object[] { new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(5635), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(5644), 1 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("91c4ebd1-33ae-4ef2-aeee-1d12e01d3dfb"),
                columns: new[] { "CreatedAt", "ModifiedOn", "Status" },
                values: new object[] { new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6885), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6886), 1 });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("a0a2e6c6-3fee-46dc-a87e-dcb215029e93"),
                columns: new[] { "CreatedAt", "ModifiedOn", "Status" },
                values: new object[] { new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6874), new DateTime(2022, 6, 16, 12, 59, 59, 595, DateTimeKind.Utc).AddTicks(6875), 1 });
        }
    }
}
