export interface ITransaccionVita {
    transaccionId: number;
    clienteOrigenId: number;
    clienteOrigenNombre: string;
    clienteOrigenCorreo: string;
    clienteOrigenTelefono: string;
    clienteDestinoId: number;
    clienteDestinoNombre: string;
    clienteDestinoCorreo: string;
    clienteDestinoTelefono: string;
    clienteOrigenDivisa: string;
    clienteDestinoDivisa: string;
    importeEnviado: number;
    importeRecibido: number;
    fecha: Date; 
  }
  
  