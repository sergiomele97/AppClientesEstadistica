namespace ApiBasesDeDatosProyecto.Servicios
{
    
        public interface IUsuarioRepository
        {
            void Agregar(Usuario usuario);
            void Actualizar(Usuario usuario);
            void Eliminar(Usuario usuario);
            Task<bool> GuardarCambios();
            Task<Usuario?> ObtenerPorId(int id);
            Task<List<Usuario>> ObtenerTodos();
        }
    }

