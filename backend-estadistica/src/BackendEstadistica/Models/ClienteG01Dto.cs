namespace BackendEstadistica.Models;

public class ClienteG01Dto
{
    public int Id { get; set; }
    public string? Usuario { get; set; }
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public int PaisId { get; set; }

}
