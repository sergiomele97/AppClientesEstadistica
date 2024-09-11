import { Pipe, PipeTransform } from '@angular/core';

/**
 * Pipe para formatear valores numéricos a dos decimales.
 * @pipe
 */
@Pipe({
  name: 'formatearDecimal',
})
export class FormatearDecimalPipe implements PipeTransform {
  /**
   * Transforma un valor numérico en un número con dos decimales.
   * Si el valor es `null` o `undefined`, devuelve `0`.
   * @param {number | null} value - El valor numérico a formatear.
   * @returns {number} - El valor formateado con dos decimales.
   */
  transform(value: number | null): number {
    if (value == null) {
      // Verifica si el valor es null o undefined
      return 0;
    }

    // Verifica si el valor es un número válido y formatea a dos decimales
    return !isNaN(value) ? parseFloat(value.toFixed(2)) : 0;
  }
}
