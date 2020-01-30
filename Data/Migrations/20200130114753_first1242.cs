using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication19.Data.Migrations
{
    public partial class first1242 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "poczatek_znajomosci",
                table: "znajomis",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "poczatek_znajomosci",
                table: "znajomis",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
