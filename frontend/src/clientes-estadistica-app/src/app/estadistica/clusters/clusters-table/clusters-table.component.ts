import { Component, OnInit } from '@angular/core';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';
import { combineLatest } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-clusters-table',
  templateUrl: './clusters-table.component.html',
  styleUrls: ['./clusters-table.component.css']
})
export class ClustersTableComponent implements OnInit {
  public tableData: any[] = [];
  public columnHeaders: string[] = [];
  public filterText: string = ''; // Añadir propiedad para el texto del filtro
  public filteredTableData: any[] = []; // Añadir propiedad para los datos filtrados

  constructor(private dataService: ClustersDataService) { }

  ngOnInit() {
    combineLatest([this.dataService.selectedDataTable$, this.dataService.selectedLabel$])
      .subscribe(([data, label]) => {
       // console.log('Data:', data);
       // console.log('Label:', label);

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

        this.filteredTableData = this.tableData; // Inicializa los datos filtrados

        // Observa cambios en el texto del filtro y aplica el filtro
        this.applyFilter();
      });
  }

  // Método para aplicar el filtro
  applyFilter() {
    this.filteredTableData = this.tableData.filter(row => {
      // Asegurarse de que el valor de la etiqueta sea una cadena
      const label = String(row[row.length - 1]);
      return label.toLowerCase().includes(this.filterText.toLowerCase());
    });
  }

  // Método para manejar cambios en el filtro
  onFilterChange() {
    this.applyFilter();
  }
}
