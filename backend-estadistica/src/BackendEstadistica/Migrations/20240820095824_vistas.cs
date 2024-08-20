using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEstadistica.Migrations
{
    /// <inheritdoc />
    public partial class vistas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
            CREATE VIEW [dbo].[ClientesConBalance] AS
            SELECT 
                c.ClienteId,
                c.Nombre,
                c.Edad,
                c.Sexo,
                p.Nombre AS Pais,
                (SELECT ISNULL(SUM(t.ImporteRecibido), 0) 
                 FROM Transacciones t 
                 WHERE t.ClienteDestinoId = c.ClienteId) 
                 - 
                (SELECT ISNULL(SUM(t.ImporteEnviado), 0) 
                 FROM Transacciones t 
                 WHERE t.ClienteOrigenId = c.ClienteId) 
                AS Balance,
                (SELECT COUNT(*) 
                 FROM Transacciones t 
                 WHERE t.ClienteOrigenId = c.ClienteId) 
                AS NumeroGastos,
                (SELECT COUNT(*) 
                 FROM Transacciones t 
                 WHERE t.ClienteDestinoId = c.ClienteId) 
                AS NumeroIngresos
            FROM Clientes c
            INNER JOIN Pais p ON c.PaisId = p.PaisId
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[ClientesConBalance]");
        }
    }
}
