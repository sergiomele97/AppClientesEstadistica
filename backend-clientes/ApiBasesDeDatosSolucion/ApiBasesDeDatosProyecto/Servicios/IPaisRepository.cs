
namespace ApiBasesDeDatosProyecto.Servicios
{
    public interface IPaisRepository 
    {

        Task<List<Pais>> ObtenerTodos();
        Task<Pais?> ObtenerPorId(int id);

        Task<bool> GuardarCambios();
        Task<Pais?> ObtenerPorNombre(string nombre);

        void Agregar(Pais pais);

        void Actualizar(Pais pais);

        // Metodo para eliminar pais
        void Eliminar(Pais pais);

    }
}
