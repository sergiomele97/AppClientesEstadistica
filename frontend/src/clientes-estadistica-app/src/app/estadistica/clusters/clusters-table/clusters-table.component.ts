import { Component, OnInit } from '@angular/core';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';
import { combineLatest } from 'rxjs';

@Component({
  selector: 'app-clusters-table',
  templateUrl: './clusters-table.component.html',
  styleUrls: ['./clusters-table.component.css']
})
export class ClustersTableComponent implements OnInit {
  public tableData: any[] = [];
  public columnHeaders: string[] = [];
  public filterText: string = '';
  public filteredTableData: any[] = [];
  public sortColumn: number | null = null; // Índice de la columna por la que ordenar
  public sortDirection: 'asc' | 'desc' = 'asc'; // Dirección de ordenamiento

  constructor(private dataService: ClustersDataService) { }

  ngOnInit() {
    combineLatest([this.dataService.selectedDataTable$, this.dataService.selectedLabel$])
      .subscribe(([data, label]) => {
        if (!Array.isArray(data) || !Array.isArray(label)) {
          console.error('Data or label is not an array');
          return;
        }

        const maxItemLength = Math.max(...data.map(item => item.length));
        
        this.columnHeaders = Array.from({ length: maxItemLength }, (_, i) => `Variable ${i + 1}`);
        this.columnHeaders.push('Grupo');

        this.tableData = data.map((item: any[], index: number) => {
          const paddedItem = [...item, ...Array(maxItemLength - item.length).fill('')];
          return [...paddedItem, label[index] || 'N/A'];
        });

        this.filteredTableData = [...this.tableData]; // Inicializa los datos filtrados
        this.applyFilter();
      });
  }

  applyFilter() {
    this.filteredTableData = this.tableData.filter(row => {
      const label = String(row[row.length - 1]);
      return label.toLowerCase().includes(this.filterText.toLowerCase());
    });
    this.sortData(); // Ordenar después de filtrar
  }

  onFilterChange() {
    this.applyFilter();
  }

  sortData(columnIndex: number | null = null) {
    if (this.sortColumn === columnIndex) {
      // Si ya estamos ordenando por esta columna, alternar la dirección
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      // Si estamos ordenando por una columna diferente, establecer la dirección a ascendente
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
