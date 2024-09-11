/**
 * Interfaz que define las propiedades de un envío.
 * @interface
 */
export interface IEnvio {
  /**
   * Identificador único del envío.
   * @type {number}
   */
  id: number;

  /**
   * Tipo de divisa utilizada en el envío.
   * @type {string}
   */
  divisa: string;

  /**
   * Cantidad de divisa enviada.
   * @type {number}
   */
  cantidad: number;

  /**
   * Fecha en que se realizó el envío.
   * @type {Date}
   */
  fecha: Date;
}
