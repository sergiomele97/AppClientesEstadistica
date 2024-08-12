namespace BackendEstadistica.Models;

public class ClienteDto
{
    public int ClienteId { get; set; }
    public string? Nombre { get; set; }
    public string? Contraseña { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public int? Edad { get; set; }
    public string? Sexo { get; set; }
    public string? Trabajo { get; set; }
    public int PaisId { get; set; }

    public PaisDto? Pais { get; set; } // DTO para el país
    public List<TransaccionDto> TransaccionesOrigen { get; set; } = new List<TransaccionDto>();
    public List<TransaccionDto> TransaccionesDestino { get; set; } = new List<TransaccionDto>();
    public List<ConversionDto> Conversiones { get; set; } = new List<ConversionDto>(); // DTO para las conversiones
}
