/**
 * Interfaz que define las propiedades de un usuario en el sistema.
 * @interface
 */
export interface IUsuario {
  /**
   * Correo electrónico del usuario. Debe ser único en el sistema.
   * @type {string}
   */
  email: string;

  /**
   * Contraseña del usuario. Debe ser protegida y no almacenada en texto plano.
   * @type {string}
   */
  password: string;

  /**
   * Confirmación de la contraseña del usuario. Usada para validar que la contraseña
   * y su confirmación coincidan durante el registro o cambio de contraseña.
   * @type {string}
   */
  confirmpassword: string;

  /**
   * Número de teléfono del usuario. Puede ser utilizado para comunicación o verificación.
   * @type {string}
   */
  phoneNumber: string;
}
