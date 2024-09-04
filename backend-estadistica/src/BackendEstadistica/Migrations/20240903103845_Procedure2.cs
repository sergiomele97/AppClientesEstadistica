using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendEstadistica.Migrations
{
    /// <inheritdoc />
    public partial class Procedure2 : Migration
    {
   
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.Sql(@"
    CREATE PROCEDURE GetFilteredTransacciones
        @ClienteId INT = NULL,
        @StartDate DATETIME = NULL,
        @EndDate DATETIME = NULL
    AS
    BEGIN
        SELECT 
            t.TransaccionId,
            t.ClienteOrigenId,
            co.Nombre AS ClienteOrigenNombre,
            co.Correo AS ClienteOrigenCorreo,
            co.Telefono AS ClienteOrigenTelefono,
            t.ClienteDestinoId,
            cd.Nombre AS ClienteDestinoNombre,
            cd.Correo AS ClienteDestinoCorreo,
            cd.Telefono AS ClienteDestinoTelefono,
            po.Divisa AS ClienteOrigenDivisa,
            pd.Divisa AS ClienteDestinoDivisa,
            t.ImporteEnviado,
            t.ImporteRecibido,
            t.Fecha
        FROM 
            Transacciones t
        JOIN 
            Clientes co ON t.ClienteOrigenId = co.ClienteId
        JOIN 
            Clientes cd ON t.ClienteDestinoId = cd.ClienteId
        JOIN 
            Paises po ON co.PaisId = po.PaisId
        JOIN 
            Paises pd ON cd.PaisId = pd.PaisId
        WHERE 
            (@ClienteId IS NULL OR t.ClienteOrigenId = @ClienteId OR t.ClienteDestinoId = @ClienteId)
            AND (@StartDate IS NULL OR t.Fecha >= @StartDate)
            AND (@EndDate IS NULL OR t.Fecha <= @EndDate)
        ORDER BY 
            t.Fecha DESC;
    END
");


            }

            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.Sql("DROP PROCEDURE GetFilteredTransacciones");
            }
        

    }

}


