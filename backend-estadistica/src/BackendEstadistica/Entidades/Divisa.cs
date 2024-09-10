<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations.Schema;
﻿namespace BackendEstadistica.Entidades;

/// <summary>
/// Representa una divisa en el sistema, con su valor en relación al dólar.
/// </summary>
public class Divisa
{
    /// <summary>
    /// Identificador único del historial de las divisas.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Esto generará un ID único autoincremental
    public int DivisaId { get; set; }

    /// <summary>
    /// Nombre de la divisa (ejemplo: USD, EUR).
    /// </summary>
    [Required(ErrorMessage = "El nombre de la divisa es obligatorio.")]
    [StringLength(3, ErrorMessage = "El nombre de la divisa debe tener un máximo de 3 caracteres.")]
    public string? Nombre { get; set; }

    /// <summary>
    /// Valor de la divisa respecto al dólar.
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "El valor de la divisa debe ser un valor positivo.")]
    public double? Valor { get; set; }

    /// <summary>
    /// Fecha de registro del valor de la divisa. Todas las divisas dentro del mismo ID tendrán la misma fecha.
    /// </summary>
    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateTime? Fecha { get; set; }
}
