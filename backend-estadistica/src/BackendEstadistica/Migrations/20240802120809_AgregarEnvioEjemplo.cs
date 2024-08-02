using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEstadistica.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEnvioEjemplo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnvioEjemplo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Divisa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<double>(type: "float", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvioEjemplo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnvioEjemplo");
        }
    }
}
