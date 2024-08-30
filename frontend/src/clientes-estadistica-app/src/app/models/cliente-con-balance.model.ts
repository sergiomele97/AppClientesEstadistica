export class ClienteConBalance {
  clienteId: number;
  nombre: string;
  edad: number;
  sexo: string;
  pais: string;
  balance: number;
  numeroGastos: number;
  numeroIngresos: number;

  constructor(init?: Partial<ClienteConBalance>) {
    Object.assign(this, init);
  }
}
