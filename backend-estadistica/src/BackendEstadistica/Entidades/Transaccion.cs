namespace BackendEstadistica.Entidades;

public class Transaccion
{
    [Key]
    public int Id { get; set; }
    public double? ImporteRecibido { get; set; }
    public double? ImporteEnviado { get; set; }
    public DateTime? Fecha { get; set; }
    public int IdOrigen { get; set; }
    public int IdDestino { get; set; }
    public Cliente ClienteOrigen { get; set; }
    public Cliente ClienteDestino { get; set; }

}
