import { ICliente } from "./cliente";

export interface IPais {
    paisId: number;
    nombre: string;
    divisa: string;
    iso3: string;

    clientes: ICliente[];
}
