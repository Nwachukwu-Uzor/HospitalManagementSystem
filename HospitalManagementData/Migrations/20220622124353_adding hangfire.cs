using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementData.Migrations
{
    public partial class addinghangfire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27fb1887-cf6f-45d8-83d1-c501d6054fd3",
                column: "ConcurrencyStamp",
                value: "43fd3c18-88aa-432c-a639-1e5a5a143af9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5af1f3a1-f7f9-4ad0-b757-cda796199def",
                column: "ConcurrencyStamp",
                value: "17270cc6-274f-419b-8f4a-8e62b68243cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67228962-a44c-49a6-b89b-395dd92cf75a",
                column: "ConcurrencyStamp",
                value: "1c5d867a-de1d-426d-84eb-e412364cc2dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1ff4611-dc37-4a8e-af8e-73e764fc8676",
                column: "ConcurrencyStamp",
                value: "c4789395-a9da-4dbe-a446-7d70bdc77e8e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "300ddf19-95e6-4744-83e6-2aa5e1d444c0",
                columns: new[] { "ConcurrencyStamp", "ModifiedOn", "PasswordHash", "RegisterationDate", "SecurityStamp" },
                values: new object[] { "65f70d0d-6967-4de6-a533-3902d1208624", new DateTime(2022, 6, 22, 12, 43, 52, 382, DateTimeKind.Utc).AddTicks(1439), "AQAAAAEAACcQAAAAEJ+gY1JRPb9SgG4s0tF3SN/s74IgCZhP9U6RRlnghMmr2hBxhpn59RdtUqhhNxxHsA==", new DateTime(2022, 6, 22, 12, 43, 52, 382, DateTimeKind.Utc).AddTicks(1432), "5ee9b3be-174c-495b-9c88-61e526d4f3fa" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("12757ffa-ab81-4a23-b3a1-4f3fc169ec53"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(696), new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(697) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("295d3a0c-992c-4dfb-bcc2-e26fb6f9b4b8"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(705), new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(705) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2b212064-c708-44fd-a49a-6d138cdded37"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(717), new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("368faff2-f91f-4de3-a9b9-ac6e659ced57"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(686), new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(687) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("501c0200-3c6d-48c7-8b6e-964a87f0c290"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(701), new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(701) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("55ccc95d-caac-44fe-b3ee-8830184ee9b5"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(713), new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7cd042ca-c443-4067-91c1-6d1df0fad8d5"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(667), new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(670) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7da11ee0-2519-493f-816a-ba6f46aacb74"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 43, 52, 379, DateTimeKind.Utc).AddTicks(8629), new DateTime(2022, 6, 22, 12, 43, 52, 379, DateTimeKind.Utc).AddTicks(8641) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("91c4ebd1-33ae-4ef2-aeee-1d12e01d3dfb"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(709), new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("a0a2e6c6-3fee-46dc-a87e-dcb215029e93"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(692), new DateTime(2022, 6, 22, 12, 43, 52, 380, DateTimeKind.Utc).AddTicks(693) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27fb1887-cf6f-45d8-83d1-c501d6054fd3",
                column: "ConcurrencyStamp",
                value: "ac5d2cbe-2791-439c-ba31-a3b0d8010f40");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5af1f3a1-f7f9-4ad0-b757-cda796199def",
                column: "ConcurrencyStamp",
                value: "fe68d865-34be-47e0-b07b-9a052073caca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67228962-a44c-49a6-b89b-395dd92cf75a",
                column: "ConcurrencyStamp",
                value: "ca504b07-00ae-40cd-9a13-c3c65c401b48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1ff4611-dc37-4a8e-af8e-73e764fc8676",
                column: "ConcurrencyStamp",
                value: "b254276b-10be-4bcb-beec-93a75d18f27b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "300ddf19-95e6-4744-83e6-2aa5e1d444c0",
                columns: new[] { "ConcurrencyStamp", "ModifiedOn", "PasswordHash", "RegisterationDate", "SecurityStamp" },
                values: new object[] { "4598c2f5-24f2-4842-88f1-0c48e0aeb7d5", new DateTime(2022, 6, 22, 12, 33, 21, 600, DateTimeKind.Utc).AddTicks(1238), "AQAAAAEAACcQAAAAEK0Fn1QYqX+UyiCEbFRZOUjXIjeBrTV4oRNovC3M/wxH/SoTZvLfft7Vjh4QbcDkJg==", new DateTime(2022, 6, 22, 12, 33, 21, 600, DateTimeKind.Utc).AddTicks(1229), "dbba1baa-1055-433d-b4ce-c505700fd5a9" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("12757ffa-ab81-4a23-b3a1-4f3fc169ec53"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6421), new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6422) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("295d3a0c-992c-4dfb-bcc2-e26fb6f9b4b8"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6427), new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6427) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2b212064-c708-44fd-a49a-6d138cdded37"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6435), new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6435) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("368faff2-f91f-4de3-a9b9-ac6e659ced57"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6414), new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6415) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("501c0200-3c6d-48c7-8b6e-964a87f0c290"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6424), new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6425) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("55ccc95d-caac-44fe-b3ee-8830184ee9b5"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6432), new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6433) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7cd042ca-c443-4067-91c1-6d1df0fad8d5"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6401), new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6403) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7da11ee0-2519-493f-816a-ba6f46aacb74"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(5025), new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(5035) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("91c4ebd1-33ae-4ef2-aeee-1d12e01d3dfb"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6429), new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("a0a2e6c6-3fee-46dc-a87e-dcb215029e93"),
                columns: new[] { "CreatedAt", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6418), new DateTime(2022, 6, 22, 12, 33, 21, 598, DateTimeKind.Utc).AddTicks(6419) });
        }
    }
}
