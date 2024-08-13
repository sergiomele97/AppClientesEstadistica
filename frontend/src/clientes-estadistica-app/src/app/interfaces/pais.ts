import { ICliente } from "./cliente";

export interface IPais {
    paisId: number;
    nombre: string;
    divisa: string;

    clientes: ICliente[];
}
