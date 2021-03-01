using Microsoft.EntityFrameworkCore.Migrations;

namespace Sibers.Migrations
{
    public partial class Add_FK_Employees_CustomerCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Company",
                table: "Employees",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Company",
                table: "Employees",
                column: "Company");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CustomerCompanies",
                table: "Employees",
                column: "Company",
                principalTable: "CustomerCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CustomerCompanies",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Company",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "Company",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
