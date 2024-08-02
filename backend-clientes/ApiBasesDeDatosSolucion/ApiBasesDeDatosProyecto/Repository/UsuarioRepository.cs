using ApiBasesDeDatosProyecto.Utilidades;

namespace ApiBasesDeDatosProyecto.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _contexto;

        public UsuarioRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Actualizar(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
        }

        public void Agregar(Usuario usuario)
        {
            if (usuario.Email.ComprobarEmail())
            {
                _contexto.Usuarios.Add(usuario);
            }

        }

        public void Eliminar(Usuario usuario)
        {
            _contexto.Usuarios.Remove(usuario);
        }

        public async Task<bool> GuardarCambios()
        {
            bool result = false;
            try
            {
                result = await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }

        public async Task<Usuario?> ObtenerPorId(int id)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> ObtenerTodos()
        {
            return await _contexto.Usuarios.ToListAsync();
        }
    }
}