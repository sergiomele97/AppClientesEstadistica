import { ICliente } from './cliente';

export interface IConversion {
  conversionId: number;
  fecha?: Date;
  monedaOrigen?: string;
  monedaDestino?: string;
  valorOrigen?: number;
  valorDestino?: number;
  clienteId: number;

  // Relaciones
  cliente: ICliente;
}
