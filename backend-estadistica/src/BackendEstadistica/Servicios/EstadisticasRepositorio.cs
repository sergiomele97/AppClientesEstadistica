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
