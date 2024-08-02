namespace ApiBasesDeDatosProyecto.Models
{
    public class ClienteAltaDto
    {
        public string UserId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Empleo { get; set; }
        public string NombrePais { get; set; }

        public int PaisId { get; set; }
    }
}
