namespace BackendEstadistica.Entidades;

public class Pais
{
    [Key]
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Divisa { get; set; }

}
