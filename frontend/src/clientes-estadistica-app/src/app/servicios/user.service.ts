import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Usuario } from '../clases/usuario';
import { environment } from '../../environments/environment';
import { Cliente } from '../clases/cliente';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  // IMPORTANTE:
  //    1 URL ESTADISTICA Y OTRA PARA CLIENTES
  private readonly url_estadistica = environment.apiEstadisticas;
  private readonly url_usuarios = environment.apiUsuarios;

  //URL AMIN
  private readonly URL = "https://localhost:7107/api/";

  constructor(private http: HttpClient) { }

  getUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${this.URL}Account/users`);
  }

  autenticarUsuario(email: string, password: string, remember: boolean): Observable<any> {
    // Crea un objeto con las propiedades que el backend espera
    const loginPayload = {
      Email: email,
      Password: password,
      RememberMe: remember // Mantén este nombre para que coincida con el modelo del backend
    };
    
    // Realiza la solicitud POST al endpoint de login
    return this.http.post<any>(`${this.url_usuarios}/login`, loginPayload);
  }
  

  registrarUsuario(usuario: any): Observable<any> {
    console.log(usuario); // Asegúrate de que los campos estén presentes y correctos DEBUG
    return this.http.post<any>(`${this.url_usuarios}`, usuario);
  }

  añadirRolUsuario(usuario: any): Observable<any> {
    console.log(usuario); // Asegúrate de que los campos estén presentes y correctos DEBUG
    return this.http.post<any>(`${this.URL}Account/cambiarRolPorEmail`, usuario);
  }

  obtenerPaisIdPorNombre(nombre: string): Observable<{ id: number }> {
    // Construir la URL con el nombre del país
    const url = `${this.URL}Paises/nombre/${nombre}`;
    // Hacer la solicitud GET
    return this.http.get<{ id: number }>(url);
  }

  editarCliente(cliente: Cliente): Observable<any>{
    console.log('Enviando PUT para cliente:', cliente);
    const url = `${this.URL}Cliente/${cliente.email}`;
    cliente.fechaNacimiento = new Date(cliente.fechaNacimiento).getTime();
    return this.http.put(url, cliente);
  }

  getEnvios(): Observable<any[]> {
    return this.http.get<any[]>(`${this.url_estadistica}/getEnvios`).pipe(
      map(envios => envios.map(envio => ({
        ...envio,
        fecha: this.formatearFecha(envio.fecha),
        cantidad: this.formatearCantidad(envio.cantidad)
      })))
    );
  }

  private formatearFecha(fecha: any): string {
    let fechaDate: Date;

    // Intenta crear un objeto Date a partir del valor proporcionado
    if (fecha instanceof Date) {
      fechaDate = fecha;
    } else if (typeof fecha === 'string') {
      fechaDate = new Date(fecha);
    } else {
      // Si la fecha no es una instancia de Date ni una cadena, devuelves un valor vacío o un error.
      return '';
    }

    // Verifica si la fecha es válida
    if (isNaN(fechaDate.getTime())) {
      return ''; // Retorna una cadena vacía o algún valor por defecto en caso de error
    }

    const day = fechaDate.getDate().toString().padStart(2, '0');
    const month = (fechaDate.getMonth() + 1).toString().padStart(2, '0');
    const year = fechaDate.getFullYear().toString().slice(-2);

    return `${day}/${month}/${year}`;
  }

  private formatearCantidad(cantidad: number): string {
    return cantidad.toFixed(2);
  }
  
}
