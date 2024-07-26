
using BackendEstadistica.Entidades;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackendEstadistica.Servicios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public List<Usuario> Usuarios { get; set; }
        public static UsuarioRepositorio Instancia { get; } = new UsuarioRepositorio();
        public void AddUsuario(Usuario usuario)
        {
            
            Usuarios.Add(new Usuario()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Contraseña = usuario.Contraseña
            });
            
        }

        public void DeleteUsuario(Usuario usuario)
        {
            var usuarioBorrar = Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (usuarioBorrar != null)
            {
                Usuarios.Remove(usuarioBorrar);
            }

            

        }

        public Usuario GetUsuarioById(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);

            var usuarioGet = (new Usuario()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Contraseña = usuario.Contraseña
            });
            return usuarioGet;
           
        }

        public List<Usuario> GetUsuarios()
        {
            return Usuarios;
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
            var usuarioUpdate = Usuarios.FirstOrDefault(u => u.Id == usuario.Id);

            Usuarios.Add(new Usuario()
            {
                Id = usuarioUpdate.Id,
                Nombre = usuarioUpdate.Nombre,
                Correo = usuarioUpdate.Correo,
                Contraseña = usuarioUpdate.Contraseña
            });

        }
    }
}
