import { IConversion } from "./conversion";

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
    transaccionesOrigen?: ITransaccion[];  // Relación con Transacciones como origen (pérdidas)
    transaccionesDestino?: ITransaccion[];  // Relación con Transacciones como destino (ingresos)
  }
  
  // datos para ejemplo

  export interface ITransaccion {
    id: number;
    cantidad: number;
    fecha: string;
    divisa: string;
}