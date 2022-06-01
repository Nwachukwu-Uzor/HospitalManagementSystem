using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagement.Data.Migrations
{
    public partial class addappointmentreferencenumbertoappointmententity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentReferenceNumber",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentReferenceNumber",
                table: "Appointments");
        }
    }
}
