using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infrastructure.Domain.Context.Migrations
{
    public partial class RefValueTableIsUpdatedv11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "RefValue",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RefValue",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RefValue");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "RefValue",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);
        }
    }
}
