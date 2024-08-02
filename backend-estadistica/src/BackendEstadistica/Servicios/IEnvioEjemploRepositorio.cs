namespace BackendEstadistica.Servicios
{
    public interface IEnvioEjemploRepositorio
    {

        Task<EnvioEjemplo> GetEnvio(int id);

    }
}
