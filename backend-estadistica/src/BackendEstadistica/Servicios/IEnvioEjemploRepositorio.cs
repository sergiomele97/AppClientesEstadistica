namespace BackendEstadistica.Servicios
{
    public interface IEnvioEjemploRepositorio
    {

        List<EnvioEjemplo> GetEnvio();

        void CrearEnvio(EnvioEjemplo envioEjemplo);

    }
}
