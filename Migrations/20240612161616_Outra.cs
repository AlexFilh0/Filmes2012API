using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes2012API.Migrations
{
    /// <inheritdoc />
    public partial class Outra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnoLancamento",
                table: "Filmes",
                newName: "Ano");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "Filmes",
                newName: "AnoLancamento");
        }
    }
}
