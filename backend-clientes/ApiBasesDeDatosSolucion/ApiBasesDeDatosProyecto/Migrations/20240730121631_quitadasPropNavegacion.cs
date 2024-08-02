using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiBasesDeDatosProyecto.Migrations
{
    /// <inheritdoc />
    public partial class quitadasPropNavegacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Divisa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellido", "FechaNacimiento", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 1, "Perez", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", 1 },
                    { 2, "Lopez", new DateTime(1985, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", 2 },
                    { 3, "Gomez", new DateTime(1978, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", 3 }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Divisa", "Nombre" },
                values: new object[,]
                {
                    { 1, "USD", "España" },
                    { 2, "EUR", "Francia" },
                    { 3, "USD", "Italia" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "UserName" },
                values: new object[,]
                {
                    { 1, "das@gmail.com", "PEPE1" },
                    { 2, "daaaaaaas@gmail.com", "PEPE2" },
                    { 3, "dadsdsds@gmail.com", "PEPE3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
