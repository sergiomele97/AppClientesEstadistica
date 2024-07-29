
using BackendEstadistica.Contexto;
using BackendEstadistica.Entidades;
using BackendEstadistica.Migrations;
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

        public void DeleteUsuario(int id)
        {
            var usuario = contextoBBDD.Usuario.Find(id);
            if (usuario != null)
            {
                contextoBBDD.Usuario.Remove(usuario);
                contextoBBDD.SaveChanges();
            }
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
