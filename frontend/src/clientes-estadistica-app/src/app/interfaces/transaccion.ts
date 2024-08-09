import { ICliente } from './cliente';

export interface ITransaccion {
  transaccionId: number;
  importeRecibido: number;
  importeEnviado: number;
  fecha?: Date;
  clienteOrigenId: number;
  clienteDestinoId: number;

  // Relaciones
  clienteOrigen: ICliente;
  clienteDestino: ICliente;
}
