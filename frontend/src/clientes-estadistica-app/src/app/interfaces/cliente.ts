import { IPais } from './pais';

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
}