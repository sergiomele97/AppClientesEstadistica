using System.ComponentModel.DataAnnotations.Schema;
namespace BackendEstadistica.Entidades
{
    
    public class Divisa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Esto generará un ID único autoincremental
        public int DivisaId { get; set; }
        public string? Nombre { get; set; } //Nombres de las divisas
        public double? Valor { get; set; } // valor de la vidisa respecto al dolar
        public DateTime? Fecha { get; set; } //la fecha, igual para todas las divisas dentro del mismo id

    }
}
