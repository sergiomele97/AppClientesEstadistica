using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendEstadistica.Servicios
{
    public class EstadisticasRepositorio : IEstadisticasRepositorio
    {
        private readonly ContextoBBDD _contextoBBDD;
        private readonly IMapper _mapper;

        public EstadisticasRepositorio(ContextoBBDD contextoBBDD, IMapper mapper)
        {
            _contextoBBDD = contextoBBDD;
            _mapper = mapper;
        }

        public async Task CrearClienteAsync(Cliente cliente)
        {
            var clienteEntity = _mapper.Map<Cliente>(cliente);
            await _contextoBBDD.Clientes.AddAsync(clienteEntity);
            await _contextoBBDD.SaveChangesAsync();
        }

        public async Task<Cliente> GetRandomClientAsync()
        {
            int totalClientes = await _contextoBBDD.Clientes.CountAsync();

            if (totalClientes == 0)
            {
                throw new InvalidOperationException("No hay clientes disponibles.");
            }

            Random random = new Random();
            int clienteAleatorioIndex = random.Next(0, totalClientes);

            var clienteAleatorio = await _contextoBBDD.Clientes
                                    .OrderBy(c => c.ClienteId)
                                    .Skip(clienteAleatorioIndex)
                                    .FirstOrDefaultAsync();

            if (clienteAleatorio == null)
            {
                throw new InvalidOperationException("No se pudo seleccionar un cliente.");
            }

            return clienteAleatorio;
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _contextoBBDD.Clientes
                .Include(c => c.Pais)
                .Include(c => c.Conversiones)
                .Include(c => c.TransaccionesOrigen)
                .Include(c => c.TransaccionesDestino)
                .ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _contextoBBDD.Clientes
                .Include(c => c.Pais)
                .Include(c => c.Conversiones)
                .Include(c => c.TransaccionesOrigen)
                .Include(c => c.TransaccionesDestino)
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        public async Task CrearDivisaAsync(Divisa divisa)
        {
            var divisaEntity = _mapper.Map<Divisa>(divisa);
            await _contextoBBDD.Divisa.AddAsync(divisaEntity);
            await _contextoBBDD.SaveChangesAsync();
        }

        public async Task<Divisa> GetDivisaByIdAsync(int id)
        {
            return await _contextoBBDD.Divisa
                .FirstOrDefaultAsync(d => d.DivisaId == id);
        }

        public async Task<List<Divisa>> GetDivisasAsync()
        {
            return await _contextoBBDD.Divisa.ToListAsync();
        }

        public async Task CrearConversionAsync(Conversion conversion)
        {
            var conversionEntity = _mapper.Map<Conversion>(conversion);
            await _contextoBBDD.Conversion.AddAsync(conversionEntity);
            await _contextoBBDD.SaveChangesAsync();
        }

        public async Task<List<Conversion>> GetConversionesAsync()
        {
            return await _contextoBBDD.Conversion
                .Include(c => c.Cliente)
                .ToListAsync();
        }

        public async Task<Conversion> GetConversionByIdAsync(int id)
        {
            return await _contextoBBDD.Conversion
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(c => c.ConversionId == id);
        }

        public async Task CrearTransaccionAsync(Transaccion transaccion)
        {
            var clienteOrigen = await _contextoBBDD.Clientes.FindAsync(transaccion.ClienteOrigenId);
            var clienteDestino = await _contextoBBDD.Clientes.FindAsync(transaccion.ClienteDestinoId);

            if (clienteOrigen != null && clienteDestino != null)
            {
                var transaccionEntity = _mapper.Map<Transaccion>(transaccion);

                clienteOrigen.TransaccionesDestino.Add(transaccionEntity);
                clienteDestino.TransaccionesOrigen.Add(transaccionEntity);
                await _contextoBBDD.Transacciones.AddAsync(transaccionEntity);
                await _contextoBBDD.SaveChangesAsync();
            }
        }

        public async Task<List<Transaccion>> GetTransaccionesAsync()
        {
            return await _contextoBBDD.Transacciones
                .Include(t => t.ClienteOrigen)
                .Include(t => t.ClienteDestino)
                .ToListAsync();
        }

        public async Task<Transaccion> GetTransaccionByIdAsync(int id)
        {
            return await _contextoBBDD.Transacciones
                .Include(t => t.ClienteOrigen)
                .Include(t => t.ClienteDestino)
                .FirstOrDefaultAsync(t => t.TransaccionId == id);
        }

        public async Task DetectarOutliersAsync()
        {
            var transaccionesByCliente = await _contextoBBDD.Transacciones
                .Include(t => t.ClienteOrigen)
                .Where(t => t.ImporteEnviado.HasValue)
                .GroupBy(t => t.ClienteOrigenId)
                .ToListAsync();

            foreach (var group in transaccionesByCliente)
            {
                var amounts = group.Select(t => t.ImporteEnviado.Value).OrderBy(a => a).ToList();

                if (amounts.Count < 10)
                    continue;

                double q1 = GetQuantile(amounts, 0.25);
                double q3 = GetQuantile(amounts, 0.75);
                double iqr = q3 - q1;

                double upperBound = q3 + 3 * iqr;

                foreach (var transaccion in group)
                {
                    transaccion.IsOutlier = transaccion.ImporteEnviado > upperBound;
                }
            }

            await _contextoBBDD.SaveChangesAsync();
        }

        private double GetQuantile(List<double> sortedValues, double percentile)
        {
            int N = sortedValues.Count;
            double index = percentile * (N - 1);
            int lowerIndex = (int)Math.Floor(index);
            int upperIndex = (int)Math.Ceiling(index);

            if (lowerIndex == upperIndex)
                return sortedValues[lowerIndex];
            return sortedValues[lowerIndex] * (1 - (index - lowerIndex)) + sortedValues[upperIndex] * (index - lowerIndex);
        }

        public async Task<bool> EliminarOutlierAsync(int transaccionId)
        {
            try
            {
                var transaccion = await _contextoBBDD.Transacciones
                    .FirstOrDefaultAsync(t => t.TransaccionId == transaccionId);

                if (transaccion == null || !(transaccion.IsOutlier ?? false))
                {
                    return false;
                }

                transaccion.IsOutlier = false;
                transaccion.IsOutlierVisto = true;
                await _contextoBBDD.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task CrearPaisAsync(Pais pais)
        {
            var paisEntity = _mapper.Map<Pais>(pais);
            await _contextoBBDD.Paises.AddAsync(paisEntity);
            await _contextoBBDD.SaveChangesAsync();
        }

        public async Task<List<Pais>> GetPaisesAsync()
        {
            return await _contextoBBDD.Paises.ToListAsync();
        }

        public async Task<Pais> GetPaisByIdAsync(int id)
        {
            return await _contextoBBDD.Paises
                .Include(p => p.Clientes)
                .FirstOrDefaultAsync(p => p.PaisId == id);
        }
    }
}
