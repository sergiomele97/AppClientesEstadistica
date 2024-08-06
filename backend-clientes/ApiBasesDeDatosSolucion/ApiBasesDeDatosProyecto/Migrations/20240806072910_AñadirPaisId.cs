using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBasesDeDatosProyecto.Migrations
{
    /// <inheritdoc />
    public partial class AñadirPaisId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "paisId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paisId",
                table: "AspNetUsers");
        }
    }
}
