using Microsoft.EntityFrameworkCore.Migrations;

namespace Sibers.Migrations
{
    public partial class Add_FK_Projects_Employees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ProjectLeaderID",
                table: "Projects",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectLeaderID",
                table: "Projects",
                column: "ProjectLeaderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees",
                table: "Projects",
                column: "ProjectLeaderID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectLeaderID",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectLeaderID",
                table: "Projects",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
