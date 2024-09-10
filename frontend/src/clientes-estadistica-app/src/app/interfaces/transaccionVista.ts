/**
 * Interfaz que define las propiedades de una transacción con información adicional de clientes.
 * @interface
 */
export interface ITransaccionVita {
  /**
   * Identificador único de la transacción.
   * @type {number}
   */
  transaccionId: number;

  /**
   * Identificador del cliente origen de la transacción.
   * @type {number}
   */
  clienteOrigenId: number;

  /**
   * Nombre del cliente origen de la transacción.
   * @type {string}
   */
  clienteOrigenNombre: string;

  /**
   * Correo electrónico del cliente origen de la transacción.
   * @type {string}
   */
  clienteOrigenCorreo: string;

  /**
   * Teléfono del cliente origen de la transacción.
   * @type {string}
   */
  clienteOrigenTelefono: string;

  /**
   * Identificador del cliente destino de la transacción.
   * @type {number}
   */
  clienteDestinoId: number;

  /**
   * Nombre del cliente destino de la transacción.
   * @type {string}
   */
  clienteDestinoNombre: string;

  /**
   * Correo electrónico del cliente destino de la transacción.
   * @type {string}
   */
  clienteDestinoCorreo: string;

  /**
   * Teléfono del cliente destino de la transacción.
   * @type {string}
   */
  clienteDestinoTelefono: string;

  /**
   * Divisa utilizada por el cliente origen.
   * @type {string}
   */
  clienteOrigenDivisa: string;

  /**
   * Divisa utilizada por el cliente destino.
   * @type {string}
   */
  clienteDestinoDivisa: string;

  /**
   * Importe enviado en la transacción.
   * @type {number}
   */
  importeEnviado: number;

  /**
   * Importe recibido en la transacción.
   * @type {number}
   */
  importeRecibido: number;

  /**
   * Fecha en la que se realizó la transacción.
   * @type {Date}
   */
  fecha: Date;
}
