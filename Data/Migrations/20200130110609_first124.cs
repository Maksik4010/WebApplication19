using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication19.Data.Migrations
{
    public partial class first124 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "data_utworzenia",
                table: "wiadomoscis",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "data_utworzenia",
                table: "komentarze",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "data_zalozenia",
                table: "fanpages",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "data_dolaczenia",
                table: "czlonkowie_Grups",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "data_utworzenia",
                table: "wiadomoscis",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "data_utworzenia",
                table: "komentarze",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "data_zalozenia",
                table: "fanpages",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "data_dolaczenia",
                table: "czlonkowie_Grups",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
