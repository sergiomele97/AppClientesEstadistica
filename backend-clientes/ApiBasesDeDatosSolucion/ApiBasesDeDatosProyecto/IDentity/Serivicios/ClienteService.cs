public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task RegisterClientAsync(Cliente cliente)
    {
        await _clienteRepository.AddClienteAsync(cliente);
    }

    public List<Cliente> GetClientes(int count)
    {
        var faker = new Faker<Cliente>()
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(u => u.Nombre, f => f.Name.ToString());

        return faker.Generate(count);
    }
}
