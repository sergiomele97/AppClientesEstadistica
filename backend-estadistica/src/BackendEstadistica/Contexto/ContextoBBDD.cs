using BackendEstadistica.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace BackendEstadistica.Contexto
{
    public class ContextoBBDD : DbContext
    {
        public static UsuariosRepositorioMemoria Instancia { get; } = new UsuariosRepositorioMemoria();

        public ContextoBBDD()
        {

        }

    }
}
