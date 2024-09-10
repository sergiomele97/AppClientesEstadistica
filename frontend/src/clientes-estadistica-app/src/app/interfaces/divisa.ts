/**
 * Interfaz que define las propiedades de una divisa.
 * @interface
 */
export interface IDivisa {
  /**
   * Identificador único de la divisa.
   * @type {number}
   */
  divisaId: number;

  /**
   * Nombre de la divisa.
   * @type {string}
   */
  nombre: string;

  /**
   * Valor actual de la divisa.
   * @type {number}
   */
  valor: number;

  /**
   * Fecha en que se registró el valor de la divisa.
   * @type {Date}
   * @optional
   */
  fecha?: Date;
}
