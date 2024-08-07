import { Timestamp } from "rxjs";

export interface Usuario {
    Email: string;
    Password: string;
    ConfirmPassword: string;
    Nombre: string;
    Apellido: string;
    Rol: string;
    PaisId: number;
    Empleo: string;
    FechaNacimiento: number; // Asegúrate de que FechaNac sea de tipo Date
  }
  