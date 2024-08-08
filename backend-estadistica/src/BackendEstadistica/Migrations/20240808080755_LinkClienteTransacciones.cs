using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEstadistica.Migrations
{
    /// <inheritdoc />
    public partial class LinkClienteTransacciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "importeRecibido",
                table: "Transacciones",
                newName: "ImporteRecibido");

            migrationBuilder.RenameColumn(
                name: "importeEnviado",
                table: "Transacciones",
                newName: "ImporteEnviado");

            migrationBuilder.RenameColumn(
                name: "idOrigen",
                table: "Transacciones",
                newName: "IdOrigen");

            migrationBuilder.RenameColumn(
                name: "idDestino",
                table: "Transacciones",
                newName: "IdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_IdDestino",
                table: "Transacciones",
                column: "IdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_IdOrigen",
                table: "Transacciones",
                column: "IdOrigen");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Clientes_IdDestino",
                table: "Transacciones",
                column: "IdDestino",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Clientes_IdOrigen",
                table: "Transacciones",
                column: "IdOrigen",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Clientes_IdDestino",
                table: "Transacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Clientes_IdOrigen",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_IdDestino",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_IdOrigen",
                table: "Transacciones");

            migrationBuilder.RenameColumn(
                name: "ImporteRecibido",
                table: "Transacciones",
                newName: "importeRecibido");

            migrationBuilder.RenameColumn(
                name: "ImporteEnviado",
                table: "Transacciones",
                newName: "importeEnviado");

            migrationBuilder.RenameColumn(
                name: "IdOrigen",
                table: "Transacciones",
                newName: "idOrigen");

            migrationBuilder.RenameColumn(
                name: "IdDestino",
                table: "Transacciones",
                newName: "idDestino");
        }
    }
}
