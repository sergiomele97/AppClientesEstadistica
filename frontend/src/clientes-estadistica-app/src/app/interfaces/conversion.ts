import { ICliente } from './cliente';

/**
 * Interfaz que define las propiedades de una conversión.
 * @interface
 */
export interface IConversion {
  /**
   * Identificador único de la conversión.
   * @type {number}
   */
  conversionId: number;

  /**
   * Fecha en que se realizó la conversión.
   * @type {Date}
   * @optional
   */
  fecha?: Date;

  /**
   * Moneda de origen en la conversión.
   * @type {string}
   * @optional
   */
  monedaOrigen?: string;

  /**
   * Moneda de destino en la conversión.
   * @type {string}
   * @optional
   */
  monedaDestino?: string;

  /**
   * Valor original antes de la conversión.
   * @type {number}
   * @optional
   */
  valorOrigen?: number;

  /**
   * Valor resultante después de la conversión.
   * @type {number}
   * @optional
   */
  valorDestino?: number;

  /**
   * Identificador del cliente asociado a la conversión.
   * @type {number}
   */
  clienteId: number;

  /**
   * Relación con el cliente que realizó la conversión.
   * @type {ICliente}
   */
  cliente: ICliente;
}
