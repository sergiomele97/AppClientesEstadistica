import { ICliente } from './cliente';

export interface ITransaccion {
  transaccionId: number;
  importeRecibido: number;
  importeEnviado: number;
  fecha?: Date;
  isOutlier: boolean;
  clienteOrigenId: number;
  clienteDestinoId: number;

  // Relaciones
  clienteOrigen: ICliente;
  clienteDestino: ICliente;
}
