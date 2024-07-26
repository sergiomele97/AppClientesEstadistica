
using BackendEstadistica.Contexto;
using BackendEstadistica.Entidades;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackendEstadistica.Servicios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ContextoBBDD contextoBBDD;
        
        public UsuarioRepositorio(ContextoBBDD contexto)
        {
            this.contextoBBDD = contexto;
        }
        public void AddUsuario(Usuario usuario)
        {

            // Añadir el usuario al DbSet
            contextoBBDD.Add(usuario);

        }

        public void DeleteUsuario(Usuario usuario)
        {
            contextoBBDD.Usuario.Remove(usuario);

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
