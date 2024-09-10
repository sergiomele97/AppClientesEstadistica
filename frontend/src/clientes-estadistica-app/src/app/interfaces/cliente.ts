import { IPais } from './pais';

/**
 * Interfaz que define las propiedades de un cliente.
 * @interface
 */
export interface ICliente {
  /**
   * Identificador único del cliente.
   * @type {number}
   */
  clienteId: number;

  /**
   * Nombre del cliente.
   * @type {string}
   * @optional
   */
  nombre?: string;

  /**
   * Contraseña del cliente.
   * @type {string}
   * @optional
   */
  contraseña?: string;

  /**
   * Correo electrónico del cliente.
   * @type {string}
   * @optional
   */
  correo?: string;

  /**
   * Teléfono del cliente.
   * @type {string}
   * @optional
   */
  telefono?: string;

  /**
   * Edad del cliente.
   * @type {number}
   * @optional
   */
  edad?: number;

  /**
   * Sexo del cliente.
   * @type {string}
   * @optional
   */
  sexo?: string;

  /**
   * Trabajo del cliente.
   * @type {string}
   * @optional
   */
  trabajo?: string;

  /**
   * Relación con el país del cliente.
   * @type {IPais}
   */
  pais: IPais;
}
