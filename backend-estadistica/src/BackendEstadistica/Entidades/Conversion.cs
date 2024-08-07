﻿namespace BackendEstadistica.Entidades;

public class Conversion
{
    [Key]
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime? Fecha { get; set; }
    public string? MonedaOrigen { get; set; }
    public string? MonedaDestino { get; set; }
    public double? ValorOrigen { get; set; }
    public double? ValorDestino { get; set; }

}
