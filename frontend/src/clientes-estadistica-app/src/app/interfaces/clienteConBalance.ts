import { ICliente } from './cliente';

export interface IClienteConBalance {
  
  nombre: string;
  edad: number;
  sexo: string;
  pais: string;
  balance: number;
  numeroGastos: number;
  numeroIngresos: number;

  cliente: ICliente;
}