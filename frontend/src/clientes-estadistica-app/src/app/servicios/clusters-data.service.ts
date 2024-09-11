import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

/**
 * Servicio para manejar la comunicación de datos relacionados con clusters.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class ClustersDataService {
  /**
   * Subject para emitir datos seleccionados de una tabla.
   * @private
   */
  private selectedDataTable = new Subject<any[]>();

  /**
   * Observable que emite los datos seleccionados de una tabla.
   * @public
   */
  selectedDataTable$ = this.selectedDataTable.asObservable();

  /**
   * Subject para emitir datos seleccionados de un cluster.
   * @private
   */
  private selectedDataCluster = new Subject<any[]>();

  /**
   * Observable que emite los datos seleccionados de un cluster.
   * @public
   */
  selectedDataCluster$ = this.selectedDataCluster.asObservable();

  /**
   * Subject para emitir un cluster seleccionado.
   * @private
   */
  private selectedClusterSubject = new Subject<any>();

  /**
   * Observable que emite el cluster seleccionado.
   * @public
   */
  selectedCluster$ = this.selectedClusterSubject.asObservable();

  /**
   * Subject para emitir etiquetas seleccionadas.
   * @private
   */
  private selectedLabelSubject = new Subject<any[]>();

  /**
   * Observable que emite las etiquetas seleccionadas.
   * @public
   */
  selectedLabel$ = this.selectedLabelSubject.asObservable();

  /**
   * Subject para emitir índices de base de datos seleccionados.
   * @private
   */
  private selectedIndexDB = new Subject<any[]>();

  /**
   * Observable que emite los índices de base de datos seleccionados.
   * @public
   */
  selectedDB$ = this.selectedIndexDB.asObservable();

  /**
   * Crea una instancia del servicio de datos de clusters.
   * @param {HttpClient} http - Servicio para realizar solicitudes HTTP (actualmente no utilizado).
   */
  constructor() {}

  /**
   * Establece los datos seleccionados de una tabla y los emite a través del observable.
   * @param {any[]} data - Datos seleccionados de la tabla.
   */
  setSelectedDataTable(data: any[]): void {
    this.selectedDataTable.next(data);
  }

  /**
   * Establece los datos seleccionados de un cluster y los emite a través del observable.
   * @param {any[]} data - Datos seleccionados del cluster.
   */
  setSelectedDataCluster(data: any[]): void {
    this.selectedDataCluster.next(data);
  }

  /**
   * Establece un cluster seleccionado y lo emite a través del observable.
   * @param {any} data - Cluster seleccionado.
   */
  setSelectednCluster(data: any): void {
    this.selectedClusterSubject.next(data);
  }

  /**
   * Establece las etiquetas seleccionadas y las emite a través del observable.
   * @param {any[]} data - Etiquetas seleccionadas.
   */
  setLabel(data: any[]): void {
    this.selectedLabelSubject.next(data);
  }

  /**
   * Establece los índices de base de datos seleccionados y los emite a través del observable.
   * @param {any[]} data - Índices de base de datos seleccionados.
   */
  setIndexDB(data: any[]): void {
    this.selectedIndexDB.next(data);
  }

  /**
   * Método asíncrono para enviar datos al backend.
   * Este método actualmente no está implementado.
   * @returns {Promise<void>} - Una promesa que se resuelve cuando la lógica se implementa.
   */
  async sendDataToBackend(): Promise<void> {
    // Implementar lógica para enviar datos al backend aquí.
    throw new Error('Método no implementado');
  }
}
