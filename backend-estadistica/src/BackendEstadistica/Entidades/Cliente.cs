namespace BackendEstadistica.Entidades;

public class Cliente
{

    [Key]
    public int ClienteId { get; set; }
    public string? Nombre { get; set; }
    public string? Contraseña { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public int? Edad { get; set; }
    public string? Sexo { get; set; }
    public string? Trabajo { get; set; }
    public int PaisId { get; set; }

    //Relaciones
    public Pais Pais { get; set; } = null!;
    public ICollection<Conversion> Conversiones { get; set; } = new List<Conversion>();
    public ICollection<Transaccion> TransaccionesOrigen { get; set; } = new List<Transaccion>();
    public ICollection<Transaccion> TransaccionesDestino { get; set; } = new List<Transaccion>();

}
