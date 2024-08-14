import { IConversion } from './conversion';
import { IPais } from './pais';
import { ITransaccion } from './transaccion';

export interface ICliente {
  clienteId: number;
  nombre?: string;
  contraseña?: string;
  correo?: string;
  telefono?: string;
  edad?: number;
  sexo?: string;
  trabajo?: string;
  
  pais: IPais; // Relación con Países
  conversiones?: IConversion[]; // Relación con Conversiones
  transaccionesOrigen?: ITransaccion[]; // Relación con Transacciones como origen (pérdidas)
  transaccionesDestino?: ITransaccion[]; // Relación con Transacciones como destino (ingresos)
}