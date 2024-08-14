namespace BackendEstadistica.Entidades;

public class Transaccion
{
    [Key]
    public int TransaccionId { get; set; }
    public double? ImporteRecibido { get; set; }
    public double? ImporteEnviado { get; set; }
    public DateTime? Fecha { get; set; }
    public int ClienteOrigenId { get; set; }
    public int ClienteDestinoId { get; set; }

    //Relaciones
    public Cliente ClienteOrigen { get; set; } = null!;
    public Cliente ClienteDestino { get; set; } = null!;

}
