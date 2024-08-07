namespace BackendEstadistica.Entidades;

public class Transaccion
{
    [Key]
    public int Id { get; set; }
    public double? importeRecibido { get; set; }
    public double? importeEnviado { get; set; }
    public DateTime? Fecha { get; set; }
    public int idOrigen { get; set; }
    public int idDestino { get; set; }




}
