
using BackendEstadistica.Contexto;

namespace BackendEstadistica.Servicios
{
    public class EnvioEjemploRepositorio : IEnvioEjemploRepositorio
    {

        private readonly ContextoBBDD contextoBBDD;

        public EnvioEjemploRepositorio(ContextoBBDD contextoBBDD)
        {
            this.contextoBBDD = contextoBBDD;
        }

        public void CrearEnvio(EnvioEjemplo envioEjemplo)
        {
            var envioFake = new EnvioEjemploFaker().Generate();

            contextoBBDD.EnvioEjemplo.Add(envioFake);
            contextoBBDD.SaveChanges();

        }

        public List<EnvioEjemplo> GetEnvio()
        {
     
           return contextoBBDD.EnvioEjemplo.ToList();
            
        }
    }
}
