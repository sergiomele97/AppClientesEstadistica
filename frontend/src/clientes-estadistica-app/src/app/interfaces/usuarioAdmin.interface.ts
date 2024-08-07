import { Timestamp } from "rxjs";

export interface UsuarioAdmin {
    Email: string;
    Password: string;
    ConfirmPassword: string;
    Rol: string;
    PaisId: number;
    FechaNacimiento: number; // Asegúrate de que FechaNac sea de tipo Date
  }
  