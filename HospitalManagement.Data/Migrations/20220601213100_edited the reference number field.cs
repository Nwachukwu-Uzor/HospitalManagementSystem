using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagement.Data.Migrations
{
    public partial class editedthereferencenumberfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentReferenceNumber",
                table: "Appointments",
                newName: "ReferenceNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReferenceNumber",
                table: "Appointments",
                newName: "AppointmentReferenceNumber");
        }
    }
}
