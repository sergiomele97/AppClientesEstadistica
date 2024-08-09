namespace BackendEstadistica.Models;

public class PaisDto
{
    public int PaisId { get; set; }
    public string? Nombre { get; set; }
    public string? Divisa { get; set; }

    //Relaciones
    public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

}
