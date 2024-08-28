export interface IUsuario {
    email: string;           // Correo electrónico del usuario (debería ser único)
    password: string;       // Contraseña del usuario
    confirmpassword: string;  // Confirmación de la contraseña (probablemente temporal, para la validación en el front)
    phoneNumber: string;         // Número de teléfono del usuario
  }