using ApiBasesDeDatosProyecto.Context;

namespace ApiBasesDeDatosProyecto.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly Contexto contexto;

        public ClienteRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public void Actualizar(Cliente cliente)
        {
            contexto.Clientes.Update(cliente);
        }
        public async Task AddClienteAsync(Cliente cliente)
        {
            contexto.Clientes.Add(cliente);
            await contexto.SaveChangesAsync();
        }

        public void Agregar(Cliente cliente)
        {
            contexto.Clientes.Add(cliente);
        }

        public void Eliminar(Cliente cliente)
        {

            contexto.Clientes.Remove(cliente);
        }

        public async Task<bool> GuardarCambios()
        {
            bool result = false;
            try
            {
                result = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }

        public async Task<Cliente?> ObtenerPorId(int id)
        {
            return await contexto.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente?> ObtenerClientesPais(int id)
        {
            return await contexto.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Cliente>> ObtenerClientesPorPaisId(int paisId)
        {
            return await contexto.Clientes
                .Where(c => c.PaisId == paisId)
                .ToListAsync();
        }
        public async Task<List<Cliente>> ObtenerTodos()
        {
            return await contexto.Clientes.ToListAsync();
        }


    }
}
