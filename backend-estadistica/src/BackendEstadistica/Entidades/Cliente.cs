namespace BackendEstadistica.Entidades;

public class Cliente
{

    [Key]
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Contraseña { get; set; }
    public string? Correo { get; set; }
    public int? Telefono { get; set; }
    public int? Edad { get; set; }
    public string? Sexo { get; set; }
    public string? Trabajo { get; set; }
    public ICollection<Conversion> Conversionos { get; } = new List<Conversion>();

}
