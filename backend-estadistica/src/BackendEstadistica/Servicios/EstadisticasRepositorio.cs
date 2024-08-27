namespace BackendEstadistica.Servicios;

public class EstadisticasRepositorio : IEstadisticasRepositorio
{
    private readonly ContextoBBDD _contextoBBDD;
    private readonly IMapper _mapper;

    public EstadisticasRepositorio(ContextoBBDD contextoBBDD, IMapper mapper)
    {
        _contextoBBDD = contextoBBDD;
        _mapper = mapper;
    }

    //Clientes
    public void CrearCliente(Cliente cliente)
    {
        var clienteEntity = _mapper.Map<Cliente>(cliente);
        _contextoBBDD.Clientes.Add(clienteEntity);
        _contextoBBDD.SaveChanges();
    }

    // Obtener todos los clientes con sus transacciones, conversiones y país

    public Cliente GetRandomClient()
    {
        // Obtener el número total de clientes en la base de datos
        int totalClientes = _contextoBBDD.Clientes.Count();

        // Si no hay clientes, lanzar una excepción o manejarlo según tu lógica
        if (totalClientes == 0)
        {
            throw new InvalidOperationException("No hay clientes disponibles.");
        }

        // Generar un número aleatorio entre 0 y totalClientes - 1
        Random random = new Random();
        int clienteAleatorioIndex = random.Next(0, totalClientes);

        // Obtener el cliente correspondiente al índice aleatorio
        var clienteAleatorio = _contextoBBDD.Clientes
                                    .OrderBy(c => c.ClienteId) // Asegura el orden de los IDs
                                    .Skip(clienteAleatorioIndex) // Salta hasta el índice aleatorio
                                    .FirstOrDefault(); // Obtiene el cliente o null si no existe

        // Si no se encuentra un cliente, lanzar una excepción o manejarlo según tu lógica
        if (clienteAleatorio == null)
        {
            throw new InvalidOperationException("No se pudo seleccionar un cliente.");
        }

        return clienteAleatorio;
    }


    // ¡!Este metodo de abajo no deberia existir
    public List<Cliente> GetClientes()
    {
        return _contextoBBDD.Clientes
            .Include(c => c.Pais) // Incluye el país del cliente
            .Include(c => c.Conversiones) // Incluye las conversiones del cliente
            .Include(c => c.TransaccionesOrigen) // Incluye las transacciones de origen del cliente
            .Include(c => c.TransaccionesDestino) // Incluye las transacciones de destino del cliente
            .ToList();
    }

    // Obtener un cliente por ID con sus transacciones, conversiones y país
    public Cliente GetClienteById(int id)
    {
        return _contextoBBDD.Clientes
            .Include(c => c.Pais) // Incluye el país del cliente
            .Include(c => c.Conversiones) // Incluye las conversiones del cliente
            .Include(c => c.TransaccionesOrigen) // Incluye las transacciones de origen del cliente
            .Include(c => c.TransaccionesDestino) // Incluye las transacciones de destino del cliente
            .FirstOrDefault(c => c.ClienteId == id);
    }

    //Divisas
 

   
        public void CrearDivisa(Divisa divisa)
    {
        var divisaEntity = _mapper.Map<Divisa>(divisa);
        _contextoBBDD.Divisa.Add(divisaEntity);
        _contextoBBDD.SaveChanges();
        
    }

    public Divisa GetDivisaById(int id)
    {
        return _contextoBBDD.Divisa
            .FirstOrDefault(d => d.DivisaId == id);
    }

    public List<Divisa> GetDivisa()
    {
        return _contextoBBDD.Divisa.ToList();
    }


    //Conversiones
    public void CrearConversion(Conversion conversion)
    {
        var conversionEntity = _mapper.Map<Conversion>(conversion);
        _contextoBBDD.Conversion.Add(conversionEntity);
        _contextoBBDD.SaveChanges();
    }

    public List<Conversion> GetConversiones()
    {
        return _contextoBBDD.Conversion
            .Include(c => c.Cliente) // Incluye el cliente asociado a la conversión
            .ToList();
    }

    public Conversion GetConversionById(int id)
    {
        return _contextoBBDD.Conversion
            .Include(c => c.Cliente) // Incluye el cliente asociado a la conversión
            .FirstOrDefault(c => c.ConversionId == id);
    }

    //Transacciones
    public void CrearTransaccion(Transaccion transaccion)
    {
        var clienteOrigen = _contextoBBDD.Clientes.Find(transaccion.ClienteOrigenId);
        var clienteDestino = _contextoBBDD.Clientes.Find(transaccion.ClienteDestinoId);

        if (clienteOrigen != null && clienteDestino != null)
        {
            var transaccionEntity = _mapper.Map<Transaccion>(transaccion);

            clienteOrigen.TransaccionesDestino.Add(transaccionEntity);
            clienteDestino.TransaccionesOrigen.Add(transaccionEntity);
            _contextoBBDD.Transacciones.Add(transaccionEntity);
            _contextoBBDD.SaveChanges();
        }
    }

    public List<Transaccion> GetTransacciones()
    {
        return _contextoBBDD.Transacciones
            .Include(t => t.ClienteOrigen) // Incluye el cliente origen de la transacción
            .Include(t => t.ClienteDestino) // Incluye el cliente destino de la transacción
            .ToList();
    }

    public Transaccion GetTransaccionById(int id)
    {
        return _contextoBBDD.Transacciones
            .Include(t => t.ClienteOrigen) // Incluye el cliente origen de la transacción
            .Include(t => t.ClienteDestino) // Incluye el cliente destino de la transacción
            .FirstOrDefault(t => t.TransaccionId == id);
    }

    public void DetectarOutliers()
    {
        var transaccionesByCliente = _contextoBBDD.Transacciones
            .Include(t => t.ClienteOrigen)
            .Where(t => t.ImporteEnviado.HasValue) // Filtrar donde ImporteEnviado no es nulo
            .GroupBy(t => t.ClienteOrigenId)
            .ToList();

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

        _contextoBBDD.SaveChanges();
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

    public async Task<bool> EliminarOutlier(int transaccionId)
    {
        try
        {
            var transaccion = await _contextoBBDD.Transacciones
                .FirstOrDefaultAsync(t => t.TransaccionId == transaccionId);

            if (transaccion == null || (bool)!transaccion.IsOutlier)
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


    //Paises
    public void CrearPais(Pais pais)
    {
        var paisEntity = _mapper.Map<Pais>(pais);
        _contextoBBDD.Paises.Add(paisEntity);
        _contextoBBDD.SaveChanges();
    }

    public List<Pais> GetPaises()
    {
        return _contextoBBDD.Paises.ToList();
    }

    public Pais GetPaisById(int id)
    {
        return _contextoBBDD.Paises
            .Include(p => p.Clientes) // Incluye los clientes del país
            .FirstOrDefault(p => p.PaisId == id);
    }
}
