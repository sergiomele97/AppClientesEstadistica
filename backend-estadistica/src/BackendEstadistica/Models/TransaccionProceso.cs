namespace BackendEstadistica.Models
{
    public class TransaccionProceso
    {
        [Key]
        public int TransaccionId { get; set; }
        public int ClienteOrigenId { get; set; }
        public string ClienteOrigenNombre { get; set; }
        public string ClienteOrigenCorreo { get; set; }
        public string ClienteOrigenTelefono { get; set; }
        public int ClienteDestinoId { get; set; }
        public string ClienteDestinoNombre { get; set; }
        public string ClienteDestinoCorreo { get; set; }
        public string ClienteDestinoTelefono { get; set; }
        public string ClienteOrigenDivisa { get; set; }
        public string ClienteDestinoDivisa { get; set; }
        public double ImporteEnviado { get; set; }
        public double ImporteRecibido { get; set; }
        public DateTime Fecha { get; set; }
    }

}
