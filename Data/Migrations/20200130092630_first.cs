using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication19.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "uzytkownicies",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    login = table.Column<string>(nullable: true),
                    haslo = table.Column<string>(maxLength: 32, nullable: true),
                    imie = table.Column<string>(nullable: false),
                    nazwisko = table.Column<string>(nullable: false),
                    ksywka = table.Column<string>(nullable: false),
                    kraj = table.Column<string>(nullable: false),
                    data_zalozenia = table.Column<long>(nullable: false),
                    ostatnie_logowanie = table.Column<int>(nullable: false),
                    ip_ostatniego_logowania = table.Column<int>(nullable: false),
                    liczba_znajomych = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uzytkownicies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fanpages",
                columns: table => new
                {
                    id_fanpage = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_uzytkownicy = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    nazwa = table.Column<string>(nullable: true),
                    kategoria = table.Column<string>(nullable: true),
                    data_zalozenia = table.Column<int>(nullable: false),
                    liczba_polubien = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fanpages", x => x.id_fanpage);
                    table.ForeignKey(
                        name: "FK_fanpages_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "filmies",
                columns: table => new
                {
                    id_filmy = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nazwa = table.Column<string>(nullable: true),
                    id_uzytkownicy = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    link_bezposredni = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filmies", x => x.id_filmy);
                    table.ForeignKey(
                        name: "FK_filmies_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grupy_Dyskusyjnes",
                columns: table => new
                {
                    id_grupy_dyskusyjne = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nazwa = table.Column<string>(nullable: false),
                    id_uzytkownicy = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    data_zalozenia = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupy_Dyskusyjnes", x => x.id_grupy_dyskusyjne);
                    table.ForeignKey(
                        name: "FK_grupy_Dyskusyjnes_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "plikis",
                columns: table => new
                {
                    id_pliki = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nazwa = table.Column<string>(nullable: true),
                    id_uzytkownicy = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    link_bezpośredni = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plikis", x => x.id_pliki);
                    table.ForeignKey(
                        name: "FK_plikis_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "posties",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    typ = table.Column<int>(nullable: false),
                    id_uzytkownika = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    tresc = table.Column<string>(nullable: false),
                    data_utworzenia = table.Column<long>(nullable: false),
                    liczba_like = table.Column<int>(nullable: false),
                    liczba_dislike = table.Column<int>(nullable: false),
                    status_komentarzy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posties", x => x.id);
                    table.ForeignKey(
                        name: "FK_posties_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reakcja_Na_Posties",
                columns: table => new
                {
                    id_reakcje_na_posty = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_wydarzenia = table.Column<int>(nullable: false),
                    id_uzytkownicy = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    typ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reakcja_Na_Posties", x => x.id_reakcje_na_posty);
                    table.ForeignKey(
                        name: "FK_reakcja_Na_Posties_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "wiadomoscis",
                columns: table => new
                {
                    Id_wiadomosci = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_konwersacji = table.Column<int>(nullable: false),
                    id_uzytkownicy = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    tresc = table.Column<string>(nullable: true),
                    data_utworzenia = table.Column<int>(nullable: false),
                    czy_usunieta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wiadomoscis", x => x.Id_wiadomosci);
                    table.ForeignKey(
                        name: "FK_wiadomoscis_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "zainteresowanias",
                columns: table => new
                {
                    Id_zainteresowania = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nazwa = table.Column<string>(nullable: true),
                    kategoria = table.Column<string>(nullable: true),
                    id_uzytkownicy = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    liczba_zainteresowanych = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zainteresowanias", x => x.Id_zainteresowania);
                    table.ForeignKey(
                        name: "FK_zainteresowanias_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "zaproszenia_Do_Znajomyches",
                columns: table => new
                {
                    Id_zapraszającego = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_uzytkownicy = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    data_zaproszenia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zaproszenia_Do_Znajomyches", x => x.Id_zapraszającego);
                    table.ForeignKey(
                        name: "FK_zaproszenia_Do_Znajomyches_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "zdjecias",
                columns: table => new
                {
                    Id_zjecia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nazwa = table.Column<string>(nullable: true),
                    Id_użytkownicy = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    link_bezposredni = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zdjecias", x => x.Id_zjecia);
                    table.ForeignKey(
                        name: "FK_zdjecias_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "znajomis",
                columns: table => new
                {
                    Id_znajomi = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_uzytkownicy = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    Id_znajomwgo = table.Column<string>(nullable: true),
                    poczatek_znajomosci = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_znajomis", x => x.Id_znajomi);
                    table.ForeignKey(
                        name: "FK_znajomis_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "polubienia_Fanpages",
                columns: table => new
                {
                    id_polubienia_fanpage = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_fanpage = table.Column<string>(nullable: true),
                    fanpageid_fanpage = table.Column<int>(nullable: true),
                    id_uzytkownicy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_polubienia_Fanpages", x => x.id_polubienia_fanpage);
                    table.ForeignKey(
                        name: "FK_polubienia_Fanpages_fanpages_fanpageid_fanpage",
                        column: x => x.fanpageid_fanpage,
                        principalTable: "fanpages",
                        principalColumn: "id_fanpage",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "czlonkowie_Grups",
                columns: table => new
                {
                    id_czlonkowie_grup = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_grupy_dyskusyjne = table.Column<int>(nullable: false),
                    id_uzytkownicy = table.Column<string>(nullable: true),
                    data_dolaczenia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_czlonkowie_Grups", x => x.id_czlonkowie_grup);
                    table.ForeignKey(
                        name: "FK_czlonkowie_Grups_grupy_Dyskusyjnes_id_grupy_dyskusyjne",
                        column: x => x.id_grupy_dyskusyjne,
                        principalTable: "grupy_Dyskusyjnes",
                        principalColumn: "id_grupy_dyskusyjne",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "zaproszenia_Do_Grups",
                columns: table => new
                {
                    Id_zaproszenia_do_grup = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_uzytkownicy = table.Column<string>(nullable: true),
                    id_grupy_dyskusyjne = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zaproszenia_Do_Grups", x => x.Id_zaproszenia_do_grup);
                    table.ForeignKey(
                        name: "FK_zaproszenia_Do_Grups_grupy_Dyskusyjnes_id_grupy_dyskusyjne",
                        column: x => x.id_grupy_dyskusyjne,
                        principalTable: "grupy_Dyskusyjnes",
                        principalColumn: "id_grupy_dyskusyjne",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "komentarze",
                columns: table => new
                {
                    id_komentarze = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_posty = table.Column<int>(nullable: false),
                    postyid = table.Column<int>(nullable: true),
                    id_uzytkownicy = table.Column<string>(nullable: true),
                    uzytkownicyid = table.Column<string>(nullable: true),
                    tresc = table.Column<string>(nullable: true),
                    data_utworzenia = table.Column<int>(nullable: false),
                    liczba_like = table.Column<int>(nullable: false),
                    liczba_dislike = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_komentarze", x => x.id_komentarze);
                    table.ForeignKey(
                        name: "FK_komentarze_posties_postyid",
                        column: x => x.postyid,
                        principalTable: "posties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_komentarze_uzytkownicies_uzytkownicyid",
                        column: x => x.uzytkownicyid,
                        principalTable: "uzytkownicies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_czlonkowie_Grups_id_grupy_dyskusyjne",
                table: "czlonkowie_Grups",
                column: "id_grupy_dyskusyjne");

            migrationBuilder.CreateIndex(
                name: "IX_fanpages_uzytkownicyid",
                table: "fanpages",
                column: "uzytkownicyid");

            migrationBuilder.CreateIndex(
                name: "IX_filmies_uzytkownicyid",
                table: "filmies",
                column: "uzytkownicyid");

            migrationBuilder.CreateIndex(
                name: "IX_grupy_Dyskusyjnes_uzytkownicyid",
                table: "grupy_Dyskusyjnes",
                column: "uzytkownicyid");

            migrationBuilder.CreateIndex(
                name: "IX_komentarze_postyid",
                table: "komentarze",
                column: "postyid");

            migrationBuilder.CreateIndex(
                name: "IX_komentarze_uzytkownicyid",
                table: "komentarze",
                column: "uzytkownicyid");

            migrationBuilder.CreateIndex(
                name: "IX_plikis_uzytkownicyid",
                table: "plikis",
                column: "uzytkownicyid");

            migrationBuilder.CreateIndex(
                name: "IX_polubienia_Fanpages_fanpageid_fanpage",
                table: "polubienia_Fanpages",
                column: "fanpageid_fanpage");

            migrationBuilder.CreateIndex(
                name: "IX_posties_uzytkownicyid",
                table: "posties",
                column: "uzytkownicyid");

            migrationBuilder.CreateIndex(
                name: "IX_reakcja_Na_Posties_uzytkownicyid",
                table: "reakcja_Na_Posties",
                column: "uzytkownicyid");

            migrationBuilder.CreateIndex(
                name: "IX_wiadomoscis_uzytkownicyid",
                table: "wiadomoscis",
                column: "uzytkownicyid");

            migrationBuilder.CreateIndex(
                name: "IX_zainteresowanias_uzytkownicyid",
                table: "zainteresowanias",
                column: "uzytkownicyid");

            migrationBuilder.CreateIndex(
                name: "IX_zaproszenia_Do_Grups_id_grupy_dyskusyjne",
                table: "zaproszenia_Do_Grups",
                column: "id_grupy_dyskusyjne");

            migrationBuilder.CreateIndex(
                name: "IX_zaproszenia_Do_Znajomyches_uzytkownicyid",
                table: "zaproszenia_Do_Znajomyches",
                column: "uzytkownicyid");

            migrationBuilder.CreateIndex(
                name: "IX_zdjecias_uzytkownicyid",
                table: "zdjecias",
                column: "uzytkownicyid");

            migrationBuilder.CreateIndex(
                name: "IX_znajomis_uzytkownicyid",
                table: "znajomis",
                column: "uzytkownicyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "czlonkowie_Grups");

            migrationBuilder.DropTable(
                name: "filmies");

            migrationBuilder.DropTable(
                name: "komentarze");

            migrationBuilder.DropTable(
                name: "plikis");

            migrationBuilder.DropTable(
                name: "polubienia_Fanpages");

            migrationBuilder.DropTable(
                name: "reakcja_Na_Posties");

            migrationBuilder.DropTable(
                name: "wiadomoscis");

            migrationBuilder.DropTable(
                name: "zainteresowanias");

            migrationBuilder.DropTable(
                name: "zaproszenia_Do_Grups");

            migrationBuilder.DropTable(
                name: "zaproszenia_Do_Znajomyches");

            migrationBuilder.DropTable(
                name: "zdjecias");

            migrationBuilder.DropTable(
                name: "znajomis");

            migrationBuilder.DropTable(
                name: "posties");

            migrationBuilder.DropTable(
                name: "fanpages");

            migrationBuilder.DropTable(
                name: "grupy_Dyskusyjnes");

            migrationBuilder.DropTable(
                name: "uzytkownicies");
        }
    }
}
