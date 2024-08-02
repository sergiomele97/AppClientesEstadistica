namespace BackendEstadistica.Entidades
{
    public class EnvioEjemplo
    {

        [Key]
        public int Id { get; set; }
        public string? Divisa { get; set; }
        public double? Cantidad { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM}")]
        public DateTime? Fecha { get; set; }



    }
}
