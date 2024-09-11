// src/app/components/clusters-table/clusters-table.component.ts

import { Component, OnInit } from '@angular/core';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';
import { combineLatest } from 'rxjs';

/**
 * Componente para mostrar y gestionar una tabla de clusters.
 */
@Component({
  selector: 'app-clusters-table',
  templateUrl: './clusters-table.component.html',
  styleUrls: ['./clusters-table.component.css'],
})
export class ClustersTableComponent implements OnInit {
  public tableData: any[] = []; // Datos de la tabla
  public columnHeaders: string[] = []; // Encabezados de columna
  public filterText: string = ''; // Texto de filtro
  public filteredTableData: any[] = []; // Datos filtrados
  public sortColumn: number | null = null; // Índice de la columna para ordenar
  public sortDirection: 'asc' | 'desc' = 'asc'; // Dirección de ordenamiento

  /**
   * Constructor del componente.
   * @param dataService Servicio de datos de clusters.
   */
  constructor(private dataService: ClustersDataService) {}

  /**
   * Inicializa el componente.
   */
  ngOnInit() {
    combineLatest([
      this.dataService.selectedDataTable$,
      this.dataService.selectedLabel$,
    ]).subscribe(([data, label]) => {
      if (!Array.isArray(data) || !Array.isArray(label)) {
        console.error('Data or label is not an array');
        return;
      }

      const maxItemLength = Math.max(...data.map((item) => item.length));

      this.columnHeaders = Array.from(
        { length: maxItemLength },
        (_, i) => `Variable ${i + 1}`
      );
      this.columnHeaders.push('Grupo');

      this.tableData = data.map((item: any[], index: number) => {
        const paddedItem = [
          ...item,
          ...Array(maxItemLength - item.length).fill(''),
        ];
        return [...paddedItem, label[index] || 'N/A'];
      });

      this.filteredTableData = [...this.tableData];
      this.applyFilter();
    });
  }

  /**
   * Aplica el filtro a los datos de la tabla.
   */
  applyFilter() {
    this.filteredTableData = this.tableData.filter((row) => {
      const label = String(row[row.length - 1]);
      return label.toLowerCase().includes(this.filterText.toLowerCase());
    });
    this.sortData(); // Ordenar después de filtrar
  }

  /**
   * Maneja el cambio en el texto del filtro.
   */
  onFilterChange() {
    this.applyFilter();
  }

  /**
   * Ordena los datos de la tabla por una columna específica.
   * @param columnIndex Índice de la columna para ordenar.
   */
  sortData(columnIndex: number | null = null) {
    if (this.sortColumn === columnIndex) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = columnIndex;
      this.sortDirection = 'asc';
    }

    this.filteredTableData.sort((a, b) => {
      const aValue = a[columnIndex];
      const bValue = b[columnIndex];

      if (aValue < bValue) return this.sortDirection === 'asc' ? -1 : 1;
      if (aValue > bValue) return this.sortDirection === 'asc' ? 1 : -1;
      return 0;
    });
  }
}
