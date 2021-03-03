using Microsoft.EntityFrameworkCore.Migrations;

namespace Sibers.Migrations
{
    public partial class Replacement_of_wrong_connection_between_Employee_and_company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CustomerCompanies",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_ExecutingCompany",
                table: "Employees",
                column: "Company",
                principalTable: "ExecutingCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_ExecutingCompany",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CustomerCompanies",
                table: "Employees",
                column: "Company",
                principalTable: "CustomerCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
