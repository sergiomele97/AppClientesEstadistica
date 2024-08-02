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
}
