import { DatePipe } from '@angular/common';
import { Injectable, Pipe, PipeTransform } from '@angular/core';

/**
 * Pipe para formatear fechas en formato 'dd/MM/yy'.
 * @pipe
 */
@Pipe({
  name: 'formaterFecha',
})
@Injectable({
  providedIn: 'root',
})
export class FormaterFechaPipe implements PipeTransform {
  /**
   * Crea una instancia de `FormaterFechaPipe`.
   * @param {DatePipe} datePipe - El servicio `DatePipe` para formatear fechas.
   */
  constructor(private datePipe: DatePipe) {}

  /**
   * Transforma un valor en una cadena de texto formateada como fecha.
   * Si el valor es `null` o `undefined`, devuelve una cadena vacía.
   * @param {Date | string | null} value - El valor que se transformará en fecha.
   * @returns {string} - La fecha formateada como 'dd/MM/yy'.
   */
  transform(value: Date | string | null): string {
    if (!value) {
      return '';
    }
    return this.datePipe.transform(value, 'dd/MM/yy')!;
  }
}
