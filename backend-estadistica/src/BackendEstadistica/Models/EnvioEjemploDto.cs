namespace BackendEstadistica.Models
{
    public class EnvioEjemploDto
    {

        public int Id { get; set; }
        public string? Divisa { get; set; }
        public double? Cantidad { get; set; }
        public DateTime? Fecha { get; set; }

    }
}
