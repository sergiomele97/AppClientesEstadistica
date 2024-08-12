using ApiBasesDeDatosProyecto.Context;

namespace ApiBasesDeDatosProyecto.Repository
{
    public class PaisRepository : IPaisRepository
    {
        private readonly Contexto contexto;

        public PaisRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public void Actualizar(Pais pais)
        {
            contexto.Paises.Update(pais);
        }

        public void Agregar(Pais pais)
        {
            contexto.Paises.Add(pais);
        }

        public void Eliminar(Pais pais)
        {

            contexto.Paises.Remove(pais);
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
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                result = false;
            }

            return result;
        }

        public async Task<Pais?> ObtenerPorId(int id)
        {
            return await contexto.Paises.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Pais?> ObtenerPorNombre(string nombre)
        {
            return await contexto.Paises
                .Where(p => p.Nombre == nombre)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Pais>> ObtenerTodos()
        {
            return await contexto.Paises.ToListAsync();
        }
    }
}