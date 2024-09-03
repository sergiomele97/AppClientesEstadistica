using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEstadistica.Migrations
{
    /// <inheritdoc />
    public partial class Procedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransaccionesProcesos",
                columns: table => new
                {
                    TransaccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteOrigenId = table.Column<int>(type: "int", nullable: false),
                    ClienteOrigenNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteOrigenCorreo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteOrigenTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteDestinoId = table.Column<int>(type: "int", nullable: false),
                    ClienteDestinoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteDestinoCorreo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteDestinoTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteOrigenDivisa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteDestinoDivisa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImporteEnviado = table.Column<double>(type: "float", nullable: false),
                    ImporteRecibido = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransaccionesProcesos", x => x.TransaccionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransaccionesProcesos");
        }
    }
}
