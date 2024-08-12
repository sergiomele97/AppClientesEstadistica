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

    public List<Cliente> GetClientes()
    {
        return _contextoBBDD.Clientes.ToList();
    }

    public Cliente GetClienteById(int id)
    {
        return _contextoBBDD.Clientes.FirstOrDefault(c => c.ClienteId == id);
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
        return _contextoBBDD.Conversion.ToList();
    }

    public Conversion GetConversionById(int id)
    {
        return _contextoBBDD.Conversion.FirstOrDefault(c => c.ConversionId == id);
    }

    //Transacciones
    public void CrearTransaccion(Transaccion transaccion)
    {
        var transaccionEntity = _mapper.Map<Transaccion>(transaccion);
        _contextoBBDD.Transacciones.Add(transaccionEntity);
        _contextoBBDD.SaveChanges();
    }

    public List<Transaccion> GetTransacciones()
    {
        return _contextoBBDD.Transacciones.ToList();
    }

    public Transaccion GetTransaccionById(int id)
    {
        return _contextoBBDD.Transacciones.FirstOrDefault(t => t.TransaccionId == id);
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
        return _contextoBBDD.Paises.FirstOrDefault(p => p.PaisId == id);
    }
}
