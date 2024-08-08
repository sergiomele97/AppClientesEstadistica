using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEstadistica.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversion_Clientes_ClienteId",
                table: "Conversion");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Clientes_IdDestino",
                table: "Transacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Clientes_IdOrigen",
                table: "Transacciones");

            migrationBuilder.DropTable(
                name: "EnvioEjemplo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "IdOrigen",
                table: "Transacciones",
                newName: "ClienteOrigenId");

            migrationBuilder.RenameColumn(
                name: "IdDestino",
                table: "Transacciones",
                newName: "ClienteDestinoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transacciones",
                newName: "TransaccionId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacciones_IdOrigen",
                table: "Transacciones",
                newName: "IX_Transacciones_ClienteOrigenId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacciones_IdDestino",
                table: "Transacciones",
                newName: "IX_Transacciones_ClienteDestinoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Paises",
                newName: "PaisId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Conversion",
                newName: "ConversionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clientes",
                newName: "PaisId");

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PaisId",
                table: "Clientes",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Paises_PaisId",
                table: "Clientes",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "PaisId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conversion_Clientes_ClienteId",
                table: "Conversion",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Clientes_ClienteDestinoId",
                table: "Transacciones",
                column: "ClienteDestinoId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Clientes_ClienteOrigenId",
                table: "Transacciones",
                column: "ClienteOrigenId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Paises_PaisId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversion_Clientes_ClienteId",
                table: "Conversion");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Clientes_ClienteDestinoId",
                table: "Transacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Clientes_ClienteOrigenId",
                table: "Transacciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PaisId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "ClienteOrigenId",
                table: "Transacciones",
                newName: "IdOrigen");

            migrationBuilder.RenameColumn(
                name: "ClienteDestinoId",
                table: "Transacciones",
                newName: "IdDestino");

            migrationBuilder.RenameColumn(
                name: "TransaccionId",
                table: "Transacciones",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Transacciones_ClienteOrigenId",
                table: "Transacciones",
                newName: "IX_Transacciones_IdOrigen");

            migrationBuilder.RenameIndex(
                name: "IX_Transacciones_ClienteDestinoId",
                table: "Transacciones",
                newName: "IX_Transacciones_IdDestino");

            migrationBuilder.RenameColumn(
                name: "PaisId",
                table: "Paises",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ConversionId",
                table: "Conversion",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PaisId",
                table: "Clientes",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EnvioEjemplo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<double>(type: "float", nullable: true),
                    Divisa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvioEjemplo", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Conversion_Clientes_ClienteId",
                table: "Conversion",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
