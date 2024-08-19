

namespace BackendEstadistica.Entidades;

public class Pais
{
    [Key]
    public int PaisId { get; set; }
    public string? Nombre { get; set; }
    public string? Divisa { get; set; }
    public string? Iso3 { get; set; }

    //Relaciones
    [JsonIgnore]
    public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
