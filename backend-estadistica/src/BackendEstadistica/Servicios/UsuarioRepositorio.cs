
using BackendEstadistica.Contexto;

namespace BackendEstadistica.Servicios
{

    // Esta clase gestiona la comunicacón con la base de datos
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        // Propiedad de tipo contexto de base de datos (puerta de entrada a la BBDD)
        private readonly ContextoBBDD contextoBBDD;
        
        // Constructor al que le pasamos el contexto como parámetro
        public UsuarioRepositorio(ContextoBBDD contexto)
        {
            this.contextoBBDD = contexto;
        }

        public bool EmailExist(string email)
        {
            return contextoBBDD.Usuario.Any(u => u.Correo == email);
        }

        public void AddUsuario(Usuario usuario)
        {
            
            // Añadir el usuario al DbSet
            contextoBBDD.Add(usuario);
            contextoBBDD.SaveChanges();

        }

        public bool DeleteUsuario(int id)
        {
            var usuario = contextoBBDD.Usuario.Find(id);
            if (usuario == null)
            {
                return false;
            }

            contextoBBDD.Usuario.Remove(usuario);
            contextoBBDD.SaveChanges();
            return true;
        }

        public Usuario GetUsuarioById(int id)
        {
            return contextoBBDD.Usuario.FirstOrDefault(u => u.Id == id);

        }

        public List<Usuario> GetUsuarios()
        {
            return contextoBBDD.Usuario.ToList();
        }

        public List<Usuario> GetUsuariosFiltrando(string nombre, int numeroPagina, int tamañoPagina)
        {
            throw new NotImplementedException();
        }

        public bool GuardarCambios()
        {

            throw new NotImplementedException();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            contextoBBDD.Usuario.Update(usuario);

        }
    }
}
