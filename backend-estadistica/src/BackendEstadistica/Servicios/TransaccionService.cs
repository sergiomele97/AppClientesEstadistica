

namespace BackendEstadistica.Servicios

{
    public class TransaccionService
    {
        private readonly ContextoBBDD _contextoBBDD;

        public TransaccionService(ContextoBBDD context)
        {
            _contextoBBDD = context;
        }

        public async Task<List<TransaccionProceso>> GetFilteredTransacciones(int? clienteId, DateTime? startDate, DateTime? endDate)
        {
            var clienteIdParam = new SqlParameter("@ClienteId", clienteId ?? (object)DBNull.Value);
            var startDateParam = new SqlParameter("@StartDate", startDate ?? (object)DBNull.Value);
            var endDateParam = new SqlParameter("@EndDate", endDate ?? (object)DBNull.Value);

            var transacciones = await _contextoBBDD.TransaccionesProcesos
                .FromSqlRaw("EXEC GetFilteredTransacciones @ClienteId, @StartDate, @EndDate", clienteIdParam, startDateParam, endDateParam)
                .ToListAsync();

            return transacciones;
        }
    }
}
