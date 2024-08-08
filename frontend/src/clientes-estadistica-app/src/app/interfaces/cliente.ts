import { IConversion } from "./conversion";
import { ITransaccion } from "./transaccion";

export interface ICliente {
    id: number;
    nombre?: string;
    contraseña?: string;
    correo?: string;
    telefono?: string;
    edad?: number;
    sexo?: string;
    trabajo?: string;
    conversiones?: IConversion[];  // Relación con Conversiones
    transaccionesOrigen?: ITransaccion[];  // Relación con Transacciones como origen
    transaccionesDestino?: ITransaccion[];  // Relación con Transacciones como destino
  }
  