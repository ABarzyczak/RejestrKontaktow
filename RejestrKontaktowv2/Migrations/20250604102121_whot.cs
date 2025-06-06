using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RejestrKontaktowv2.Migrations
{
    /// <inheritdoc />
    public partial class whot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Osoby",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nr_tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoby", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Osoby",
                columns: new[] { "id", "adres", "email", "imie", "nazwisko", "nr_tel" },
                values: new object[,]
                {
                    { 1, "Warszawa", "kur@gmail.com", "Hubert", "Kurowski", "111111111" },
                    { 2, "Podgorze Gazdy", "barz@gmail.com", "Aleksander", "Barzyczak", "222222222" },
                    { 3, "Ciechocinek", "bess@gmail.com", "Wiktor", "Bessert", "333333333" },
                    { 4, "Saperowice", "chu@gmail.com", "Marcin", "Chuchla", "444444444" },
                    { 5, "Pabianice", "daw@gmail.com", "Dawid", "Jasper", "1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Osoby");
        }
    }
}
