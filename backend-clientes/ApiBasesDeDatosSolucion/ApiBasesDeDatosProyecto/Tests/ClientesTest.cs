namespace ApiBasesDeDatosProyecto.Tests;
public class ClientesTest
{
    private readonly Contexto _contexto;
    private readonly ClienteRepository _repository;

    public ClientesTest(Contexto contexto, ClienteRepository clienteRepository)
    {
        _contexto = contexto;
        _repository = clienteRepository;
    }

    public async Task GetClientesFake()
    {
        var clientesRepositorio = new ClienteRepository(_contexto);
        var cliente = new ClienteFaker().Generate();
        _contexto.Clientes.Add(cliente);
        _contexto.SaveChanges();

        var clienteRecuperado = await clientesRepositorio.ObtenerPorId(cliente.Id);

        clienteRecuperado.Should().BeEquivalentTo(cliente, options => options.
        ComparingByMembers<Cliente>());
    }
}