namespace BackendEstadistica.Entidades
{
    
    public class Divisa
    {
        [Key]
        public int DivisaId { get; set; } // id del historico de las divisas
        public string? Nombre { get; set; } //Nombres de las divisas
        public double? Valor { get; set; } // valor de la vidisa respecto al dolar
        public DateTime? Fecha { get; set; } //la fecha, igual para todas las divisas dentro del mismo id

    }
}
