using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEstadistica.Migrations
{
    /// <inheritdoc />
    public partial class UsuariosTlf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Paises_PaisId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PaisId",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "Usuario",
                newName: "Telefono");

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
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Paises_PaisId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PaisId",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Usuario",
                newName: "Rol");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PaisId",
                table: "Clientes",
                column: "PaisId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Paises_PaisId",
                table: "Clientes",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "PaisId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
