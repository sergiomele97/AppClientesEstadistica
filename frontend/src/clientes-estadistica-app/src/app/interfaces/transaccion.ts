import { ICliente } from './cliente';

/**
 * Interfaz que define las propiedades de una transacción.
 * @interface
 */
export interface ITransaccion {
  /**
   * Identificador único de la transacción.
   * @type {number}
   */
  transaccionId: number;

  /**
   * Importe recibido en la transacción.
   * @type {number}
   */
  importeRecibido: number;

  /**
   * Importe enviado en la transacción.
   * @type {number}
   */
  importeEnviado: number;

  /**
   * Fecha en la que se realizó la transacción.
   * @type {Date}
   * @optional
   */
  fecha?: Date;

  /**
   * Indicador de si la transacción es un valor atípico.
   * @type {boolean}
   * @optional
   */
  isOutlier?: boolean;

  /**
   * Identificador del cliente origen de la transacción.
   * @type {number}
   */
  clienteOrigenId: number;

  /**
   * Identificador del cliente destino de la transacción.
   * @type {number}
   */
  clienteDestinoId: number;

  /**
   * Información del cliente origen de la transacción.
   * @type {ICliente}
   */
  clienteOrigen: ICliente;

  /**
   * Información del cliente destino de la transacción.
   * @type {ICliente}
   */
  clienteDestino: ICliente;
}
