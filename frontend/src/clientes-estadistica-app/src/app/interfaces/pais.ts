/**
 * Interfaz que define las propiedades de un país.
 * @interface
 */
export interface IPais {
  /**
   * Identificador único del país.
   * @type {number}
   */
  paisId: number;

  /**
   * Nombre del país.
   * @type {string}
   */
  nombre: string;

  /**
   * Nombre de la divisa utilizada en el país.
   * @type {string}
   */
  divisa: string;

  /**
   * Código ISO 3166-1 alfa-3 del país (ejemplo: "USA").
   * @type {string}
   */
  iso3: string;
}
