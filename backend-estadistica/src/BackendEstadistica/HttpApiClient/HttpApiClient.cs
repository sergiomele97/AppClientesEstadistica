using System.Net.Http;

namespace BackendEstadistica.Repositorios
{
    /* La instancia de HttpClient se utiliza para realizar solicitudes 
     * HTTP a un servicio web. El método GetHClient permite acceder 
     * a esta instancia de HttpClient desde otras partes del código.
     */

    public class HttpApiClient
    {

        public static HttpApiClient Instancia { get; } = new HttpApiClient();     // Única instancia de la clase

        public static HttpClient _httpClient;       // Propiedad de tipo HttpClient

        // Constructor
        public HttpApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7138"); // Establece la URL base para las solicitudes HTTP.
        }

        // Permite acceder al objeto HttpClient desde fuera
        public HttpClient GetHClient()
        {
            return _httpClient;
        }
    }
}
