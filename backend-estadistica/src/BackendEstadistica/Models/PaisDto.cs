namespace BackendEstadistica.Models;

public class PaisDto
{
    public int PaisId { get; set; }
    public string? Nombre { get; set; }
    public string? Divisa { get; set; }

    //Relaciones
    public Cliente? Cliente { get; set; }

}
